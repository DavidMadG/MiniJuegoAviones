using UnityEngine;

public class Tierra : MonoBehaviour
{

    [SerializeField]

    private GameObject explosiones;

    private int ValorRR;

    private int i;
    [SerializeField]
    private GameObject sonidoExplosion;

    [SerializeField]
    private GameObject acumulador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ValorRR = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OcultarExplosion()
    {
        for (i=0;i<explosiones.gameObject.transform.childCount; i++)
        {
            explosiones.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        sonidoExplosion.gameObject.GetComponent<AudioSource>().Play();
        explosiones.gameObject.transform.GetChild(ValorRR).gameObject.transform.position = other.gameObject.transform.position;
        explosiones.gameObject.transform.GetChild(ValorRR).gameObject.SetActive(true);
        Invoke("OcultarExplosion",0.3f);
        ValorRR++;
        if(ValorRR >= explosiones.gameObject.transform.childCount)
        {
            ValorRR = 0;
        }

        Destroy(other.gameObject);
        Destroy(this.gameObject);
        acumulador.gameObject.GetComponent<UIController>().MostrarPanelDerrota();
       
    }
}
