using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlackHoleRender : MonoBehaviour
{
    #region references

    private CircleCollider2D gravityArea;

    [SerializeField]
    private GameObject GravitationLevel1;

    [SerializeField]
    private GameObject GravitationLevel2;

    [SerializeField]
    private GameObject GravitationLevel3;

    [SerializeField]
    private GameObject GravitationLevel4;

    [SerializeField]
    private GameObject GravitationLevel5;

    [SerializeField]
    private GameObject GravitationLevel6;

    [SerializeField]
    private GameObject GravitationLevel7;

    [SerializeField]
    private GameObject GravitationLevel8;

    [SerializeField]
    private GameObject GravitationLevel9;

    #endregion

    void Start()
    {
        gravityArea = GetComponent<CircleCollider2D>();

        GravitationLevel3.SetActive(gravityArea.radius > 2.39f);
        GravitationLevel4.SetActive(gravityArea.radius > 3.65f);
        GravitationLevel5.SetActive(gravityArea.radius > 5.17f);
        GravitationLevel6.SetActive(gravityArea.radius > 7.1f);
        GravitationLevel7.SetActive(gravityArea.radius > 9.4f);
        GravitationLevel8.SetActive(gravityArea.radius > 12.4f);
        GravitationLevel9.SetActive(gravityArea.radius > 15.9f);
    }

    private void FixedUpdate()
    {
        float pastAngle = 0;

        GravitationLevel1.transform.Rotate(new Vector3(0, 0, 1) * 79 * Time.deltaTime);
        GravitationLevel2.transform.Rotate(new Vector3(0, 0, 1) * -74 * Time.deltaTime);
        GravitationLevel3.transform.Rotate(new Vector3(0, 0, 1) * 70 * Time.deltaTime);
        GravitationLevel4.transform.Rotate(new Vector3(0, 0, 1) * -65 * Time.deltaTime);
        GravitationLevel5.transform.Rotate(new Vector3(0, 0, 1) * 60 * Time.deltaTime);
        GravitationLevel6.transform.Rotate(new Vector3(0, 0, 1) * -53 * Time.deltaTime);
        GravitationLevel7.transform.Rotate(new Vector3(0, 0, 1) * 48 * Time.deltaTime);
        GravitationLevel8.transform.Rotate(new Vector3(0, 0, 1) * -43 * Time.deltaTime);
        GravitationLevel9.transform.Rotate(new Vector3(0, 0, 1) * 38 * Time.deltaTime);

    }
}
