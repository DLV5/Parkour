using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject agentTarget;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent?.SetDestination(agentTarget.transform.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damaged");
        if(health < 0)
        {
            Debug.Log("Destroyed");

            Destroy(gameObject);
        }
    }

}
