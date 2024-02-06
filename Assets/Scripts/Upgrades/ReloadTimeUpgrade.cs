using UnityEngine;

public class ReloadTimeUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private float _upgradeStep = 0.2f;
    public void Upgrade(GameObject player)
    {
        Weapon weapon = player.GetComponent<Weapon>();
        weapon.ReloadTime -= weapon.ReloadTime * _upgradeStep;
    }
}
