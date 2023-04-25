using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Update is called once per frame

    private void Start()
    {
        Destroy(this.gameObject, 3.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }
}
