using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public bool Pressed = false;
    Rigidbody2D rb;
    public GameObject cube;
    public GameObject lcube;
    public float ForceMultiplier = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Pressed = true;
    }
    private void OnMouseUp()
    {
        Pressed = false;
    }

    void Update()
    {
        if (Pressed) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.velocity = ForceMultiplier * (mousePos - new Vector2(cube.transform.position.x, cube.transform.position.y));
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl)) {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x + 0.1f, cube.transform.localScale.y + 0.1f, cube.transform.localScale.z);
                }
                else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y + 0.1f, cube.transform.localScale.z);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x + 0.1f, cube.transform.localScale.y, cube.transform.localScale.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x - 0.1f, cube.transform.localScale.y - 0.1f, cube.transform.localScale.z);
                }
                else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, cube.transform.localScale.y - 0.1f, cube.transform.localScale.z);
                }
                else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
                {
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x - 0.1f, cube.transform.localScale.y, cube.transform.localScale.z);
                }
            }
            if (Input.GetKey(KeyCode.C))
            {
                cube.transform.GetComponent<Rigidbody2D>().freezeRotation = true;
                cube.transform.rotation *= Quaternion.Euler(0f, 0f, 1 * 100f * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.V))
            {
                cube.transform.GetComponent<Rigidbody2D>().freezeRotation = true;
                cube.transform.rotation *= Quaternion.Euler(0f, 0f, -1 * 100f * Time.fixedDeltaTime);
            }
        }
        else
        {
            cube.transform.GetComponent<Rigidbody2D>().freezeRotation = false;
        }
        
    }
    void OnMouseOver()
        {
            if(Input.GetMouseButtonDown(1)) {
            Destroy(this.gameObject);
        }
    }
}