using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SnakeMonsterMain : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private float maxSpeed = 8;

    [SerializeField]
    private float minSpeed = 5;

    #endregion

    #region references

    private GameObject parentMonsterNode;

    [SerializeField]
    private GameObject snakeMonsterPrefab;

    private Transform _myTransform;

    private Transform parentNodeTransform;

    private Rigidbody2D body;

    #endregion

    #region properties

    [SerializeField]
    private int tailLeghtAtCurrentPoint;

    #endregion

    #region methods

    public void AddSnakeMonsterNode()
    {
        Vector2 instancePosition = (Vector2)_myTransform.position + new Vector2(1, 0) * GetComponent<CircleCollider2D>().radius * 2;
        GameObject sonMonsterInstance = Instantiate(snakeMonsterPrefab, instancePosition, Quaternion.identity);
        sonMonsterInstance.GetComponent<SnakeMonsterMain>().SnakeMonsterConstructor(gameObject, tailLeghtAtCurrentPoint - 1);
    }

    public void SnakeMonsterConstructor(GameObject parentNode, int tailLeght)
    {
        parentMonsterNode = parentNode;
        tailLeghtAtCurrentPoint = tailLeght;

        parentNodeTransform = parentMonsterNode.transform;
    }

    #endregion

    void Start()
    {
        Debug.Log("CREATED");
        _myTransform = transform;

        body = GetComponent<Rigidbody2D>();

        if (tailLeghtAtCurrentPoint > 0)
        {
            Debug.Log("Instance");
            AddSnakeMonsterNode();
        }
    }

    void Update()
    {
        if (parentMonsterNode == null) parentNodeTransform = FindObjectOfType<PlayerMain>().gameObject.transform;

        Vector2 distToTarget = parentNodeTransform.position - transform.position;

            if (distToTarget.magnitude < 25)
            {
                Vector2 movement = distToTarget;
                if (movement.magnitude > maxSpeed) movement = movement.normalized * maxSpeed;
                if (movement.magnitude < minSpeed) movement = movement.normalized * minSpeed;

                if (distToTarget.magnitude > 1.5f)
                    body.velocity = movement;
            }
    }
}
