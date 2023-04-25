using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChargeBar : MonoBehaviour
{
    private PlayerInputActions _input;
    [SerializeField]
    private Slider slider;
    private bool isCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.ChargeBar.Enable();
        _input.ChargeBar.Charge.started += Charge_started;
        _input.ChargeBar.Charge.canceled += Charge_canceled;
    }

    private void Charge_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isCharging = true;
        StartCoroutine(ChargeUp());
    }

    private void Charge_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isCharging = false;
    }

    IEnumerator ChargeUp()
    {
        while(isCharging == true)
        {
            slider.value += (1.0f * Time.deltaTime)/5;
            yield return null;
        }
        while(slider.value > 0)
        {
            slider.value -= (1.0f * Time.deltaTime)/5;
            yield return null;
        }
    }
}
