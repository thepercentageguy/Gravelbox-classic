using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject Cube;
    public GameObject Circle;
    public GameObject Ragdoll;
    public GameObject Light;
    public GameObject PosRag;
    public GameObject Radio;
    public GameObject Rotor;
    public GameObject Bomb;
    public GameObject AcidDroid;
    public GameObject KCube;
    public GameObject Thruster;
    public GameObject Gun;
    public GameObject Gravelbox;
    public Slider timeScaleSlider;
    public TMPro.TMP_Text timescaleText;
    public int CurrentSpawner = 1;
    public Camera Cam;
    Vector3 _mousePositionInWorld;
    public TMPro.TMP_Text spawnerText;    
    [Header("Deleting")]
    public Grabbing grabScript;
    protected bool menuOpen = false;

    public static SpawnManager Instance;

    public void timeReset()
    {
        timeScaleSlider.value = 1.0f;
    }
    public void cubeSelect()
    {
        CurrentSpawner = 1;
    }
    public void circleSelect()
    {
        CurrentSpawner = 2;
    }
    public void ragSelect() {
        CurrentSpawner = 3;
    }
    public void lightSelect()
    {
        CurrentSpawner = 4;
    }
    public void posragSelect()
    {
        CurrentSpawner = 5;
    }
    public void radioSelect()
    {
        CurrentSpawner = 6;
    }
    public void rotorSelect()
    {
        CurrentSpawner = 7;
    }
    public void bombSelect()
    {
        CurrentSpawner = 8;
    }
    public void aciddroidSelect()
    {
        CurrentSpawner = 9;
    }
    public void KCubeSelect()
    {
        CurrentSpawner = 10;
    }
    public void ThrusterSelect()
    {
        CurrentSpawner = 11;
    }
    public void GunSelect()
    {
        CurrentSpawner = 12;
    }
    public void GbSelect()
    {
        CurrentSpawner = 13;
    }
    public void DestroyAllOther(){
        GameObject[] others = GameObject.FindGameObjectsWithTag("Prop"); //Get array of 
        //all possible objects with a given tag.
        foreach (GameObject go in others){ //Get all of those objects so we can check them..
            //As long as the gameObject we're checking isn't ours..
            if(go != gameObject){ //gameObject refers to the gameObject this script is attached to.
                Destroy(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _mousePositionInWorld = Cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {

            spawnCurrent();
            
        }
        if (CurrentSpawner == 1)
        {
            spawnerText.text = "Cube";
        }
        if (CurrentSpawner == 2)
        {
            spawnerText.text = "Circle";
        }
        if (CurrentSpawner == 3)
        {
            spawnerText.text = "Ragdoll";
        }
        if (CurrentSpawner == 4)
        {
            spawnerText.text = "Light";
        }
        if (CurrentSpawner == 5)
        {
            spawnerText.text = "0-Gravity Ragdoll";
        }
        if (CurrentSpawner == 6)
        {
            spawnerText.text = "R̷̢̡̮̲̩̹̹̄̿͗̆̑͑͂̾͒̍̅̂̚a̴̧͎͔͙̺͍̮̲̗̖̲͓̻̓̓̔͆̎͂͗̇̀̓͊̏͐d̶̮̟̦̬͈̄̏̽͗̂̊͗̚į̷̢͎̗̭̭͍̗̥̯̻̤͆̊͊̉̌͛͊̉̒͌́͠o̶̞̝̍̾̇̄͝";
        }
        if (CurrentSpawner == 7)
        {
            spawnerText.text = "Rotor";
        }
        if (CurrentSpawner == 8)
        {
            spawnerText.text = "Explosive";
        }
        if (CurrentSpawner == 9)
        {
            spawnerText.text = "Aciddroid";
        }
        if (CurrentSpawner == 10)
        {
            spawnerText.text = "Kinematic Cube";
        }
        if (CurrentSpawner == 11)
        {
            spawnerText.text = "Thruster";
        }
        if (CurrentSpawner == 12)
        {
            spawnerText.text = "Gun";
        }
        if (CurrentSpawner == 13)
        {
            spawnerText.text = "Gravelbox :)";
        }
        Time.timeScale = timeScaleSlider.value;
        timescaleText.text = $"{timeScaleSlider.value}";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var mainUI = Object.FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in mainUI)
            {
                if (canvas.gameObject.tag == "MainUI")
                {
                    if (canvas.transform.GetChild(5) != null && canvas.transform.GetChild(5).name == "ESCPANEL")
                    {
                        var escPanel = canvas.transform.GetChild(5);
                        if (menuOpen)
                        {
                            escPanel.gameObject.SetActive(false);
                            menuOpen = false;
                        }
                        else
                        {
                            escPanel.gameObject.SetActive(true);
                            menuOpen = true;
                        }
                    }
                }
            }
        }
    }
    void Awake()
    {
        Instance = this;
    }

    public void spawnCurrent()
    {
        if (CurrentSpawner == 1)
        {
            Instantiate(Cube, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Cube";
        }
        if (CurrentSpawner == 2)
        {
            Instantiate(Circle, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Circle";
        }
        if (CurrentSpawner == 3)
        {
            Instantiate(Ragdoll, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Ragdoll";
        }
        if (CurrentSpawner == 4)
        {
            Instantiate(Light, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, -5), Quaternion.identity);
            spawnerText.text = "Light";
        }
        if (CurrentSpawner == 5)
        {
            Instantiate(PosRag, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "0-Gravity Ragdoll";
        }
        if (CurrentSpawner == 6)
        {
            Instantiate(Radio, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "R̷̢̡̮̲̩̹̹̄̿͗̆̑͑͂̾͒̍̅̂̚a̴̧͎͔͙̺͍̮̲̗̖̲͓̻̓̓̔͆̎͂͗̇̀̓͊̏͐d̶̮̟̦̬͈̄̏̽͗̂̊͗̚į̷̢͎̗̭̭͍̗̥̯̻̤͆̊͊̉̌͛͊̉̒͌́͠o̶̞̝̍̾̇̄͝";
        }
        if (CurrentSpawner == 7)
        {
            Instantiate(Rotor, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Rotor";
        }
        if (CurrentSpawner == 8)
        {
            Instantiate(Bomb, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Explosive";
        }
        if (CurrentSpawner == 9)
        {
            Instantiate(AcidDroid, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Aciddroid";
        }
        if (CurrentSpawner == 10)
        {
            Instantiate(KCube, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Kinematic Cube";
        }
        if (CurrentSpawner == 11)
        {
            Instantiate(Thruster, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Thruster";
        }
        if (CurrentSpawner == 12)
        {
            Instantiate(Gun, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Gun";
        }
        if (CurrentSpawner == 13)
        {
            Instantiate(Gravelbox, new Vector3(_mousePositionInWorld.x, _mousePositionInWorld.y, 0), Quaternion.identity);
            spawnerText.text = "Gravelbox :)";
        }
    }

    public void confirmMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void denyMenu()
    {
        var mainUI = Object.FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in mainUI)
        {
            if (canvas.gameObject.tag == "MainUI")
            {
                if (canvas.transform.GetChild(5) != null && canvas.transform.GetChild(5).name == "ESCPANEL")
                {
                    var escPanel = canvas.transform.GetChild(5);
                    escPanel.gameObject.SetActive(false);
                    menuOpen = false;
                }
            }
        }
    }
}
