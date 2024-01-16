using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 3;
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
