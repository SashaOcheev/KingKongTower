using UnityEngine;
using System.Collections;

namespace Scripts.Building.SetUpBlockPhases
{
    public interface IPhaseManager
    {
        void Start();
        bool IsEnd { get; }

        float FinalBringPosition { set; }
        float FinalPutPosition { set; }
    }
}
