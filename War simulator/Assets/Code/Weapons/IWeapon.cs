using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public bool Meele();

    public void Attack(int damage);

    public void Rotate(Quaternion goalRotation);
    public void Rotate(Vector3 direction);
}
