using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Debuffs/BlindnessDebuff")]
    public class BlindnessDebuff : ScriptableBuff
    {
        public override TimedBuff InitializeBuff(GameObject obj)
        {
            return new TimedBlindnessDebuff(this, obj);
        }
    }
}