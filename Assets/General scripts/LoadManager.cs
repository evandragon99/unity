using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    //name of scene to be loaded
    public string SceneName;
   
    public void changeScene()
    {
        //change scene to scene with SceneName
        SceneManager.LoadScene(SceneName);
    }
}
