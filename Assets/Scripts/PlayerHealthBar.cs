using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Gradient _gradient;

    [SerializeField] private Image _fill;


    /// <summary>
    /// Setting max health and changing slider value
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;

        _fill.color = _gradient.Evaluate(1f);
    }

    /// <summary>
    /// Setting only max health without chaning slider value
    /// </summary>
    /// <param name="amount"></param>
    public void SetMaxHealthLimit(int amount)
    {
        _slider.maxValue = amount;
    }

    public void SetHealth(int health)
    {
        _slider.value = health;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
