using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        PhotonNetwork.Instantiate(prefab.name, transform.position, Quaternion.identity);
    }
}
