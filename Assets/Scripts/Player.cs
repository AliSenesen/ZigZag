using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

    private enum CurrentDirection
    {
        up,left
    }

    private CurrentDirection currentDirection;

    [SerializeField] private FollowPlayer _cameraControl;


    public bool isPlayerDead;

    [SerializeField] private GameObject deathParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDirection = CurrentDirection.left;
        isPlayerDead = false;
    }

   
    void Update()
    {
        if (!isPlayerDead)
        {
            ShootRay();
            if (Input.GetMouseButtonDown(0))
            {
                StopPlayer();
                ChangeDirection();
               
            }
        }
        else
        {
           
            return;
           
        }
        
    }

    private void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
           
            _cameraControl.enabled = false;
            Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }


    private void ChangeDirection()
    {
        MovePlayer();
        if (currentDirection == CurrentDirection.up)
        {
            currentDirection = CurrentDirection.left;
            
        }
        else if (currentDirection == CurrentDirection.left)
        {
            currentDirection = CurrentDirection.up;
        }

    }
    private void MovePlayer()
    {
        if (currentDirection == CurrentDirection.up)
        {
            SetMovementBall(Vector3.forward, ForceMode.VelocityChange);
        }

        else if (currentDirection == CurrentDirection.left)
        {
            SetMovementBall(Vector3.right, ForceMode.VelocityChange);
        }

    }

    private void SetMovementBall(Vector3 direction, ForceMode ForceMod)
    {
        rb.AddForce((direction).normalized * moveSpeed * Time.fixedDeltaTime, ForceMod);
    }

    private void StopPlayer()
    {
        rb.velocity = Vector3.zero;
    }

   
}
