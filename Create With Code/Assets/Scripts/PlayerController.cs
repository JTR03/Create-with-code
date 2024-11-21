using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected GameInput gameInput;
    [SerializeField] protected float moveSpeed = 7.0f;


    void Update()
    {
        Vector2 inputValue = gameInput.GetInputValueNormalised();

        Vector3 moveDir = new Vector3(inputValue.x, 0, inputValue.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

       float rotationSpeed = 10f;

        transform.forward += Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }
}
