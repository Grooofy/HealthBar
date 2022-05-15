using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorChanger : MonoBehaviour
{
    private Image _fill;

    private void Awake() => _fill = GetComponent<Image>();

    public void SetColor(Color value) => _fill.color = value;
}
