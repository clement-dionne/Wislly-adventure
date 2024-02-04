using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    #region Unity Public
    public Transform PlayerTransform;
    public float CameraSpeed = 1f;
    #endregion

    #region Unity Private
    private Vector3 CameraPos;
    private Vector3 PlayerPos;
    #endregion

    public void Start()
    {
        CameraPos = transform.position - PlayerTransform.position;
    }

    public void Update()
    {
        PlayerPos = PlayerTransform.position + CameraPos;
        transform.position = Vector3.Lerp(transform.position, PlayerPos, CameraSpeed * Time.deltaTime);
    }
}
