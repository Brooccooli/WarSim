using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public bool Meele();

    public void Attack(int damage);

    public void Rotate(Quaternion goalRotation);
}
