using UnityEngine;

public class MisilPlayer : MonoBehaviour
{

    private int posDestruccion;
    private int incremento;
    [SerializeField]

    private GameObject acumulador;

    [SerializeField]

    private GameObject explosionesMisiles;

    [SerializeField]

    private GameObject[] sonidos;

    private int ValorRR;

    private int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ValorRR = 0;
        posDestruccion = 300;
        incremento = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OcultarExplosion()
    {
        for (i=0;i<explosionesMisiles.gameObject.transform.childCount; i++)
        {
            explosionesMisiles.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        acumulador.gameObject.GetComponent<UIController>().ActualizarPuntuacion(1);
        sonidos[0].gameObject.GetComponent<AudioSource>().Play();

        explosionesMisiles.gameObject.transform.GetChild(ValorRR).gameObject.transform.position = other.gameObject.transform.position;
        explosionesMisiles.gameObject.transform.GetChild(ValorRR).gameObject.SetActive(true);
        Invoke("OcultarExplosion",0.3f);
        ValorRR++;
        if(ValorRR >= explosionesMisiles.gameObject.transform.childCount)
        {
            ValorRR = 0;
        }
        other.gameObject.transform.position = new Vector2(posDestruccion, 300);
        this.gameObject.transform.position = new Vector2(posDestruccion, 400);
        posDestruccion = posDestruccion + incremento;

    }
}
