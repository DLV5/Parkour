using Photon.Pun;
using TMPro;

public class PlayerNickname : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public TMP_Text nickname;
    private void Awake()
    {
        try
        {
            if (photonView.IsMine)
            {
                transform.gameObject.SetActive(false); // hiding own nickname
            }
            nickname.text = photonView.Owner.NickName;
        }
        catch
        {
            UnityEngine.Debug.LogWarning("Player nicknames active only in a online mode");
        }
    }
}
