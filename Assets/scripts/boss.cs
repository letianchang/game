using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {

   // public GameObject jimo;
   // public Vector3 spawnValues;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValueeee;
    private GameController gameController;
    public GUIText BossHPText;
    private int j = 0, x=999;
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
    void Update()
    {
        BossHPText.text = "hp"+(x - j); 
    }
    void OnTriggerEnter(Collider other)
    {  
       // x = gameController.Health();

		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Enemybullet"||other.tag=="asteroid"||other.tag == "Shield")
        {
            return;
        }
        else
        {
            gameController.AddScore(scoreValueeee);
            /*if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

                Destroy(other.gameObject);
                Destroy(gameObject); gameController.GameOver();
            }*/
           //else {
             
            // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            if (other.tag == "Laser")
            { j = j + 1; }
            else { 
            Destroy(other.gameObject);
            j = j + 1; }//Debug.Log(j);
            //}
        }

        if (j >= x)
       { 
            if (explosion != null)
            {
              // Instantiate(explosion, transform.position, transform.rotation);
           }



            
           Destroy(other.gameObject);
           Destroy(gameObject);
           
           // gameController.Destory(gameObject);

        }
    }

}
