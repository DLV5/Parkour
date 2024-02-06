using UnityEngine;

public class MaxAmmoUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private int _ammoToAdd = 1;
    public void Upgrade(GameObject player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.IncreaseMaxAmmo(_ammoToAdd);
    }
}
