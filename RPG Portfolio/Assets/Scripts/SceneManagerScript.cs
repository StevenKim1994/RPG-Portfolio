using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    [SerializeField]
    GameObject bgmPlayer;
    ManagerSingleton MGR = new ManagerSingleton();
    public void EnterStartChurch()
    {
        LoadingSceneManagerScript.LoadScene("InChurchScene");
            
    }
   public void EnterDungeonFirst()
    {
        LoadingSceneManagerScript.LoadScene("FirstDungeonScene");
    }

   public void EnterDungeonThird()
   {
       LoadingSceneManagerScript.LoadScene("ThirdDungeonScene");
   }

   public void EnterDungeonSecond()
   {
       LoadingSceneManagerScript.LoadScene("SecondDungeonScene");
   }
    public void EnterBlackSmith()
    { 
        LoadingSceneManagerScript.LoadScene("InBlackSmithScene");
    }
    public void EnterCamp()
    {
        LoadingSceneManagerScript.LoadScene("CampScene");
            
       
    }
    
    public void EnterNewGame()
    {
        LoadingSceneManagerScript.LoadScene("CharacterSelectScene");
    }

}
