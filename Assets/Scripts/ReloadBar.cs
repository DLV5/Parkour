using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Gradient _gradient;

    [SerializeField] private Image _fill;

    public void SetMaxReload(float maxReloadTime)
    {
        _slider.maxValue = maxReloadTime;
        _slider.value = maxReloadTime;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetReload(float reloadTime)
    {
        _slider.value = reloadTime;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}