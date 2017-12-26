using UnityEngine;

namespace Scripts.Building
{
    public interface IHouse
    {
        void PutBlock();
        bool IsEnd { get; }
        bool IsPutted { get; }
        int Height { get; }

        Vector3 FinalPosition { get; }
    }
}