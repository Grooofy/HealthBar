using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HUD : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    
    private Slider _slider;
    private Coroutine _coroutine;
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _colorChanger = GetComponentInChildren<ColorChanger>();
    }

    public void SetMaxHeathValue(float maxHealth)
    {
        _slider.maxValue  = maxHealth;
        _slider.value = _slider.maxValue;
        _colorChanger.SetColor(_gradient.Evaluate(1f));
    }

    public void AddHeathValue(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(FadeHeath(health));
    }

    public void ReduceHeathValue(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeHeath(health));
    }

    private IEnumerator FadeHeath(float healthValue)
    {
        float speed = 5f;
        float step = speed * Time.deltaTime;
        
        while (_slider.value != healthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, healthValue, step);
            _colorChanger.SetColor(_gradient.Evaluate(_slider.normalizedValue));
            yield return null;
        }
    }
}
