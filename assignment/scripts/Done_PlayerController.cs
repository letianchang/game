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
	public GameObject shot;
	public Transform[] shotSpawn;
	public float fireRate;
    private int jimoValue;
	private float nextFire;
  
    void Start()
    {

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
                Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
                Instantiate(shot, shotSpawn[1].position, shotSpawn[1].rotation);
                Instantiate(shot, shotSpawn[2].position, shotSpawn[2].rotation);
                GetComponent<AudioSource>().Play();
            }
            else { 
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
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
	} 
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);  jimoValue = 1;
            gameController.AddScore(jimoValue);speed = speed +2;
          
          //  if (Time.time > nextFire)
           // {   
              // nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
                Instantiate(shot, shotSpawn[1].position, shotSpawn[1].rotation);
                Instantiate(shot, shotSpawn[2].position, shotSpawn[2].rotation);
                GetComponent<AudioSource>().Play();
          //  }
            
                
          
        }
    }
}
