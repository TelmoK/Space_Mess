using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region parameters



    #endregion

    #region references

    private Transform _myTransform;

    [SerializeField]
    private GameObject eyeKraken;

    [SerializeField]
    private GameObject bombMonster;

    [SerializeField]
    private GameObject starMonster;

    [SerializeField]
    private GameObject blackHoleMonster;

    private SpriteRenderer sprite;

    private ParticleSystem particles;

    #endregion

    #region methods
    
    public void CreateMonster()
    {
        particles.Play();

        float rand = Random.Range(0, 100);

        if (rand >= 0 && rand < 86) Instantiate(eyeKraken, _myTransform.position, Quaternion.identity);
        else if (rand >= 86 && rand < 95) Instantiate(bombMonster, _myTransform.position, Quaternion.identity);
        else if (rand >= 95 && rand < 98) Instantiate(starMonster, _myTransform.position, Quaternion.identity);
        else Instantiate(blackHoleMonster, _myTransform.position, Quaternion.identity);
    }
    
    #endregion

    void Start()
    {
        _myTransform = transform;

        sprite = GetComponent<SpriteRenderer>();

        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }
}
