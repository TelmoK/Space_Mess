using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ChasePlayerMovement : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float maxSpeed = 13;

    [SerializeField]
    private float minSpeed = 5;
    
    #endregion

    #region references

    [SerializeField]
    private Transform playerTransform;

    private Transform _myTransform;

    private Rigidbody2D body;

    #endregion

    #region properties

    private List<Vector2> pathPositions = new List<Vector2>();

    private List<Vector2> lastPlayerPositions = new List<Vector2>();

    private const int MAX_PREVIOUS_PLAYER_POSITIONS = 20;

    private Vector2 movementDirection = new Vector2();

    #endregion

    #region methods

    private void AddPlayerPreviousPosition()
    {
        lastPlayerPositions.Add(playerTransform.position);

        if(lastPlayerPositions.Count > MAX_PREVIOUS_PLAYER_POSITIONS) lastPlayerPositions.RemoveAt(0);
    }

    private Vector2 GetPreviousPlayerPosition()
    {
        return lastPlayerPositions[0];
    }

    private Vector2 GetMovementInFrontOfPlayer()
    {
        Vector2 distToPlayer = playerTransform.position - transform.position;
        
        Vector2 movement = Vector2.zero;

        if (distToPlayer.magnitude < 25)
        {
            movement = distToPlayer;
            if (movement.magnitude > maxSpeed) movement = movement.normalized * maxSpeed;
            if (movement.magnitude < minSpeed) movement = movement.normalized * minSpeed;
        }

        return movement;
    }

    #endregion

    void Start()
    {
        _myTransform = transform;

        body = GetComponent<Rigidbody2D>();

        AddPlayerPreviousPosition();
    }

    void Update()
    {
        RaycastHit2D directRayToPlayer = Physics2D.Raycast(_myTransform.position, playerTransform.position - _myTransform.position);
        
        if(directRayToPlayer.collider.gameObject.GetComponent<PlayerMain>() != null)
        {
            movementDirection = (playerTransform.position - _myTransform.position).normalized;

            pathPositions.Clear();

            body.velocity = GetMovementInFrontOfPlayer();
        }
        else
        {
            if (pathPositions.Count == 0) pathPositions.Add(GetPreviousPlayerPosition());

            RaycastHit2D pointRayToPlayer = Physics2D.Raycast(pathPositions[^1], (Vector2)playerTransform.position - pathPositions[^1]);

            if (pointRayToPlayer.collider.gameObject.GetComponent<PlayerMain>() == null)
            {
                pathPositions.Add(GetPreviousPlayerPosition());
            }

            movementDirection = (pathPositions[0] - (Vector2)_myTransform.position).normalized;
            body.velocity = movementDirection * maxSpeed;
        }

        if (pathPositions.Count > 0 && (pathPositions[0] - (Vector2)_myTransform.position).magnitude < 1) pathPositions.RemoveAt(0);

        AddPlayerPreviousPosition();
    }
}
