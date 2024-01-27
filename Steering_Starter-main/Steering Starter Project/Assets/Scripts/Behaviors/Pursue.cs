using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek
{
    float maxPrediction;
    public override SteeringOutput getSteering()
    {
        SteeringOutput steeringOutput = new SteeringOutput();
        Vector3 direction = target.transform.position - character.transform.position;
        float distance = direction.magnitude;
        float speed = character.linearVelocity.magnitude;
        float prediction =0;
        if(speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }
        target.transform.position += target.transform.forward * prediction;
        steeringOutput.linear = direction;
        steeringOutput.angular = 0;
        return steeringOutput;
    }
}
