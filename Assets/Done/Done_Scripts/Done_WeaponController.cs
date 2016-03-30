using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
    private GameController gameController;
    public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
    public GameObject shot11;
    private GameObject shot1;
    private float angle;
    private float angle2;
    private float angle1;
    private Rigidbody rb;
    public float waveWait;
        private float nextFire;
	void Start ()
        {
            GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>(); Debug.Log("asd");
            }
		 //InvokeRepeating ("Fire", delay, fireRate);
       StartCoroutine(EnemyWaves());
	}

	void Fire ()
    {
        if (Time.time > nextFire)
        {


            nextFire = Time.time + fireRate;
            angle2 = Mathf.Atan((shot11.GetComponent<Rigidbody>().position.x - GetComponent<Rigidbody>().position.x) / (GetComponent<Rigidbody>().position.z - shot11.GetComponent<Rigidbody>().position.z));

            angle = angle2 * 180 / Mathf.PI; //Debug.Log("angle=" + angle);
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(0, -angle, 0));
            //GetComponent<AudioSource>().Play();
        }
	}
    IEnumerator EnemyWaves()
    {
       yield return new WaitForSeconds(delay);
        while (true)
        {

            for (int i = 0; i < 3; i++)
            {
                angle2 = Mathf.Atan((GetComponent<Rigidbody>().position.x-gameController.ziji.x ) / (GetComponent<Rigidbody>().position.z - gameController.ziji.z));
               // angle = gameController.jiaodu();
                angle = angle2 * 180 / Mathf.PI;
               // Debug.Log("angle=" + angle);
                shot1 = Instantiate(shot, shotSpawn.position, Quaternion.Euler(0, angle, 0)) as GameObject;
                // shot1.GetComponent<Rigidbody>().velocity = shot1.transform.forward * -10; 
                // else { Debug.Log("aaa"); }
                /*if (i % 6 == 0&&i<=24) {
                Vector3 jimoPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(jimo, jimoPosition, spawnRotation);  }*/
                yield return new WaitForSeconds(fireRate);
            }

            yield return new WaitForSeconds(waveWait);

          

   


        }
    }
}
