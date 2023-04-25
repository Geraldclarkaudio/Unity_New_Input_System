using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Ball : MonoBehaviour
{
    PlayerInputActions _input;
    private bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Ball.Enable();
        _input.Ball.Jump.performed += Jump_performed;
        _input.Ball.Jump.canceled += Jump_canceled;
    }

    private void Jump_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("No Full Jump");
        Debug.Log(context.duration);
        var forceMod = context.duration;
        GetComponent<Rigidbody>().AddForce(Vector3.up * (25f * (float)forceMod), ForceMode.Impulse);

    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Full Jump");
        jumped = true;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 25f, ForceMode.Impulse);
    }

}
