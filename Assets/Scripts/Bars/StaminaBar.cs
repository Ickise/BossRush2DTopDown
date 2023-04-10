using UnityEngine;

public class StaminaBar : BarBase
{
    [SerializeField] PlayerSprint playerSprint;

    float target;
    
    protected override void Update()
    {
        base.Update();
        
        target = playerSprint.sprintTime / playerSprint.maxSprintTime;

        BarFiller(target);
        ColorChanger(target, Color.grey, Color.blue);
    }
}
