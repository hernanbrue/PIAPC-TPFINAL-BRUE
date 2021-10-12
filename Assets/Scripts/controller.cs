using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    float fuerza = 50f;
    float movX;
    float movY;
    public static float vida;
    public GameObject bomba;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vida = 10f;
    }

   
    void Update()
    {

        movX = Input.GetAxis("Horizontal") * fuerza * Time.deltaTime;
        movY = Input.GetAxis("Vertical") * fuerza * Time.deltaTime;
        
        rb.AddForce(Vector3.right * movX, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * movY, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(bomba, position, Quaternion.identity);
        }

        if(gameObject.transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemigo")
        {
            vida--;
        }

        if (collision.collider.tag == "vida")
        {
            vida = vida + 2;
            Destroy(collision.gameObject);
        }


    }
}
