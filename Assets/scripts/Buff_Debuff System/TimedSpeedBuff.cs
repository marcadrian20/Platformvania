using ScriptableObjects;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly PlayerMovement _movementComponent;

    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        _movementComponent = obj.GetComponent<PlayerMovement>();
    }
    
    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        SpeedBuff speedBuff = (SpeedBuff)Buff;
        _movementComponent.runSpeed += speedBuff.SpeedIncrease;
    }

    public override void End()
    {
        //Revert speed increase
        SpeedBuff speedBuff = (SpeedBuff)Buff;
        _movementComponent.runSpeed -= speedBuff.SpeedIncrease * EffectStacks;
        EffectStacks = 0;
    }
}