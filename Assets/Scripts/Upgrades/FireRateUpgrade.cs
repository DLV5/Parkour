using UnityEngine;

public class FireRateUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private float _upgradeStep = .2f;

    public void Upgrade(GameObject player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.DelayBetweenShoots -= weapon.DelayBetweenShoots * _upgradeStep;
    }
}
