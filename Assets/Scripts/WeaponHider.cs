using Photon.Pun;
using UnityEngine;

public class WeaponHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var _photonView = transform.root.GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
}
