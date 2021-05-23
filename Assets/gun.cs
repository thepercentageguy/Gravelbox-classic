using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    protected ParticleSystem muzzleFlash;
    protected ParticleSystem bullet;
    protected AudioSource shoot;
    protected Grabbing grabscript;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = transform.GetChild(1).GetComponent<ParticleSystem>();
        bullet = transform.GetChild(0).GetComponent<ParticleSystem>();
        shoot = transform.GetChild(2).GetComponent<AudioSource>();
        grabscript = GetComponent<Grabbing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabscript.Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                muzzleFlash.Play();
                bullet.Play();
                shoot.Play();
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.right.x * -2, 2f), ForceMode2D.Impulse);
                transform.GetComponent<Rigidbody2D>().AddTorque(0.2f, ForceMode2D.Impulse);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 999999999999999f);
                if (hit.collider != null && hit.collider.gameObject.tag == "Prop")
                {
                    hit.collider.transform.GetComponent<Rigidbody2D>().AddForce(transform.right * force * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }
    }

    void OnMouseOver()
    {
        if (!grabscript.Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                muzzleFlash.Play();
                bullet.Play();
                shoot.Play();
                transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.right.x * 2, 2f), ForceMode2D.Impulse);
                transform.GetComponent<Rigidbody2D>().AddTorque(0.2f, ForceMode2D.Impulse);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 999999999999999f);
                if (hit.collider != null && hit.collider.gameObject.tag == "Prop")
                {
                    hit.collider.transform.GetComponent<Rigidbody2D>().AddForce(transform.right * (hit.collider.gameObject.GetComponent<Rigidbody2D>().mass * force) * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }
    }
}
