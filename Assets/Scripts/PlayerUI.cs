using System.Linq;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
     [field : SerializeField] public PlayerHealthBar HealthBar { get; private set; }
     [field : SerializeField] public GameObject DeathScreen { get; private set; }

    private void Awake()
    {
        HealthBar = FindFirstObjectByType<PlayerHealthBar>();
        DeathScreen = GameObject.Find("Canvas").transform.Find("DeathScreen").gameObject;
    }
}
