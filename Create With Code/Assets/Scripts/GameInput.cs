using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    public Vector2 GetInputValueNormalised()
    {
        Vector2 inputValue = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputValue = inputValue.normalized;
        return inputValue;
    }
}
