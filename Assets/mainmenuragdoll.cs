using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class mainmenuragdoll : MonoBehaviour
{
    protected Transform ragdollTrans;
    void Start()
    {
        ragdollTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ragdollTrans.position.y <= -10)
        {
            Vector3 position = ragdollTrans.position;
            position.y = 10;
            ragdollTrans.position = position;
        }
    }
}
