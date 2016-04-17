using UnityEngine;
using System.Collections;

public class ceshiyongsudu : MonoBehaviour {
    //public GameObject wocao;
    private dandao wocao;
    public GameObject shot11;
    public float speed;
    private Rigidbody rb;
    private float angle;
    private dandao jimo2;
    private bosscontrol jimo1;
    private float s = 0;
    private float p = 0;
    private float time;
    private float st;
    private int wa = 0;
    void Start()
    {
        GameObject gameControllerObject1 = GameObject.FindGameObjectWithTag("aaa");
        if (gameControllerObject1 != null)
        {
            wocao = gameControllerObject1.GetComponent<dandao>();
        }
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("boss");
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script1");
        }
        if (gameControllerObject != null)
        {
            jimo1 = gameControllerObject.GetComponent<bosscontrol>();
        }
        if (jimo1 == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        //    if (GetComponent<Rigidbody>().position.x < -10)
        //  { speed = 0; }
        rb = GetComponent<Rigidbody>();
        time = wocao.jimo(); Debug.Log("time= " + time); Debug.Log("st" + st);  
        angle = 90;
        st = Time.time;
        // Debug.Log(time);GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    public float xiba()
    {
        return p;
    }

    void Update()
    {
        //Debug.Log(xiba());
        
        if (Time.time - st > time )
        {
           //Debug.Log("time" + time);
            GetComponent<Rigidbody>().velocity = transform.forward * 0;
        }

       /* if (wocao.jimo1() == 1)
        {
            // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
            // rb.velocity = movement * speed;Debug.Log("speed="+speed);
            // angle += 1;
            Vector3 movement = new Vector3(0, 0.0f, 11.15f);
            transform.RotateAround(gameController.aaxiba(), Vector3.up, 10 * Time.deltaTime);
        }
        if (jimo1.jimo1() == 2)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            Vector3 movement = new Vector3(0, 0.0f, 11.15f);
            transform.RotateAround(gameController.aaxiba(), Vector3.up, 10 * Time.deltaTime);
        }*/
        // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
        //rb.velocity = movement * speed;
        // angle += 1;
    }

}
