using UnityEngine;
using System.Collections;

public class bossbullet : MonoBehaviour
{
   // public GameObject jimo;
   // public Vector3 spawnValues;
    public GameObject explosion;
    public GameObject playerExplosion;
    //public int scoreValue;
    private GameController gameController;
    private int l=0;
    //private int i = 0, x;
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

    void OnTriggerEnter(Collider other)
    {
       // x = gameController.Health();

        if (other.tag == "Boundary" || other.tag == "Enemy"||other.tag=="asteroid" )
        {
            return;
        }
        else
        {
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

                Destroy(other.gameObject);
                Destroy(gameObject); gameController.GameOver();
            }
          //  else { i = i + 1; Destroy(other.gameObject); }
        }
        if (other.tag == "cai")
        {
         //   l = l + 1; //Debug.Log("l="+  l);
        }
        //if (i == x)
        //{
           // if (explosion != null)
            //{
           //     Instantiate(explosion, transform.position, transform.rotation);
           // }



            //  speedText.text = "Score: " + j;
            //Destroy(other.gameObject);
           // Destroy(gameObject);
           // gameController.AddScore(scoreValue);
           // gameController.Destory(gameObject);

        //}
    }

}