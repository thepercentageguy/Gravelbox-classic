using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rotting : MonoBehaviour
{
    public HingeJoint2D targetJoint;
    public Color targetColor;
    protected Color currentColor;
    public ParticleSystem blood;

    public List<GameObject> targetLimbs;

    public List<AudioSource> sounds;

    public float timeToRot = 0.05f;

    protected float rottingTime;
    protected bool madeBlood;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetJoint == null)
        {
            rottingTime += (timeToRot * Time.deltaTime);
            makeBlood(blood);
        }
        if (targetJoint == null)
        {
            foreach(GameObject limb in targetLimbs)
            {
                var Color = limb.GetComponent<SpriteRenderer>().color;

                Color.r = Mathf.Lerp(currentColor.r, targetColor.r, rottingTime);
                Color.g = Mathf.Lerp(currentColor.g, targetColor.g, rottingTime);
                Color.b = Mathf.Lerp(currentColor.b, targetColor.b, rottingTime);
                limb.GetComponent<SpriteRenderer>().color = Color;
            }
        }
    }

    protected void makeBlood(ParticleSystem blood)
    {
        if (!madeBlood)
        {
            currentColor = transform.GetComponent<SpriteRenderer>().color;
            blood.Play();
            sounds[Random.Range(0, sounds.Count)].Play();
            madeBlood = true;
        }
    }
}
