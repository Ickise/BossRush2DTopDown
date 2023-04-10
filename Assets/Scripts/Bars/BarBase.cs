using UnityEngine;
using UnityEngine.UI;

public class BarBase : MonoBehaviour
{
    [SerializeField] Image bar;

    float lerpSpeed;

    protected virtual void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;
    }

    protected void BarFiller(float target)
    {
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, target, lerpSpeed);
    }

    protected void ColorChanger(float time, Color emptyColor, Color fullColor)
    {
        Color barColor = Color.Lerp(emptyColor, fullColor, time);

        bar.color = barColor;
    }
}