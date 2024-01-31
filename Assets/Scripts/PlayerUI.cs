using System.Linq;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerHealthBar HealthBar { get; private set; }
    public GameObject DeathScreen { get; private set; }

    private void Awake()
    {
        HealthBar = FindFirstObjectByType<PlayerHealthBar>();
        DeathScreen = GameObject.Find("Canvas").transform.Find("DeathScreen").gameObject;
    }
}
