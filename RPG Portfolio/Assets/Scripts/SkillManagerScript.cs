// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkillManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Player;

    [SerializeField]
    Sprite[] SKILL_ICON = new Sprite[12];

    [SerializeField]
    Sprite[] Potion_ICON = new Sprite[12];

    
 

    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

  


    public void Set_Player(GameObject _in)
    {
        Player = _in;
    }

}


