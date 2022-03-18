using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMove : MonoBehaviour
{

    [SerializeField] private GameObject pointParticle;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 150));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(pointParticle, gameObject.transform.position,gameObject.transform.rotation);
          

        }
    }
}
