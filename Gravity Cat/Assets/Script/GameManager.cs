using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dontDestoyOnLoad;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {

            SceneManager.LoadScene(1);
            SceneManager.UnloadSceneAsync(0);
            Debug.Log("Nueva escena"); 
        } 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            SceneManager.UnloadSceneAsync(1);
            Debug.Log("Nueva escena");
        };


    }
}

