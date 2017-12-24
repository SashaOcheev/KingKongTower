using UnityEngine;
using Scripts.Building.Pickers;

namespace Scripts.Building
{
    public class BlockPickerPosition : MonoBehaviour
    {
        [SerializeField]
        private float LOWER_LIMIT;

        [SerializeField]
        private float HIGHER_LIMIT;

        public float Calculate(float position)
        {
            return (HIGHER_LIMIT - LOWER_LIMIT) / PickerModel.GRADATION * position;
        }
    }
}