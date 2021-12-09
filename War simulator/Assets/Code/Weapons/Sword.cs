using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Quaternion startRotation;
    public bool Meele()
    {
        return true;
    }

    public void Attack(int damage)
    {
        // Todo: Add area check to see if close enough
        transform.Rotate(new Vector3(0, 0, 60));
    }

    public void Rotate(Quaternion goalRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.01f);
    }
    
    public void Rotate(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion goalRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.05f);
    }

    void Start()
    {
        startRotation = transform.rotation;
    }
}
