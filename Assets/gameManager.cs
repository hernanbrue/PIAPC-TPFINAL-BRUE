using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    int vidasActivas;
    public GameObject enemigo;
    public int numeroEnemigos;
    Vector3 pos;

    void Start()
    {
        numeroEnemigos = 20;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(controller.vida);

        if(numeroEnemigos > 0){

            pos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            Instantiate(enemigo, pos, Quaternion.identity);
            numeroEnemigos--;
        }


        if (vidasActivas <= 0)
        {
            //JUNTÓ TODAS LAS MONEDAS (MONEDA = 2 VIDAS)
            Debug.Log("GANÓ");
        }

    }
}
