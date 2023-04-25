using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //get a reference in start to an instance of our Input Action class. 
    private PlayerInputActions _inputActions;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform pointToFireFrom;

    [SerializeField]
    private GameObject chargeUp;
    [SerializeField]
    private GameObject pop;
    [SerializeField]
    private GameObject projectile;

    void Start()
    {
        _inputActions = new PlayerInputActions(); // this initializes the instance. 
        _inputActions.Player.Enable();            //enable the correct action map.

        //register perform functions.
        _inputActions.Player.Fire.performed += Fire_performed;
        _inputActions.Player.Sprint.performed += Sprint_performed;
        _inputActions.Player.Sprint.canceled += Sprint_canceled;
        _inputActions.Player.SelfDestruct.performed += SelfDestruct_performed;
        _inputActions.Player.ChargeBeam.started += ChargeBeam_started;
        _inputActions.Player.ChargeBeam.performed += ChargeBeam_performed;
        _inputActions.Player.ChargeBeam.canceled += ChargeBeam_canceled;
    }

    private void ChargeBeam_canceled(InputAction.CallbackContext obj)
    {
        GameObject currentCharge = GameObject.Find("Charge(Clone)");
        Destroy(currentCharge);
    }

    private void ChargeBeam_performed(InputAction.CallbackContext obj)
    {
        GameObject currentCharge = GameObject.Find("Charge(Clone)");
        Destroy(currentCharge);
        GameObject popUp = Instantiate(pop, pointToFireFrom.position, Quaternion.identity);
        Instantiate(projectile, pointToFireFrom);
    }

    private void ChargeBeam_started(InputAction.CallbackContext obj)
    {
        GameObject charge = Instantiate(chargeUp, pointToFireFrom.position, Quaternion.identity);
        charge.transform.parent = pointToFireFrom.transform;
    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Fire!");
    }

    private void SelfDestruct_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Self Destruct!");
    }

    private void Sprint_performed(InputAction.CallbackContext obj)
    {
        _speed = _speed + 5;
    }

    private void Sprint_canceled(InputAction.CallbackContext obj)
    {
        _speed = _speed - 5;
    }

    private void Update()
    {
        // poll the input readings.
        var move = _inputActions.Player.Walk.ReadValue<Vector2>();
        transform.Translate(move * Time.deltaTime * _speed);
    }


}
