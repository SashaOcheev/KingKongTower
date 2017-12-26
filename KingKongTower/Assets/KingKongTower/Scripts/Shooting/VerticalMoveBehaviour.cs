using UnityEngine;
using System.Collections;
using Scripts.Building;

namespace Scripts.Shooting
{
    public class VerticalMoveBehaviour : MonoBehaviour
    {
        float MaxHeight { get; set; }

        [SerializeField]
        float SPEED;

        public bool IsEnd {
            get
            {
                return CurrentHeight >= MaxHeight;
            }
        }

        // Use this for initialization
        void Start()
        {
            var house = FindObjectOfType<House>();
            MaxHeight = house.FinalPosition.y;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsEnd)
            {
                return;
            }

            MoveUp();
        }

        void MoveUp()
        {
            transform.Translate(new Vector3(0f, SPEED, 0f));
        }

        float CurrentHeight
        {
            get
            {
                return transform.position.y;
            }
        }
    }
}