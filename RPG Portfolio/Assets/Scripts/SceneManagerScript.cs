using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
   public void EnterDungeonFirst()
    {
       // SceneManager.LoadScene("FirstDungeonScene");
       LoadingSceneManagerScript.LoadScene("FirstDungeonScene");
    }
    public void EnterBlackSmith()
    {
        //SceneManager.LoadScene("InBlackSmithScene");
        LoadingSceneManagerScript.LoadScene("InBlackSmithScene");

    }

    public void EnterCamp()
    {
       // SceneManager.LoadScene("CampScene");
       LoadingSceneManagerScript.LoadScene("CampScene");
    }
}
