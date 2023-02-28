using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/StrengthBuff")]
    public class StrengthBuff : ScriptableBuff
    {
        public int StrengthIncrease = 30;
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new TimedStrengthBuff(this, obj);
        }
    }
}