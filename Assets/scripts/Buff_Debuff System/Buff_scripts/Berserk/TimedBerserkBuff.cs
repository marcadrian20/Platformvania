using UnityEngine;
using ScriptableObjects;

public class TimedBerserkBuff : TimedBuff
{
    private readonly PlayerCombat playerCombat;
    private readonly PlayerHealth playerHealth;
    public TimedBerserkBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        //Getting MovementComponent, replace with your own implementation
        playerCombat = obj.GetComponent<PlayerCombat>();
        playerHealth = obj.GetComponent<PlayerHealth>();
    }

    protected override void ApplyEffect()
    {
        BerserkBuff berserkBuff = (BerserkBuff)Buff;
        int temp = berserkBuff.StatsIncrease;
        playerCombat.ultimateDamage += berserkBuff.StatsIncrease;
        playerCombat.attackDamage += berserkBuff.StatsIncrease;
        playerCombat.attackRate += 1f;
        playerCombat.attackRange += 0.2f;
        if (playerHealth.currentHealth <= temp)
            temp = temp / 2;
        temp = temp - (2 * temp);
        playerHealth.AddHealth(temp);
    }

    public override void End()
    {
        BerserkBuff berserkBuff = (BerserkBuff)Buff;
        playerCombat.ultimateDamage -= berserkBuff.StatsIncrease * EffectStacks;
        playerCombat.attackDamage -= berserkBuff.StatsIncrease * EffectStacks;
        playerCombat.attackRange -= 0.2f;
        playerCombat.attackRate -= 1f;
        EffectStacks = 0;
    }
}