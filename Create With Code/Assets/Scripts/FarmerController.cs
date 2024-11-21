using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : PlayerController
{
    [SerializeField] private GameObject projectPrefab;
    private float xRange = 22.5f;
    // Update is called once per frame
    void Update()
    {
        Vector2 inputValue = gameInput.GetInputValueNormalised();

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else
        {
            Vector3 moveDir = new Vector3(inputValue.x, 0, 0);

            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z)) { 
            Instantiate(projectPrefab, transform.position, projectPrefab.transform.rotation);
        }
    }
}
