using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float delay = 1.2f, currentTime = 0;
    

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > currentTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            currentTime = Time.time + delay;
        }

    }

    
}
