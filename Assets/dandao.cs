using UnityEngine;
using System.Collections;

public class dandao : MonoBehaviour
{
    private Rigidbody rb;
    private GameController gameController;
    public GameObject shot;
    public GameObject shot11;
    public int shotSpawn;
  private float timerWuDi;
    public float fireRate;
    private float nextFire;
    private bool b;
    private float x=0;
    private float angle;
    private float angle2;
    private float angle1;
    private GameObject shot1;
    private Done_Mover lol;
    private int l = 0;
    private int q = 0;private float d =7.5f;
  /*  public float jimo()
    {
        return d;
    }
    public float jimo1()
    {
        if (q == 1)
        { return 1; }
        if (q == 2)
        { return 2; }
        else return 0;
    }*/
    private int shoot = 0;
    void Start()
    {
       
        timerWuDi = 5;
        b = true;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("Enemybullet");
        if (gameControllerObject != null)
        {
            lol = gameControllerObject.GetComponent<Done_Mover>();
        }
        
        if (lol == null)
        {
            Debug.Log("Cannot find 'jimo' script");
        }
//       
       
    }
    void Update()
    {
        rb = GetComponent<Rigidbody>(); //Debug.Log(lol.xiba());
      
      //  d = d + lol.xiba();
//if (Time.time > timerWuDi && Time.time - timerWuDi <= 5)
//{ 
        if (Time.time > nextFire)
        {

            
            nextFire = Time.time + fireRate;
            for (int i = 1; i <=shotSpawn; i++)
            {
                
                float k = 30;

           
                if (l<12*shotSpawn)
                {
                    if (q == 0) { 
                    if (l %shotSpawn == 0)  
                    { d = d -0.15f; Debug.Log("l="+l); } if (shot1 != null)
                  angle2=Mathf.Atan(shot11.GetComponent<Rigidbody>().position.x/(rb.position.z-shot11.GetComponent<Rigidbody>().position.z));
                   // Vector3 movement = new Vector3(Mathf.Sin(angle * Mathf.PI / 180), 0.0f, Mathf.Cos(angle * Mathf.PI / 180));
                    angle = angle2 * 180/Mathf.PI;
                    angle1=-45+k * (i-1)+angle;
                    shot1 = Instantiate(shot, rb.position, Quaternion.Euler(0, -45+k * (i-1)-angle, 0)) as GameObject;
                    //Debug.Log("angle " + angle); 
                    Debug.Log("angle2 " + angle2); Debug.Log("angle1 " + angle); shoot = 1;
                    l = l + 1;  timerWuDi = Time.realtimeSinceStartup;
                   // shot1.transform.position = new Vector3(1, 2, 3);//重新摆放预设 
               //  shot1.transform.Rotate(40, 0, 120);//预设的旋转角
       shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -5; }
                  //  Quaternion.Euler(0, k * i, 0)
                }
                
                if (l >=49*shotSpawn  )
                {
                   
                    if (Time.realtimeSinceStartup > timerWuDi && Time.realtimeSinceStartup - timerWuDi >=3)
                    { q = 1; }
                    if (Time.realtimeSinceStartup - timerWuDi >= 10)
                    { q = 2; }
                }  
        }
}

    }
}