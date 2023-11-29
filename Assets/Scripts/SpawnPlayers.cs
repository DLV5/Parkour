using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject playerPrefab;
    //public GameObject cameraPrefab;

    private void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.transform.position, Quaternion.identity);
        //GameObject camera = PhotonNetwork.Instantiate(cameraPrefab.name, Vector3.zero, Quaternion.identity);
        //camera.GetComponent<CinemachineVirtualCamera>().Follow = player.transform.GetChild(0);
    }
}
