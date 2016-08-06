using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Screen.SetResolution(1280, 720, true, 60);
        }
        else
        {
            Screen.SetResolution(1280, 720, false, 60);
        }      
    }
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
}
