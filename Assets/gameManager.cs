using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    int vidasActivas;
    public GameObject enemigo;
    public int numeroEnemigos;
    public GameObject win;
    Vector3 pos;

    void Start()
    {
        numeroEnemigos = 20;
        win.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(controller.vida);

        if (numeroEnemigos > 0) {

            pos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            Instantiate(enemigo, pos, Quaternion.identity);
            numeroEnemigos--;
        }


        if (GameObject.FindGameObjectsWithTag("vida").Length <= 0)
        {
            win.SetActive(true);
            Time.timeScale = 0;
            

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
