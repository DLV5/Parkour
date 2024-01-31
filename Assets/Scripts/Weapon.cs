using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponUI))]
public class Weapon : MonoBehaviour
{
    public event Action OnReloadEnded;

    private WeaponUI _weaponUI;

    private ReloadBar _reloadBar;

    private PlayerInput _playerInput;

    [Header("Ammo Settings")]
    [SerializeField] private float _reloadTime = 2f;

    private bool _isReloading = false;

    public float ReloadTimer { get; private set; }

    public float DelayBetweenShoots { get; private set; } = 1f;

    private float _delayTimer;

    [field: SerializeField] public int MaxAmmo { get; private set; } = 5;

    [field: SerializeField] public int CurrentAmmo { get; private set; }


    private void Awake()
    {
        _weaponUI = GetComponent<WeaponUI>();
        _reloadBar = GameObject.Find("Reload Bar").GetComponent<ReloadBar>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        _reloadBar.SetMaxReload(_reloadTime);
        _reloadBar.SetReload(0f);

        _delayTimer = DelayBetweenShoots;
    }

    private void Update()
    {
        if (_isReloading)
        {
            ReloadTimer -= Time.deltaTime;

            _reloadBar.SetReload(ReloadTimer);

            if (ReloadTimer < 0)
            {
                OnReloadFinished();
            }
        }

        if(_delayTimer < 0)
        {
            if (_playerInput.actions["Fire"].IsPressed())
            {
                OnFireHoldOrPressed();
                _delayTimer = DelayBetweenShoots;
            }
        }
        else
        {
            _delayTimer -= Time.deltaTime;
        }
    }

    private void OnFireHoldOrPressed()
    {
        if (_isReloading)
            return;

        CurrentAmmo--;

        if(CurrentAmmo == 0)
        {
            OnReload();
        }

        RaycastHit hit;
        Ray ray = _weaponUI.PlayerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Player")
            {
                return;
            }

            IDamagable damagable = hit.transform.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.TakeDamage(1);
            }
        }

        _weaponUI.PlayShootEffects(hit);
    }

    private void OnReload()
    {
        if (_isReloading)
            return;

        _isReloading = true;
        ReloadTimer = _reloadTime;      
    }

    private void OnReloadFinished()
    {
        CurrentAmmo = MaxAmmo;
        _isReloading = false;

        OnReloadEnded?.Invoke();
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        CurrentAmmo = MaxAmmo;
        _isReloading = false;
    }
}
