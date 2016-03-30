using UnityEngine;
using System.Collections;

public class levelmanager : MonoBehaviour {
  
	// Use this for initialization
    public   void LoadGame(string name)
    {
        Application.LoadLevel(name);
    }
    public void quit() 
    {
        Application.Quit();
    }
    public void score(string name)
    {
        Application.LoadLevel(name);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
