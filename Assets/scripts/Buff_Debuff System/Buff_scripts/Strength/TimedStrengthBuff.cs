using ScriptableObjects;
using UnityEngine;

public class TimedStrengthBuff : TimedBuff
{
    private readonly PlayerCombat playerCombat;
    private readonly EffectsUI effectsUI;
    private GameObject UIObject;
    public TimedStrengthBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        playerCombat = obj.GetComponent<PlayerCombat>();
        UIObject = GameObject.Find("/UI/StatsUI/Buffs_DebuffsUI");
        effectsUI = UIObject.GetComponent<EffectsUI>();
    }

    protected override void ApplyEffect()
    {
        effectsUI.ActivateBuff(0);
        StrengthBuff strengthBuff = (StrengthBuff)Buff;
        playerCombat.ultimateDamage += strengthBuff.StrengthIncrease;
        playerCombat.attackDamage += strengthBuff.StrengthIncrease;
    }

    public override void End()
    {
        effectsUI.DeactivateBuff(0);
        StrengthBuff strengthBuff = (StrengthBuff)Buff;
        playerCombat.ultimateDamage -= strengthBuff.StrengthIncrease * EffectStacks;
        playerCombat.attackDamage -= strengthBuff.StrengthIncrease * EffectStacks;
        EffectStacks = 0;
    }
}