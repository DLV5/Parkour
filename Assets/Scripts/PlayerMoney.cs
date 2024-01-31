using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int Money { get; private set; }

    private TMP_Text _moneyUI;

    private void Start()
    {
        _moneyUI = GameObject.Find("MoneyText").GetComponent<TMP_Text>();
    }

    public void AddMoney(int money)
    {
        Money += money;
        UpdateText();
    }

    public bool RemoveMoney(int money)
    {
        if(Money - money < 0)
        {
            return false;
        }

        Money -= money;
        UpdateText();

        return true;
    }

    private void UpdateText()
    {
        _moneyUI.text = Money.ToString();
    }
}
