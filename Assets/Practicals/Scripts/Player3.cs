using UnityEngine;

public class Player3 : MonoBehaviour
{
    public float _speed;
    [SerializeField]
    private GameObject projectile;
    public float canFire = -1f;
    public float fireRate = 0.5f;

    public int ammoCount = 3;
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * _speed);
    }

    public void Fire()
    {
        if(Time.time > canFire && ammoCount > 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            canFire = Time.time + fireRate;
            ammoCount--;
        }

    }
}
