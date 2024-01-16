using UnityEngine;

public class WeaponFollowPlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerCamera;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _playerCamera.transform.rotation;
    }
}
