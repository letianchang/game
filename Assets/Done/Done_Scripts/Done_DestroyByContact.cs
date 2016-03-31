using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
    
    public Vector3 spawnValues;
	public GameObject explosion;
	public GameObject playerExplosion;
    //public GameObject explosion1;
	public int scoreValue;
	private GameController gameController;

    private float x ;
    private float i;
	void Start ()
    {
        
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
        
	}

    void OnTriggerEnter(Collider other)
    {
        x = gameController.Health();

        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Enemybullet" || other.tag == "boss")
        {
            return;
        }
        else
        {
            if (other.tag == "Shield")
            {
                Destroy(gameObject);
            }
            else
            {
                if (other.tag == "Player")
                {
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

                    Destroy(other.gameObject);
                    Destroy(gameObject); gameController.GameOver();
                }
                else {
                      if(other.tag == "Laser")
                      { 
                          i = i + 0.5f; //Instantiate(explosion1, transform.position, transform.rotation); 
                      } 
                      else
                      { i = i + 1; Destroy(other.gameObject);  }
                     }
            }
        }

        if (i >= x)
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }



            //  speedText.text = "Score: " + j;
            if (gameController.goo() != 1)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                gameController.AddScore(scoreValue);
                gameController.Destory(gameObject);
            }
        }
    }

}