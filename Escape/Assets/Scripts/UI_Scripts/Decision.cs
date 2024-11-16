using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Decision_Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the collision is with Square A
        if (collision.gameObject.CompareTag("1"))
        {
            // Your code for when a collision with Square A occurs
        }
    }
}
