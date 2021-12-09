using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BotV1 : MonoBehaviour
{
    [SerializeField] private List<GameObject> weaponPrefabs;
    private GameObject weapon;

    [SerializeField] private GameObject target;

    public int Health = 10;
    private int damage = 1;

    private enum State
    {
        Walk,
        Attack,
        Wait
    }

    private State[] allStates = new[] {State.Walk, State.Attack, State.Wait};
    private State state = State.Wait;

    void Start()
    {
        int rand = Random.Range(0, weaponPrefabs.Count);
        weapon = Instantiate(weaponPrefabs[rand], transform);
        GameEvents.beat.onBeat += Action;
    }

    public void Action()
    {
        setState();
        
        switch (state)
        {
            case State.Attack:
                Attack();
                break;
            case State.Walk:
                Move();
                break;
            case State.Wait:
                break;
            default:
                Debug.LogError("State is wrong, state: " + state);
                break;
        }
    }

    private void Attack()
    {
        if (weapon.GetComponent<IWeapon>().Meele())
        {
            Vector3 dist = transform.position - target.transform.position;
            if (dist.magnitude > 1)
            {
                Move();
                return;
            }
        }
        weapon.GetComponent<IWeapon>().Attack(damage);
    }
    
    private void Move()
    {
        if (weapon.GetComponent<IWeapon>().Meele())
        {
            Vector3 dir =  target.transform.position - transform.position;
            dir = dir.normalized;
            transform.position += dir * 0.5f;
            return;
        }
        Vector3 randDir = new Vector3(Random.Range(-2, 3), Random.Range(-2, 3));
        transform.position += randDir * 0.1f;
    }

    private void setState()
    {
        int rand = Random.Range(0, 3);
        state = allStates[rand];
    }

    private void direction()
    {
        Vector3 goalDirection = (target.transform.position - transform.position).normalized;
        weapon.GetComponent<IWeapon>().Rotate(goalDirection);
    }
    
    void Update()
    {
        direction();
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.GetComponent<IWeapon>().Attack(damage);
        }
    }
}