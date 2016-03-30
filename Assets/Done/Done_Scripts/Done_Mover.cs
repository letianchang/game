using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
   
	void Start ()
    {
       GetComponent<Rigidbody>().velocity = transform.forward * speed;
     //  Debug.Log("speed" +  GetComponent<Rigidbody>().rotation);
    //    if (GetComponent<Rigidbody>().position.x < -10)
      //  { speed = 0; }
    
        
	}
  
 
    void Update()
    {
        //Debug.Log(xiba());
   
      /* if (GetComponent<Rigidbody>().position.z < dis&&wa==0)
       { speed = 0; p = 0.3f;  } 
        if (speed == 0)
       {
          // speed = GetComponent<Rigidbody>().position.z - jimo1.jimo2(); 
            wa = 1;//Debug.Log(dis);
       }
        if (jimo1.jimo1() == 1&&wa==1)
        {
           // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
           // rb.velocity = movement * speed;Debug.Log("speed="+speed);
           // angle += 1;
            Vector3 movement = new Vector3(0, 0.0f, 11.15f);
            transform.RotateAround(movement, Vector3.up, 80 * Time.deltaTime);
        }
       // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
        //rb.velocity = movement * speed;
       // angle += 1;*/
    }
    
}
        