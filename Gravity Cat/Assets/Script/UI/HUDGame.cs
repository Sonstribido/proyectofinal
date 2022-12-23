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
    public static int cantQuesito = 0;
    public float splashTime = 4f;
    public static int spawnInfo = 1;
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

        }

        if (splashTime <= 0)
        {
            textoRat.gameObject.SetActive(false);
        } else
        {
            splashTime -= Time.deltaTime;
        }
        textoQuesitos.text = "Quesitos = " + cantQuesito.ToString();
        textoSpawn.text = "Spawn: " + "Room " + spawnInfo.ToString();
    }
}
