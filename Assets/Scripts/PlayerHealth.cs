using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public event Action OnPlayerDied;
    public event Action OnPlayerRevived;

    private int _maxHealth = 5;

    private int _currentHealth;

    private bool _isInvincible = false;
    private float _invincibilityTime = 2f;

    private PlayerUI _playerUI;

    private void Awake()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    private void Start()
    {
        SetHealthToMax();
    }

    public void TakeDamage(int damage)
    {
        if (_isInvincible)
        {
            Debug.Log("Invincible");
            return;
        }

        _currentHealth -= damage;

        _playerUI.HealthBar.SetHealth(_currentHealth);

        StartCoroutine(StartInvincibility());
    
        if (_currentHealth == 0)
        {
            _playerUI.DeathScreen.SetActive(true);
            OnPlayerDied?.Invoke();
        }
    }

    public void Revive(Vector3 spawnPosition)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPosition;
        SetHealthToMax();

        OnPlayerRevived?.Invoke();
    }

    public void IncreaseMaxHealth(int amount)
    {
        _maxHealth += amount;
        _playerUI.HealthBar.SetMaxHealthLimit(_maxHealth);
    }

    private void SetHealthToMax()
    {
        _currentHealth = _maxHealth;
        _playerUI.HealthBar.SetMaxHealth(_currentHealth);
    }

    private IEnumerator StartInvincibility()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(_invincibilityTime);
        _isInvincible = false;
    }

}
