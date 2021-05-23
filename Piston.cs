using UnityEngine;

public class Piston : MonoBehaviour
{
    protected bool isOn = false;
    public float length = 10f;
    public Transform piston;
    protected float lerp = 0;
    protected Vector2 currPos;

    // Start is called before the first frame update
    void Start()
    {
        currPos = piston.position;
    }

    // Update is called once per frame
    void Update()
    {
        lerp += (0.1f * Time.deltaTime);
        
        if (isOn)
        {
            piston.position = Vector2.Lerp(currPos, new Vector2(piston.position.x + length, piston.position.y), Mathf.Clamp(lerp, 0f, 1f));
        }
        else
        {
            piston.position = Vector2.Lerp(currPos, new Vector2(piston.position.x - length, piston.position.y), Mathf.Clamp(lerp, 0f, 1f));
        }
        if (GetComponent<Grabbing>().Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                currPos = piston.position;
                isOn = !isOn;
                lerp = 0f;
            }
        }
    }

    private void OnMouseOver()
    {
        if (!GetComponent<Grabbing>().Pressed)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                currPos = piston.position;
                isOn = !isOn;
                lerp = 0f;
            }
        }
    }
}
