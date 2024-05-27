using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Controller character = other.gameObject.GetComponent<Controller>();
        if (other.gameObject.name == "Character")
        {
            character.Respawn();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
