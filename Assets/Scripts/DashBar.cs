using UnityEngine;

public class DashBar : BarBase
{
    [SerializeField] PlayerDash playerDash;

    float target;

    protected override void Update()
    {
        base.Update();

        target = playerDash.timeBeforeDash / playerDash.maxTimeBeforeDash;

        BarFiller(target);
        ColorChanger(target, Color.grey, Color.blue);
    }
}