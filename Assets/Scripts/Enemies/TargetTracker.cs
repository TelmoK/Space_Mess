using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TargetTracker : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float maxSpeed = 13;

    [SerializeField]
    private float minSpeed = 5;
    
    #endregion

    #region references

    [SerializeField]
    public TimeTrackedTransform targetTimeTransform;

    private Transform _myTransform;

    private Rigidbody2D body;

    #endregion

    #region properties

    public enum TrackState { Idle, Chasing, Searching}
    private TrackState state;

    public TrackState State
    {
        get { return state; }
    }

    private List<Vector2> pathPositions = new List<Vector2>();

    private Vector2 movementDirection = new Vector2();

    #endregion

    #region methods

    private Vector2 GetMovementInFrontOfPlayer()
    {
        Vector2 distToPlayer = targetTimeTransform.position - transform.position;
        
        Vector2 movement = Vector2.zero;

        if (distToPlayer.magnitude < 60)
        {
            movement = distToPlayer;
            if (movement.magnitude > maxSpeed) movement = movement.normalized * maxSpeed;
            if (movement.magnitude < minSpeed) movement = movement.normalized * minSpeed;
        }

        return movement;
    }

    private void DeleteUnnecessaryPoints()
    {
        if (pathPositions.Count > 0 && (pathPositions[0] - (Vector2)_myTransform.position).magnitude < 1) pathPositions.RemoveAt(0);

        if (pathPositions.Count < 2) return;

        RaycastHit2D directRayToPathPoint = Physics2D.Raycast(_myTransform.position, pathPositions[1] - (Vector2)_myTransform.position);
        
        while (pathPositions.Count > 1 && directRayToPathPoint.collider == null)
        {
            pathPositions.RemoveAt(0);
            directRayToPathPoint = Physics2D.Raycast(_myTransform.position, pathPositions[1] - (Vector2)_myTransform.position);
        }
    }

    #endregion

    void Start()
    {
        _myTransform = transform;

        body = GetComponent<Rigidbody2D>();

        state = TrackState.Idle;
    }

    void Update()
    {
        RaycastHit2D directRayToPlayer = Physics2D.Raycast(_myTransform.position, targetTimeTransform.position - _myTransform.position);
        
        if(directRayToPlayer.collider.gameObject.GetComponent<PlayerMain>() != null)
        {
            state = TrackState.Chasing;
            
            movementDirection = (targetTimeTransform.position - _myTransform.position).normalized;

            pathPositions.Clear();

            body.velocity = GetMovementInFrontOfPlayer();
        }
        else
        {
            state = TrackState.Searching;

            if (pathPositions.Count == 0) pathPositions.Add(targetTimeTransform.GetPreviousPosition(60));

            //Last point of the path follows de target with a ray
            RaycastHit2D pointRayToPlayer = Physics2D.Raycast(pathPositions[^1], (Vector2)targetTimeTransform.position - pathPositions[^1]);

            if (pointRayToPlayer.collider.gameObject.GetComponent<PlayerMain>() == null)
            {
                pathPositions.Add(targetTimeTransform.GetPreviousPosition(60));
            }

            DeleteUnnecessaryPoints();

            movementDirection = (pathPositions[0] - (Vector2)_myTransform.position).normalized;
            body.velocity = movementDirection * maxSpeed;
        }

    }
}
