using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public float force = 1f;
    protected float actualForce;
    public Rigidbody2D Rigidbody;
    protected bool isOn = false;

    private void Awake()
    {
        actualForce = force * force;
    }

    // Update is called once per frame
    void Update()
    {
        force = (transform.lossyScale.x + transform.lossyScale.y) * (actualForce * transform.GetComponent<Rigidbody2D>().mass);
        if (isOn)
        {
            Rigidbody.AddForce((transform.right * force) * Time.deltaTime, ForceMode2D.Force);
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
        else
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        }
        if (GetComponent<Grabbing>().Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isOn = !isOn;
            }
        }
    }

    private void OnMouseOver()
    {
        if (!GetComponent<Grabbing>().Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isOn = !isOn;
            }
        }
    }
}
