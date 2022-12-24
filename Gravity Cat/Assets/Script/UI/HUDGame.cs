using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDGame : MonoBehaviour
{
   
    public TextMeshProUGUI textoQuesitos;
    public TextMeshProUGUI textoRat;
    public TextMeshProUGUI textoSpawn;
    public TextMeshProUGUI textoPause;
    public TextMeshProUGUI keyInfo;
    public static int cantQuesito = 0;
    public float splashTime = 4f;
    public static int spawnInfo = 1;
    public static bool gotTutorialKey = false;
    public static bool gotGreenKey = false;
    public static bool gotRoomKey = false;
    void Start()
    {
        
    }


    void Update()
    {   if (Time.timeScale == 0)
        {
            textoPause.gameObject.SetActive(true);
        } else
        {
        textoPause.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            SceneManager.LoadScene(0);

        };
        if (splashTime >= 0)
        {
            splashTime -= Time.deltaTime;
        } else if (splashTime <= 0)
        {
            splashTime = 4f;
        };
               
        if (splashTime <= 0 && gotTutorialKey == false)
        {
            keyInfo.gameObject.SetActive(true);
            textoRat.gameObject.SetActive(false);
            splashTime = 4f;
        };

        if (gotTutorialKey == true)
        {

            keyInfo.text = "Good, now the door, there are more keys";
            splashTime = 4f;           
            
        };
        

        if (gotGreenKey == true)
        {
            keyInfo.text = "A Green key! They are good for breaking odd colored walls!";
            keyInfo.gameObject.SetActive(true);
            splashTime -= Time.deltaTime;
            if (splashTime <= 0)
            {
                keyInfo.gameObject.SetActive(false);
            };
        };

        if (gotRoomKey == true)
        {
            keyInfo.text = "The room key! Rat must be hungry! I can already smell cheese";
            keyInfo.gameObject.SetActive(true);
            splashTime -= Time.deltaTime;
            if (splashTime <= 0)
            {
                keyInfo.gameObject.SetActive(false);
            };
        };







        textoQuesitos.text = "Quesitos = " + cantQuesito.ToString();
        textoSpawn.text = "Spawn: " + "Room " + spawnInfo.ToString();
        
    }
}
