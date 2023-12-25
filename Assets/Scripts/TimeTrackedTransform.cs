using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrackedTransform : MonoBehaviour
{
    #region references

    private Transform _myTransform;

    #endregion

    #region properties

    private const int MAX_PREVIOUS_POSITIONS = 100;

    private List<Vector3> lastGameObjectPositions = new List<Vector3>();

    public Vector3 position
    {
        get { return _myTransform.position; }
    }

    #endregion

    #region methods

    private void AddGameObjectPreviousPosition()
    {
        lastGameObjectPositions.Add(_myTransform.position);

        if (lastGameObjectPositions.Count > MAX_PREVIOUS_POSITIONS) lastGameObjectPositions.RemoveAt(0);
    }

    public Vector3 GetPreviousPosition(int index)
    {
        if (index >= lastGameObjectPositions.Count) index = lastGameObjectPositions.Count - 1;
        if (index < 0) index = 0;

        return lastGameObjectPositions[index];
    }

    #endregion

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        AddGameObjectPreviousPosition();
    }
}
