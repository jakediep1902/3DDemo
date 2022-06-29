using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController playerController;
    public Transform lookTarget;
    //public GameObject lookTarget;
    public Vector3 posStart;
    public Vector3 posPlayer;
    public Vector3 camDistance;
    void Start()
    {
        playerController = PlayerController.Instance;              
        camDistance = lookTarget.position - transform.position;
    }  
    private void LateUpdate()
    {
        FollowTarget();     
    }
    public void FollowTarget()
    {
        transform.position = lookTarget.position - lookTarget.rotation * camDistance;
        transform.LookAt(lookTarget);
    }
   
}
