using UnityEngine;
using System.Collections;
using Scripts.Building;

namespace Scripts.Shooting
{
    public class HorizontalMoveBehaviour : MonoBehaviour
    {
        [SerializeField]
        float RADIUS;

        [SerializeField]
        float MAX_SPEED;

        float Speed { get; set; }

        public bool IsEnd { get; set; }

        // Use this for initialization
        void Start()
        {
            var finalPosition = FindObjectOfType<House>().FinalPosition;

            transform.position = new Vector3(finalPosition.x + RADIUS, finalPosition.y, finalPosition.z);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Move(float shift)
        {
            
        }
    }
}