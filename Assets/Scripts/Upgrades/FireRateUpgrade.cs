using UnityEngine;

public class FireRateUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private float _upgradeStep = .49f;

    public void Upgrade(GameObject player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.DelayBetweenShoots -= weapon.DelayBetweenShoots * .2f;
    }
}
