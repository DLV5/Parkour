using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    [SerializeField] private Animator animator;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private GameObject _impactEffect;

    [SerializeField] private CinemachineShake _cameraShaker;
    
    private void OnFire()
    {
        RaycastHit hit;
        Ray ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        animator.SetTrigger("OnShoot");
        _particleSystem.Play();
        _cameraShaker.ShakeCamera(.3f, .1f);
        if (Physics.Raycast(ray, out hit))
        {
            IDamagable damagable = hit.transform.GetComponent<IDamagable>();
            Debug.Log(damagable);
            if (damagable != null)
            {
                damagable.TakeDamage(1);
            }
        }

        var effect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 2f);
    }
}
