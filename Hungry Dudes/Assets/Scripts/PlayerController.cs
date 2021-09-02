using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f, zMaxRange = 14.0f, zMinRange = 0.0f;

    

    public GameObject foodPrefab;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < - xRange)
        {
            transform.position = new Vector3( - xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zMinRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMinRange);
        }
        if (transform.position.z > zMaxRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }
    }
}
