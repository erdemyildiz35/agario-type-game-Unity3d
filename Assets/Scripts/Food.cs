using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
 

        
    }
    //Food Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {

            Destroy(this.gameObject, .01f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject, .01f);

        }
    }

}
