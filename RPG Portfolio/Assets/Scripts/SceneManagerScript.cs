using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
   public void EnterDungeonFirst()
    {
        SceneManager.LoadScene("FirstDungeonScene");
    }
    public void EnterBlackSmith()
    {
        SceneManager.LoadScene("InBlackSmithScene");

    }

    public void EnterCamp()
    {
        SceneManager.LoadScene("CampScene");
    }
}
