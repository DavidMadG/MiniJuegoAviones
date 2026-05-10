using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField]
    
    private FloatingJoystick fj;

    [SerializeField]

    private float velocidad;

    [SerializeField]

    private GameObject explosiones;

    [SerializeField]

    private GameObject misilesPlayer;

    private int ValorRR;

    private int i;

    private int valorRRMisil;

    [SerializeField]

    private GameObject[] sonidos;

    [SerializeField]
    private GameObject acumulador;


    private float VelocidadDisparo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VelocidadDisparo = 1.0f;
        valorRRMisil = 0;
        ValorRR = 0;
        //InvokeRepeating("Disparar",0.0f,1.0f);
        StartCoroutine(DispararMisil());
    }

    IEnumerator DispararMisil()
    {
        while(true){
        yield return new WaitForSeconds(VelocidadDisparo);
        VelocidadDisparo = VelocidadDisparo - 0.005f;
        if(VelocidadDisparo < 0.3f)
            {
                VelocidadDisparo = 0.3f;
            }
            Disparar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(fj.Horizontal * Time.deltaTime*velocidad, fj.Vertical* Time.deltaTime*velocidad, 0.0f);
    }

    private void Disparar()
    {
        sonidos[1].gameObject.GetComponent<AudioSource>().Play();
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.transform.position = this.gameObject.transform.position;
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.0f,10f);
        valorRRMisil++;
        if(valorRRMisil >= misilesPlayer.gameObject.transform.childCount)
        {
            valorRRMisil = 0;
        }
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
        if(other.gameObject.tag !="MisilPlayer"){
        sonidos[0].gameObject.GetComponent<AudioSource>().Play();
        explosiones.gameObject.transform.GetChild(ValorRR).gameObject.transform.position = this.gameObject.transform.position;
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
}
