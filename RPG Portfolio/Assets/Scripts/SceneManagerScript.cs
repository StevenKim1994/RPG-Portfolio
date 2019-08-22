using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public void EnterStartChurch()
    {
        LoadingSceneManagerScript.LoadScene("InChurchScene");
    }
   public void EnterDungeonFirst()
    {
        LoadingSceneManagerScript.LoadScene("FirstDungeonScene");
    }
    public void EnterBlackSmith()
    { 
        LoadingSceneManagerScript.LoadScene("InBlackSmithScene");
    }
    public void EnterCamp()
    {
        LoadingSceneManagerScript.LoadScene("CampScene");
    }
}
