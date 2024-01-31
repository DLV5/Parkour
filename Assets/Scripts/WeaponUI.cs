using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [field : SerializeField] public Camera PlayerCamera {  get; private set; }


    [SerializeField] private Animator animator;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private GameObject _impactEffect;

    [SerializeField] private CinemachineShake _cameraShaker;

    private TMP_Text _ammoText;
   
    private Weapon _weapon;

    private void Start()
    {
        _ammoText = GameObject.Find("Ammo").GetComponent<TMP_Text>();

        _weapon = GetComponent<Weapon>();

        UpdateAmmoText();

        _weapon.OnReloadEnded += UpdateAmmoText;
    }

    public void PlayShootEffects(RaycastHit hit)
    {
        UpdateAmmoText();

        animator.SetTrigger("OnShoot");
        _particleSystem.Play();
        _cameraShaker.ShakeCamera(.6f, .1f);

        var effect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 2f);
    }

    private void UpdateAmmoText()
    {
        _ammoText.text = $"{_weapon.CurrentAmmo}/{_weapon.MaxAmmo}";
    }
}
