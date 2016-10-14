using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public static int opponentCount=0;
    void Start()
    {
        if (autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Next level auto is disabled");
        }
        else {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    
	public void LoadLevel(string scene_name) {
        if(scene_name == "01a Start")
        {
            opponentCount = 0;
        }
        Application.LoadLevel(scene_name);
	}
	
    
	public void Quit_Requested() {
		
		Application.Quit();
	}
    public void LoadNextLevel()
    {
     
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    
}
