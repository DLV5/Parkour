using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    [SerializeField] private Animator animator;
    
    private void OnFire()
    {
        RaycastHit hit;
        Ray ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        animator.SetTrigger("OnShoot");
        if(Physics.Raycast(ray, out hit))
        {
            IDamagable damagable = hit.transform.GetComponent<IDamagable>();
            Debug.Log(damagable);
            if (damagable != null)
            {
                damagable.TakeDamage(1);
            }
        }
    }
}
