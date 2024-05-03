using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetAnimationScene : MonoBehaviour
{
    public void loadAnimationScene(TextMeshProUGUI text){
        string scene_to_change_to=text.text;
        SceneManager.LoadScene(scene_to_change_to);
    }
}
