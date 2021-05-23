using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmable : MonoBehaviour
{
    public HingeJoint2D Joint;
    public Vector3 MaxForce1 = new Vector3(10.0f, 10.0f, 10.0f);
    public Vector3 MaxForce2 = new Vector3(20.0f, 20.0f, 20.0f);
    public Vector3 forceApplied;


    // Update is called once per frame
    void Update()
    {
        if(forceApplied.x > MaxForce1.x || forceApplied.y > MaxForce1.y || forceApplied.z > MaxForce1.z)
        {
            BreakJoint(Joint);
        }
        if (forceApplied.x > MaxForce2.x || forceApplied.y > MaxForce2.y || forceApplied.z > MaxForce2.z)
        {
            BreakLimb(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Vector3 collisionForce = col.impulse / Time.fixedDeltaTime;
        forceApplied = collisionForce;
    }



    public string BreakJoint(HingeJoint2D joint)
    {
        Destroy(joint);
        return $"{joint} Destroyed!";
    }
    public string BreakLimb(GameObject limb)
    {
        Destroy(limb);
        return $"{limb} Destroyed!";
    }
    
}
