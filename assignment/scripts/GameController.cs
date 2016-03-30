using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
   // public GameObject jimo;
    public GameObject hazard;
    public GameObject jimo;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int h;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
   // public int jimoCount;
    private bool gameOver;
    private bool restart;
    private int score;
    private int s;
    //private float x = 2;
    //private Done_DestroyByContact gameController;
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        
        score = 0;
        h = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
       // StartCoroutine(JimoWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
   public int Health()
    {
       // x = x + 0.5f;
        int t = h/2+1;
            
       
       return t; 
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation); 
                /*if (i % 6 == 0&&i<=24) {
                Vector3 jimoPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(jimo, jimoPosition, spawnRotation);  }*/yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            hazardCount = Mathf.CeilToInt(hazardCount +2);
            spawnWait = spawnWait * 0.9f;
            h = h + 1;

          
        }
    }
 

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void Destory(GameObject gameobject)
    {
        s = s + 1;
        if (s % 4 == 0)
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(jimo, gameobject.transform.position, spawnRotation);  
        }

    }
    
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}