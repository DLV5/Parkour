using UnityEngine;

public class MaxHealthUpgrade : MonoBehaviour, IUpgrade
{
    [SerializeField] private int _amountOfHelathToAdd = 1;

    public void Upgrade(GameObject player)
    {
       PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.IncreaseMaxHealth(_amountOfHelathToAdd);
    }
}
