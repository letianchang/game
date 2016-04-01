using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    private bool lowSpeed;
    public GUIText powerText;

	public float speed;
	public float tilt;
	public Done_Boundary boundary;
    private GameController gameController;
	public GameObject[] shot;
    public GameObject zdd;
    public GameObject ydd;
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
        lowSpeed = false;
        zdd.SetActive(false);
        ydd.SetActive(false);
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
        powerText.text = "power : " + jimoValue1;
		if (Time.time > nextFire)
        {
            if (jimoValue1 < 1)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
                GetComponent<AudioSource>().Play();
            }
            else
            {
                zdd.SetActive(true);
                ydd.SetActive(true);
                if (jimoValue1 < 4)
                {
                    nextFire = Time.time + fireRate;
                    ShootMainBullet(-0.2f, -8.0f);
                    ShootMainBullet(-0.1f, -4.0f);
                    //ShootMainBullet(0.0f, 0.0f);
                    //ShootMainBullet(0.1f, 4.0f);
                    //ShootMainBullet(0.2f, 8.0f);
                    //Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
                    //Instantiate(shot[1], shotSpawn[1].position, shot[1].GetComponent<Rigidbody>().rotation);
                    // Instantiate(shot[1], shotSpawn[2].position, shot[1].GetComponent<Rigidbody>().rotation);
                    ShootSubBullet(0.15f, 0.1f);
                    GetComponent<AudioSource>().Play();
                }
                else if (jimoValue1 < 8)
                {
                    nextFire = Time.time + fireRate;
                    ShootMainBullet(-0.2f, -2.0f);
                    ShootMainBullet(0.2f, 2.0f);
                    ShootMainBullet(0.0f, 0.0f);
                    //Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
                    //Instantiate(shot[1], shotSpawn[1].position, shot[1].GetComponent<Rigidbody>().rotation);
                    // Instantiate(shot[1], shotSpawn[2].position, shot[1].GetComponent<Rigidbody>().rotation);
                    ShootSubBullet(0.15f, 0.2f);
                    GetComponent<AudioSource>().Play();
                }
                else if (jimoValue1 >= 8)
                {
                    nextFire = Time.time + fireRate;
                    ShootMainBullet(-0.2f, -8.0f);
                    ShootMainBullet(-0.1f, -4.0f);
                    ShootMainBullet(0.0f, 0.0f);
                    ShootMainBullet(0.1f, 4.0f);
                    ShootMainBullet(0.2f, 8.0f);
                    //Instantiate(shot[0], shotSpawn[0].position, shotSpawn[0].rotation);
                    //Instantiate(shot[1], shotSpawn[1].position, shot[1].GetComponent<Rigidbody>().rotation);
                    // Instantiate(shot[1], shotSpawn[2].position, shot[1].GetComponent<Rigidbody>().rotation);
                    ShootSubBullet(0.3f, 0.3f);
                    GetComponent<AudioSource>().Play();
                }
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
            
		}
	}
    

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        Debug.Log(moveVertical);
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        if (moveVertical > 0)
        {  
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        else if (moveVertical<=0) { GetComponent<Rigidbody>().velocity = movement * (speed + 5); }
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
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
            other.gameObject.SetActive(false); jimoValue1 = jimoValue1+1; 
            gameController.AddScore(jimoValue);

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
    void ShootSubBullet(float scale, float lifeTime)
    {
        GameObject subBulletL = Instantiate(
            shot[1],
            new Vector3(
               shotSpawn[1].position.x,
                0.0f,
               shotSpawn[1].position.z + 20.0f
            ),
            Quaternion.Euler(90.0f, 0.0f, 0.0f)
        ) as GameObject;
        GameObject subBulletR = Instantiate(
            shot[1],
            new Vector3(
                shotSpawn[2].position.x,
                0.0f,
                shotSpawn[2].transform.position.z + 20.0f
            ),
            Quaternion.Euler(90.0f, 0.0f, 0.0f)
        ) as GameObject;
        subBulletL.transform.localScale = new Vector3(scale, 20.0f, scale);
        subBulletR.transform.localScale = new Vector3(scale, 20.0f, scale);
        subBulletL.transform.parent = shotSpawn[1].transform;
        subBulletR.transform.parent = shotSpawn[2].transform;
        Destroy(subBulletL, lifeTime);
        Destroy(subBulletR, lifeTime);
    }
    void ShootMainBullet(float xPosition, float yRotation)
    {
        Instantiate(
            shot[0],
            new Vector3(
                transform.position.x + xPosition,
                0.0f,
                transform.position.z + 0.5f
            ),
            Quaternion.Euler(0.0f, yRotation, 0.0f)
        );
    }
}
