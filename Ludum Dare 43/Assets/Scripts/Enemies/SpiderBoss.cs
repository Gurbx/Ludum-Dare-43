using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBoss : MonoBehaviour {

    // Set in editor
    [SerializeField] private float acceleration;
    [SerializeField] private float horizontalDragCoefficient;
    [SerializeField] private float verticalDragCoefficient;
    [SerializeField] private float gravityAccel;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject childSprite;
    [SerializeField] private GameObject spiderMinionPrefab;

    private LayerMask wallsOnly;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private callback nextPositionAction;
    private float colliderSize;
    private GameObject player;

    private Orientation orientation;
    private enum Orientation {
        Ground,
        Wall,
        Ceiling
    }

    private delegate void callback(); // TODO: Make a better name

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("MainCamera");
        wallsOnly = 1 << LayerMask.NameToLayer("Walls");
        colliderSize = GetComponent<SphereCollider>().bounds.extents.magnitude;
        Debug.Log(colliderSize);
        rb = GetComponent<Rigidbody>();

        ClimbToCeiling();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, targetPosition);
    }

    private void FixedUpdate() {
        HandleMovementInput(targetPosition - transform.position);
        Rotate();

        if (nextPositionAction != null && 
            (targetPosition - transform.position).magnitude < colliderSize + 0.2f) {
            nextPositionAction();
        }
    }

    private void Rotate() {
        Vector3 toPlayer = player.transform.position - transform.position;
        float yAngle = Vector3.Angle(Vector3.forward, toPlayer);
        if (toPlayer.x < 0) {
            yAngle *= -1;
        }

        float targetZAngle = 0f;
        if (orientation == Orientation.Wall) {
            targetZAngle = 90f;
        } else if (orientation == Orientation.Ceiling) {
            targetZAngle = 180f;
        }
        float zAngle = childSprite.transform.rotation.eulerAngles.z;
        if (zAngle > 180) {
            zAngle -= 360;
        }
        zAngle += (targetZAngle - zAngle) * rotationSpeed;

        childSprite.transform.rotation = Quaternion.Euler(0, yAngle, zAngle);
    }

    private void HandleMovementInput(Vector3 direction) {
        if (orientation != Orientation.Wall) {
            direction.y = 0;
        }
        direction.Normalize();
        Vector3 accelerationForce = (direction).normalized * acceleration;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        Vector3 horizontalDrag = horizontalVelocity.sqrMagnitude * horizontalDragCoefficient * -horizontalVelocity;
        Vector3 verticalDrag = rb.velocity.y * rb.velocity.y * verticalDragCoefficient * Vector3.down * Mathf.Sign(rb.velocity.y);

        Vector3 gravityForce = Vector3.down * (orientation == Orientation.Ground ? gravityAccel : 0f);

        rb.AddForce(accelerationForce + horizontalDrag + verticalDrag + gravityForce);
    }

    private void ClimbToCeiling() {
        rb.velocity += Vector3.up;
        targetPosition = FindClosestWall();
        nextPositionAction = StartClimbing;
    }

    private void StartClimbing() {
        orientation = Orientation.Wall;
        targetPosition = FindCeilingAtPoint(transform.position);
        nextPositionAction = MoveAbovePlayer;
    }

    private void MoveAbovePlayer() {
        orientation = Orientation.Ceiling;
        targetPosition = FindCeilingAtPoint(player.transform.position);
        nextPositionAction = DropFromCeiling;
    }

    private void DropFromCeiling() {
        orientation = Orientation.Ground;
        targetPosition.y = 0;
        nextPositionAction = HitTheGround;
    }

    private void HitTheGround() {
        int numSpiders = Random.Range(1, 3);
        for (int i = 0; i < numSpiders; i++) {
            Vector3 spawnPos = transform.position + Random.onUnitSphere;
            spawnPos.y = 0.5f; // TODO: Use gravity instead
            Instantiate(spiderMinionPrefab, spawnPos, Quaternion.identity);
        }
        nextPositionAction = null;
        Invoke("ClimbToCeiling", 2f);
    }

    private Vector3 FindCeilingAtPoint(Vector3 point) {
        RaycastHit hit;
        Physics.Raycast(point, Vector3.up, out hit, Mathf.Infinity, wallsOnly);
        return hit.point;
    }

    private Vector3 FindClosestWall() {

        Vector3[] directions = new Vector3[] {
            Vector3.right,
            Vector3.left,
            Vector3.forward,
            Vector3.back
        };

        /*
        RaycastHit closest = new RaycastHit();
        closest.distance = Mathf.Infinity;

        foreach (Vector3 dir in directions) {
            RaycastHit hit;
            Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity, wallsOnly);
            if (hit.distance < closest.distance) {
                closest = hit;
            }
        }

        return closest.point;
        */

        RaycastHit hit;
        Physics.Raycast(transform.position, directions[Random.Range(0, directions.Length)], out hit, Mathf.Infinity, wallsOnly);
        return hit.point;
    }
}
