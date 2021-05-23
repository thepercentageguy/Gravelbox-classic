using System.Net.Security;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class toggleable : MonoBehaviour
{
    public AudioSource onSound;
    public AudioSource offSound;
    public AudioSource idleSound;
    public AudioClip onSound2;
    public AudioSource breakSound;
    [SerializeField]
    HingeJoint2D Hjoint;
    public FixedJoint2D FJoint;
    public JointMotor2D motor2D;
    public float maxSpeed = 1000.00f;
    protected float minSpeed = 0.00f;
    public SpriteRenderer switchColor;
    public bool isOn = false;
    protected bool isBroken = false;
    protected bool alreadyBroke = false;
    protected float _wait = -1f;

    public Rigidbody2D circle;
    public Collider2D stand;

    private void Start()
    {
        motor2D = Hjoint.motor;
        switchColor.color = Color.red;
    }

    void Update()
    {
        if (Hjoint != null && FJoint != null && !isBroken && !alreadyBroke)
        {
            motor2D = Hjoint.motor;
            if (_wait > 0.00f)
            {
                _wait -= Time.deltaTime;
            }
            if (!onSound.isPlaying && _wait <= 0.00f && _wait > -1.00f && !idleSound.isPlaying)
            {
                _wait = -1.00f;
                idleSound.Play();
            }
        }
        else
        {
            if (!alreadyBroke) {
                alreadyBroke = true;
                isOn = false;
                breakSound.Play();
                ForceRotorUpdate();
            }
        }
        if (isBroken && !alreadyBroke)
        {
            alreadyBroke = true;
            isOn = false;
            breakSound.Play();
            ForceRotorUpdate();
        }
    }

    public void rotorUpdate()
    {
        if (Hjoint != null && FJoint != null && !isBroken)
        {
            if (isOn)
            {
                switchColor.color = Color.green;
                _wait = onSound2.length - 0.1f;
                onSound.Play();
                JointMotor2D motor = Hjoint.motor;
                motor.motorSpeed = maxSpeed;
                Hjoint.motor = motor;
            }
            else if (!isOn)
            {
                switchColor.color = Color.red;
                idleSound.Stop();
                offSound.Play();
                JointMotor2D motor = Hjoint.motor;
                motor.motorSpeed = 0;
                Hjoint.motor = motor;
            }
        }
        else
        {
            isBroken = true;
        }
    }




    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Hjoint != null && FJoint != null && !isBroken)
            {
                if (!isOn)
                {
                    switchColor.color = Color.green;
                    _wait = onSound2.length - 0.1f;
                    onSound.Play();
                    isOn = true;
                    JointMotor2D motor = Hjoint.motor;
                    motor.motorSpeed = maxSpeed;
                    Hjoint.motor = motor;
                }
                else if (isOn)
                {
                    switchColor.color = Color.red;
                    idleSound.Stop();
                    offSound.Play();
                    isOn = false;
                    JointMotor2D motor = Hjoint.motor;
                    motor.motorSpeed = 0;
                    Hjoint.motor = motor;
                }
            }
            else
            {
                isBroken = true;
            }
        }
    }

    public void ForceRotorUpdate()
    {
        if (isOn)
        {
            circle.gravityScale = 1f;
        }
        else if (!isOn)
        {
            switchColor.color = Color.yellow;
            idleSound.Stop();
            offSound.Play();
            circle.gravityScale = 1f;
        }
    }
}
