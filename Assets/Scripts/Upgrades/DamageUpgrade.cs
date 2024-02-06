using UnityEngine;

public class DamageUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private int _damageToAdd = 1;

    public void Upgrade(GameObject player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.Damage += _damageToAdd;
    }
}
