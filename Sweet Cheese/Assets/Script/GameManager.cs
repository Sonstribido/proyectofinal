using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad (gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
                  }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}

