using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HUDGame : MonoBehaviour
{
 
    public TextMeshProUGUI textoQuesitos;
    public TextMeshProUGUI textoRat;
    public TextMeshProUGUI textoSpawn;
    public static int cantQuesito = 0;
    public float splashTime = 4f;
    public static int spawnInfo = 1;
    void Start()
    {
        
    }
    void Update()
    {
        
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
