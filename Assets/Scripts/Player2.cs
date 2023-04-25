using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2 : MonoBehaviour
{
    PlayerInputActions _input;
    MeshRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player2.Enable();
        _input.Player2.ChangeColor.performed += ChangeColor_performed;
    }

    private void ChangeColor_performed(InputAction.CallbackContext obj)
    {
        _renderer = GetComponent<MeshRenderer>();
        if (_renderer != null)
        {

            _renderer.material.color = Random.ColorHSV();
        }
     
    }

    private void Update()
    {
        Debug.Log("Axis Value: " + _input.Player2.Rotate.ReadValue<float>());

        var rotDirection = _input.Player2.Rotate.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * 30f * rotDirection);
    }

}
