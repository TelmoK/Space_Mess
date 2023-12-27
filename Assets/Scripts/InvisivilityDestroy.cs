using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisivilityDestroy : MonoBehaviour
{
    #region references

    private SpriteRenderer sprite;
    
    #endregion

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite != null && sprite.isVisible == false) Destroy(gameObject);
    }
}
