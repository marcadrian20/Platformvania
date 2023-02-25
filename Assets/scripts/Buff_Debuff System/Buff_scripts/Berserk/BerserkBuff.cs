using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/BerserkBuff")]
    public class BerserkBuff : ScriptableBuff
    {
        public int StatsIncrease = 30;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new TimedBerserkBuff(this, obj);
        }
        
    }
}