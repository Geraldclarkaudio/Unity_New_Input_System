using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCube : MonoBehaviour
{
    PlayerInputActions _input;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.MobileCube.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        var move = _input.MobileCube.Move.ReadValue<Vector2>();
        transform.Translate(new Vector3(move.x, 0, 0) * Time.deltaTime * _speed); 
    }
}
