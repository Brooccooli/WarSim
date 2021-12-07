using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    public bool Meele()
    {
        return false;
    }

    public void Attack(int damage)
    {
        Instantiate(bulletPrefab, transform.position + (transform.right * 1), transform.rotation);
        transform.Rotate(new Vector3(0, 0, 90));
    }

    public void Rotate(Quaternion goalRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.1f);
    }

    // Only for test, delete later
    Quaternion right;
    
    void Start()
    {
        right = transform.rotation;
    }

    void Update()
    {
        Rotate(right);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(1);
        }
    }
}
