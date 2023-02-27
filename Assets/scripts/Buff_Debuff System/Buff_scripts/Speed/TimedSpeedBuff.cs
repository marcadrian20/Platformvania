using ScriptableObjects;
using UnityEngine;

public class TimedSpeedBuff : TimedBuff
{
    private readonly PlayerMovement _movementComponent;
    private readonly EffectsUI effectsUI;
    private GameObject UIObject;
    private int eff_str = 1;

    public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        _movementComponent = obj.GetComponent<PlayerMovement>();
        UIObject = GameObject.Find("/UI/StatsUI/Buffs_DebuffsUI");
        effectsUI = UIObject.GetComponent<EffectsUI>();

    }

    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        //add buff to ui list
        SpeedBuff speedBuff = (SpeedBuff)Buff;
        if (speedBuff.SpeedIncrease > 16)
            eff_str = 2;
        else eff_str = 1;
        effectsUI.ActivateBuff(eff_str);
        _movementComponent.runSpeed += speedBuff.SpeedIncrease;
    }

    public override void End()
    {
        //Revert speed increase
        //remove from ui
        effectsUI.DeactivateBuff(eff_str);
        SpeedBuff speedBuff = (SpeedBuff)Buff;
        _movementComponent.runSpeed -= speedBuff.SpeedIncrease * EffectStacks;
        EffectStacks = 0;
    }
}