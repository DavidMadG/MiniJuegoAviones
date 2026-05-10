using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public void CambiarEscena()
    {
        SceneManager.LoadScene("Juego");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("CambiarEscena", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
