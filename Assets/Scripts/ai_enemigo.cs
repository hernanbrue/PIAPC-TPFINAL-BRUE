using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_enemigo : MonoBehaviour
{
    //VARIABLES
    //public Transform objetivo;
    GameObject jugador;
    private NavMeshAgent agente;
    Vector3 actualPos;
    Vector3 randPos;
    Vector3 startPos;
    public Material pasivo;
    public Material alerta;
    public Material tranca;



    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        startPos = gameObject.transform.position;


    }


    void Update()
    {

        jugador = GameObject.FindWithTag("Player");

        float distance = (gameObject.transform.position -  jugador.transform.position).magnitude;
        actualPos = gameObject.transform.position;

        
        if (distance <= 12)
        {
            agente.speed = 6f;
            gameObject.GetComponent<MeshRenderer>().material = alerta;
            agente.SetDestination(jugador.transform.position);
        }

        else
        {
            agente.speed = 4f;
            gameObject.GetComponent<MeshRenderer>().material = pasivo;

            if ((startPos - actualPos).magnitude < 10)
            {
                agente.SetDestination(startPos);
            }

            if ((startPos - actualPos).magnitude >= 10)
            {
                randPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), gameObject.transform.position.z);
                startPos = randPos;
                agente.SetDestination(randPos);

            }

            else if((startPos - actualPos).magnitude < 2)
            {
                gameObject.GetComponent<MeshRenderer>().material = tranca;
            }


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }


        if (collision.collider.tag == "bomba")
        {
            Destroy(gameObject);
        }

    }

}

