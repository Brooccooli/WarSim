using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject bulletPrefab;

    // Only for test, delete later
    private Quaternion startQuaternion;
    
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
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.05f);
    }
    
    public void Rotate(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion goalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.05f);
    }
    
    void Start()
    {
        startQuaternion = transform.rotation;
    }
}
