using Photon.Pun;
using TMPro;

public class PlayerNickname : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public TMP_Text nickname;
    private void Awake()
    {
        if (photonView.IsMine)
        {
            transform.gameObject.SetActive(false); // hiding own nickname
        }
        nickname.text = photonView.Owner.NickName;
    }
}
