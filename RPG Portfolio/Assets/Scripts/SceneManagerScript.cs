using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
   public void EnterDungeonFirst()
    {
        SceneManager.LoadScene("FirstDungeon");
    }
    public void EnterBlackSmith()
    {
        SceneManager.LoadScene("BlackSmith");

    }
}
