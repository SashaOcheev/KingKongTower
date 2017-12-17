using UnityEngine;

namespace Scripts.Building
{
    public class BuildingController : MonoBehaviour
    {
        IHouse _house;
        IScore _score;

        #region MonoBehaviour members

        private void Start()
        {
            _house = GetComponent<House>();
            _house.CreateNextBlock();

            _score = FindObjectOfType<Score>();
        }

        private void Update()
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _house.CreateNextBlock();
                    _score.Height = _house.Height;
                }
            }
        }

        #endregion
    }
}
