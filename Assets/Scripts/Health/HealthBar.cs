using UnityEngine.UI;
using UnityEngine;

public class HealthBar : BarBase
{
    [SerializeField] Life life;

    float target;

    protected override void Update()
    {
        base.Update();

        target = (float)life.currentHealth / (float)life.maxHealth;

        BarFiller(target);
        ColorChanger(target, Color.red, Color.green);
    }
}
