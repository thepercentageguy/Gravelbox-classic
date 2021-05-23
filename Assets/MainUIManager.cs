using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using GB;
public class MainUIManager : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MapsPanel;
    protected bool isMaps = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMaps)
        {
            MainPanel.SetActive(false);
            MapsPanel.SetActive(true);
        }
        else
        {
            MainPanel.SetActive(true);
            MapsPanel.SetActive(false);
        }
    }

    public void OnMapSelect()
    {
        isMaps = true;
    }
    public void OnBackSelect()
    {
        isMaps = false;
    }
    public void SelDefault()
    {
        SceneManager.LoadScene("Default");
    }
    public void SelPlinko()
    {
        SceneManager.LoadScene("Plinko");
    }
    public void SelHuge()
    {
        SceneManager.LoadScene("Huge");
    }
    public void SelWater()
    {
        SceneManager.LoadScene("Water");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void onSettingsSelect()
    {

    }
}
