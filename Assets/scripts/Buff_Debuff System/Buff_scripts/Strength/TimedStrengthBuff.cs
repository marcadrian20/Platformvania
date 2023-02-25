using ScriptableObjects;
using UnityEngine;

public class TimedStrengthBuff : TimedBuff
{
    private readonly PlayerCombat playerCombat;

    public TimedStrengthBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        playerCombat = obj.GetComponent<PlayerCombat>();
    }

    protected override void ApplyEffect()
    {
        //Add speed increase to MovementComponent
        StrengthBuff strengthBuff = (StrengthBuff)Buff;
        playerCombat.ultimateDamage += strengthBuff.StrengthIncrease;
        playerCombat.attackDamage += strengthBuff.StrengthIncrease;
    }

    public override void End()
    {
        //Revert speed increase
        StrengthBuff strengthBuff = (StrengthBuff)Buff;
        playerCombat.ultimateDamage -= strengthBuff.StrengthIncrease * EffectStacks;
        playerCombat.attackDamage -= strengthBuff.StrengthIncrease * EffectStacks;
        EffectStacks = 0;
    }
}