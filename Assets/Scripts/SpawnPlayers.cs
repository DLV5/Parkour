using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject playerPrefab;
    //public GameObject cameraPrefab;
    private PhotonView _player;

    private static SpawnPlayers _instance;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        } else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, Quaternion.identity);
        _player = player.GetComponent<PhotonView>();
    }

    public void RevivePlayer()
    {
        if(_player.IsMine)
        {
            _player.GetComponent<PlayerHealth>().Revive(spawnPoint.transform.position);
        }
    }
}
