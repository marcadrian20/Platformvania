using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
    public class SpeedBuff : ScriptableBuff
    {
        public float SpeedIncrease = 60f;

        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new TimedSpeedBuff(this, obj);
        }
    }
}