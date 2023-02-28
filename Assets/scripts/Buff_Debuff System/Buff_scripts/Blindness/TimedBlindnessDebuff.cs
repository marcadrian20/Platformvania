using ScriptableObjects;
using UnityEngine;

public class TimedBlindnessDebuff : TimedBuff
{
    private GameObject BlindnessUI;
    private readonly EffectsUI effectsUI;
    private GameObject UIObject;

    private readonly PlayerMovement _movementComponent;

    public TimedBlindnessDebuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        UIObject = GameObject.Find("/UI/StatsUI/Buffs_DebuffsUI");
        effectsUI = UIObject.GetComponent<EffectsUI>();
        BlindnessUI = GameObject.Find("UI/StatsUI/BlindUI");
    }

    protected override void ApplyEffect()
    {
        effectsUI.ActivateBuff(3);
        BlindnessUI.SetActive(true);
    }

    public override void End()
    {
        effectsUI.DeactivateBuff(3);
        BlindnessUI.SetActive(false);
        EffectStacks = 0;
    }
}