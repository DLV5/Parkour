using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private string _textToDisplay = "Press E to increase firerate for: ";

    [SerializeField] private int _baseCostOfUpgrade = 5;

    [SerializeField] private GameObject _upgrade;

    private int _costOfUpgrade;

    private bool _isInAShoop = false;

    private TMP_Text _shopText;

    private PlayerMoney _money;

    private GameObject _playerToUpgade;

    private void Start()
    {
        _shopText = GameObject.Find("Shop Text").GetComponent<TMP_Text>();

        _costOfUpgrade = _baseCostOfUpgrade;
    }

    void Update()
    {
        if (_isInAShoop)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Buy();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        _playerToUpgade = other.gameObject;

        _money = other.GetComponent<PlayerMoney>();
        _shopText.text = _textToDisplay + _costOfUpgrade + "$";
        _isInAShoop = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        _shopText.text = "";
        _isInAShoop = false;
    }

    private void Buy()
    {
        if(_money.RemoveMoney(_costOfUpgrade))
        {
            _costOfUpgrade += _baseCostOfUpgrade;
            _upgrade.GetComponent<IUpgrade>().Upgrade(_playerToUpgade);
        }
    }
}
