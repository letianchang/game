using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    public GUIText scoreText;
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
    private GameController gameController;
	public GameObject[] shot;
	public Transform[] shotSpawn;
	public float fireRate;
    private int jimoValue;
    private int jimoValue1;
	private float nextFire;
    public GameObject Shield;
    private int isWuDi;
    private int isSuoXiao;
    private float timerWuDi;
    private float timerSuoXiao;
    private Rigidbody rb;

    void Start()
    {
        jimoValue1 = 0;
        rb = GetComponent<Rigidbody>();
        isWuDi = 0;
        isSuoXiao = 0;


        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	void Update ()
	{
		if (Time.time > nextFire)
        {
            if (jimoValue == 1)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
                Instantiate(shot[1], shotSpawn[1].position, shotSpawn[1].rotation);
                Instantiate(shot[1], shotSpawn[2].position, shotSpawn[2].rotation);
                GetComponent<AudioSource>().Play();
            }
           /* if (jimoValue1 == 2)
            {
                nextFire = Time.time + fireRate;
                for (int i = 0; i <=15;i++ )
                    if (i % 2 == 0)
                    {
                        Instantiate(shot[0], shotSpawn[i].position, shotSpawn[i].rotation);
                    }
                    else
                    {
                        Instantiate(shot[1], shotSpawn[i].position, shotSpawn[i].rotation);
                    }
               
                GetComponent<AudioSource>().Play();
            }*/
            else { 
			nextFire = Time.time + fireRate;
            Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
			GetComponent<AudioSource>().Play ();}
		}
	}
    

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        if (isWuDi == 1 && Time.realtimeSinceStartup - timerWuDi >= 5)
        {

            isWuDi = 0;
            Shield.gameObject.SetActive(false);
        }
        //缩小计时
        if (isSuoXiao == 1 && Time.realtimeSinceStartup - timerSuoXiao >= 5)
        {

            isSuoXiao = 0;
            rb.transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
        }

	} 
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false); jimoValue = 1; 
            gameController.AddScore(jimoValue);speed = speed +2;

            }      
           //无敌
            if (other.gameObject.CompareTag("PUWuDi"))
            {
                Destroy(other.gameObject);
                isWuDi = 1;
                Shield.gameObject.SetActive(true);
                timerWuDi = Time.realtimeSinceStartup;

            }

            //缩小
            if (other.gameObject.CompareTag("PUSuoXiao"))
            {
                Destroy(other.gameObject);
                isSuoXiao = 1;
                rb.transform.localScale -= new Vector3(0.5F, 0.5F, 0.5F);
                timerSuoXiao = Time.realtimeSinceStartup;
        }
    }
}
