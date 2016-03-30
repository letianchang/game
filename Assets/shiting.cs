using UnityEngine;
using System.Collections;

public class shiting : MonoBehaviour
{
    private GameController gameController;
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
        GameObject gameControllerObject1 = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject1 != null)
        {
            gameController = gameControllerObject1.GetComponent<GameController>();
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
        time = jimo1.jimo();
        angle = 90;
        st = Time.realtimeSinceStartup;
       // Debug.Log(time);
    }
    public float xiba()
    {
        return p;
    }

    void Update()
    {
        //Debug.Log(xiba());
        GetComponent<Rigidbody>().velocity = transform.forward * speed; 
        if (Time.realtimeSinceStartup -st>time  && wa == 0)
        { 
            //Debug.Log("st" + st); Debug.Log("time" + Time.realtimeSinceStartup); Debug.Log("time" + time);
            GetComponent<Rigidbody>().velocity = transform.forward * 0; }
       
        if (jimo1.jimo1() == 1 )
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
        }
        // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
        //rb.velocity = movement * speed;
        // angle += 1;
    }

}
