using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    public event Action OnDamaged;

    [SerializeField] private int _health = 3;
    [SerializeField] private int _moneyValue = 5;

    private GameObject[] _players;

    private NavMeshAgent _agent;
    private GameObject _agentTarget;

    private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        _agent = transform.parent.GetComponent<NavMeshAgent>();
        _players = GameObject.FindGameObjectsWithTag("Player");        
    }

    private void Update()
    {
        if (_players.Length != 0)
        {
            _agentTarget = _players.OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).FirstOrDefault();
        }
        _agent?.SetDestination(_agentTarget.transform.position);
    }

    public void TakeDamage(int damage)
    {
        _playerMoney = _agentTarget.GetComponent<PlayerMoney>();

        _health -= damage;

        OnDamaged?.Invoke();

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        _playerMoney.AddMoney(_moneyValue);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided");
        if (collider.transform.tag != "Enemy" )
        {
            IDamagable damagable = collider.gameObject.GetComponent<IDamagable>();
            if(damagable != null )
            {
                damagable.TakeDamage(1);
            }
        }
    }
}
