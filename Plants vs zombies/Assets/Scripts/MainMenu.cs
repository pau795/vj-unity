using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int level;
    void Awake()
    {
        level = 0;
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Salir()
    {
        Application.Quit();
    }

    public void loadLevel(int l)
    {
        level = l;
        Jugar();
    }
}
