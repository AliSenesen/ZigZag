using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{

    public static  VFX  singleton;

    [Header("VFX Controls")]
    public bool enableRotation;


    [Header("Collectable Variables")]
    public bool enableCollectionVFX;
    public GameObject collectionVFX;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAmount;


    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
    }

    private void Start()
    {
        enableCollectionVFX = false;
        enableRotation = false;
    }

    private void Update()
    {

      if(enableCollectionVFX && enableRotation)
        {
            Rotate();
        }
      
    }





    
    public void Rotate()
    {
       collectionVFX.transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.fixedDeltaTime * rotationSpeed, rotationAmount),
        Mathf.PingPong(Time.fixedDeltaTime * rotationSpeed, rotationAmount),
        Mathf.PingPong(Time.fixedDeltaTime * rotationSpeed, rotationAmount));

    }



}
