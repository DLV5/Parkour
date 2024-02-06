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

    private bool _isReloading = false;

    private float _delayTimer;

    [field: SerializeField] public int MaxAmmo { get; private set; } = 5;

    [field: SerializeField] public int CurrentAmmo { get; private set; }

    public float ReloadTime { get; set; } = 2f;

    public float ReloadTimer { get; private set; }

    public float DelayBetweenShoots { get; set; } = 1f;

    public int Damage { get; set; } = 1;

    private void Awake()
    {
        _weaponUI = GetComponent<WeaponUI>();
        _reloadBar = GameObject.Find("Reload Bar").GetComponent<ReloadBar>();

        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        _reloadBar.SetMaxReload(ReloadTime);
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

    public void IncreaseMaxAmmo(int amount)
    {
        MaxAmmo += amount;
        _weaponUI.UpdateAmmoText();
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
                damagable.TakeDamage(Damage);
            }
        }

        _weaponUI.PlayShootEffects(hit);
    }

    private void OnReload()
    {
        if (_isReloading)
            return;

        _isReloading = true;
        ReloadTimer = ReloadTime;      
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
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = MaxAmmo;
        _isReloading = false;
    }
}
