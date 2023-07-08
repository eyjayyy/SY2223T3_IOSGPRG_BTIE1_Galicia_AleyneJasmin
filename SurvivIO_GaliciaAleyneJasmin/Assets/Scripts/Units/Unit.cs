using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public float _speed;

    [SerializeField] private string _name;
    [SerializeField] private Health _health;
    [SerializeField] private Gun _gun;

    public virtual void Initialize(string name, int maxHealth, float speed)
    {
        _name = name;

        _health = gameObject.GetComponent<Health>();
        _health.MaxHealth = maxHealth;
        _health.Initialize();

        _speed = speed;

        gameObject.name = name;
        Debug.Log($"{_name} has been spawned");
    }

    public void Shoot()
    {
        Debug.Log($"{_name} is shooting");

        if (_gun != null)
        {
            _gun.Shoot();
        }
    }

    private void Reload()
    {
        Debug.Log($"{_name} is reloading");

        if (_gun != null)
        {
            _gun.Reload();
        }
    }
}
