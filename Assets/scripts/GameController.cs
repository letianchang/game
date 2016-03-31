using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    //public Text name11Text;
    private int gaofen;
    public Text entername1;
    public GameObject name;
    public GameObject botton1;
    private float angle;
    private float angle2;
    private float angle1;
    public GameObject boss;
   // public GameObject jimo;
    public GameObject hazard;
    public GameObject enemyship;
    public GameObject jimo;
    public GameObject shot11;
    private GameObject shot1;
    public GameObject jimo1;
    public Vector3 spawnValues;
    public int hazardCount;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float enemyspawnWait;
    public float xgtime;
    public float enemywaveWait;
    private float h;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText highscoreText;
 
    public GUIText AsteroidHPText;
   // public int jimoCount;
    private bool gameOver;
    private bool restart;
    private bool hs;
    private int score;
    public Vector3 ziji;
    public Vector3 bossji;
    private int s;
    private int go;
    public float highscore;
    //private float x = 2;
    //private Done_DestroyByContact gameController;

	//story system:
	private int isStory;
	public GameObject mainCamera;
	public GameObject storyCamera;
	public GUIText storyText;
			//private int isStory;
	private string[] storyContent={ "Evil Boss: You find me finally","Player: ...", 
		"Evil Boss: I am so scared","Player: ...",
		"Evil Boss: Don't kill me please", "Player: heihei",
		"Evil Boss: Oh shit your are dead now","Player: ..."};
	private int storyIndex;
	private float storyEndTime;



    void Start()
    {
        //story init:
		storyIndex = 0;
		isStory = 0;
		storyEndTime = 0.0f;

		xgtime = xgtime + Time.time;
        Debug.Log("xtime" + xgtime);
        boss.SetActive(false); 
        name.SetActive(false);
        botton1.SetActive(false);
        go = 0;
        if (PlayerPrefs.GetFloat("HighScore") != null)
        {
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
        gameOver = false;
        restart = false;
        hs = true;
        restartText.text = "";
        gameOverText.text = "";
        //highscore = 0;
        score = 0;
        h = 0;
        UpdateScore(); 
		StartCoroutine(EnemyWaves());
        StartCoroutine(SpawnWaves());
    
    }

    public Vector3 axiba()
    {
        return ziji;
    }
    public Vector3 aaxiba()
    {
        return bossji;
    }
    public int goo()
    {
        return go; 
    }

    void Update()
	{

      AsteroidHPText.text="xg : "+Health();;
		angle = angle2 * 180 / Mathf.PI; //Debug.Log("2" + angle);
		if (Time.time > xgtime) { 
			boss.SetActive (true);
		}
			//enter story mode
		if (boss.activeSelf) {
			if (isStory == 0) {
				isStory = 1;
				gameOverText.text = "press \"Y\" to continue talking";
				//Shield.gameObject.SetActive (true);
				Time.timeScale = 0.0f;
				mainCamera.gameObject.SetActive (false);
				storyCamera.gameObject.SetActive (true);
				storyText.gameObject.SetActive (true);
			} else {	
				
				if (Input.GetKeyDown (KeyCode.Y)) {
					if (storyIndex < storyContent.Length) {
						storyText.text = storyContent [storyIndex];
						storyIndex = storyIndex + 1;
					} else {
						gameOverText.text = "";
						mainCamera.gameObject.SetActive (true);
						storyCamera.gameObject.SetActive (false);
						storyText.gameObject.SetActive (false);
						isStory = 2; // story end
						storyEndTime = Time.time;


						//Shield.gameObject.SetActive (false);
					}
				}
			}
            if (isStory == 2)
            {
                //Debug.Log(Time.realtimeSinceStartup); Debug.Log("story"+storyEndTime);
                if (Time.realtimeSinceStartup - storyEndTime < 1.5f)
                {
					gameOverText.text = "get ready!";
                }
                else if (Time.realtimeSinceStartup - storyEndTime < 2)
                {
					gameOverText.text = "Go!";				
				} else {
					gameOverText.text = "";
					isStory = 3;
					Time.timeScale = 1.0f;
				}
			}
		}
			

		if (hs) 
		{
			if (score > highscore)
			{ 
				highscore = score;            
			}
			highscoreText.text = "highscore:" + highscore;
		}

		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				// xgtime = xgtime + Time.realtimeSinceStartup;
				Application.LoadLevel (Application.loadedLevel);
			}
		}
			bossji = boss.GetComponent<Rigidbody> ().position;
			ziji = shot11.GetComponent<Rigidbody> ().position;


		}

   
	public float Health()
    {
       // x = x + 0.5f;
        float t = h/2+1;
       
       
       return t; 
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z) ;
                Quaternion spawnRotation = Quaternion.identity; //Debug.Log("1" + spawnPosition);

               shot1= Instantiate(hazard, spawnPosition, spawnRotation)as GameObject; 
                /*if (i % 6 == 0&&i<=24) {
                Vector3 jimoPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(jimo, jimoPosition, spawnRotation);  }*/yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true; hs = false; 
                highscoreText.text = " ";
                break;
            }
            hazardCount = Mathf.CeilToInt(hazardCount +2);
            spawnWait = spawnWait * 0.9f;
            h = h + 1;

          
        }
    }
    IEnumerator EnemyWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
          
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition1 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                if (Time.time < xgtime)
                {
                    
                   shot1= Instantiate(enemyship, spawnPosition1, spawnRotation)as GameObject;
                   // botton.SetActive(false);
                   
                }
                else { 
                    //Debug.Log("aaa"); 
                }
                /*if (i % 6 == 0&&i<=24) {
                Vector3 jimoPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(jimo, jimoPosition, spawnRotation);  }*/
                yield return new WaitForSeconds(enemyspawnWait);
            }
            yield return new WaitForSeconds(enemywaveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true; hs = false;
                highscoreText.text = " "; 
                break;
            }

           enemyCount = Mathf.CeilToInt(enemyCount + 1);
            

        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void Destory(GameObject gameobject)
    {
        s = s + 1; Debug.Log("s=" + s);
        if (s % 4 == 0)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(jimo, gameobject.transform.position, spawnRotation);  
        }
        if (s % 9 == 0)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(jimo1, gameobject.transform.position, spawnRotation);
            s = 0;
        }

    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
       // Debug.Log(PlayerPrefs.GetFloat("HighScore"));
        gameOverText.text = "Game Over!"; PlayerPrefs.SetFloat("score", score); 
        if(highscore>PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", highscore); gaofen = 1;
        name.SetActive(true);
        botton1.SetActive(true);
        }
        
        gameOver = true; go = 1;
    
    }
    public void entername()
    {
        if (entername1.text != string.Empty)
        {
            Debug.Log("aaaaa");
             PlayerPrefs.SetString("naaaame", entername1.text);    Application.LoadLevel("score");
    
        }
    }

}