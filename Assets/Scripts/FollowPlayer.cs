using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float smoothSpeed = 0.3f;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

  
  private  void Update()
    {
        Vector3 targetPosition = player.transform.TransformPoint(new Vector3(0, 0, 0));
        targetPosition = new Vector3(targetPosition.x, 0, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity,smoothSpeed*Time.deltaTime);
    }
}
