using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Quaternion startRotation;
    public bool Meele()
    {
        throw new System.NotImplementedException();
    }

    public void Attack(int damage)
    {
        // Todo: Add area check to see if close enough
        transform.Rotate(new Vector3(40, 0, 60));
    }

    public void Rotate(Quaternion goalRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, goalRotation, 0.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(startRotation);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(1);
        }
    }
}
