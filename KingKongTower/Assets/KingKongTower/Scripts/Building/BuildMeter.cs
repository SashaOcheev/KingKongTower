using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public interface IPositionPercent
{
    float PositionPercent { set; }
}

 public class BuildMeter : MonoBehaviour, IPositionPercent
{
    public float maxHeight;    //the max height at which we will change direction
    public float minHeight;    //the min height at which we will change direction

    public float PositionPercent
    {
        set
        {
            float normalizedPositionPercentRatio = (value + 100) / 200;
            transform.position = new Vector3(minHeight + (maxHeight - minHeight) * normalizedPositionPercentRatio, transform.position.y,  transform.position.z );
        }
    }

    void Update()
    {
        PositionPercent = 100;
    }

}

