using UnityEngine;

public class HealUpgrade : MonoBehaviour, IUpgrade
{
    public void Upgrade(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(-1);
    }
}
