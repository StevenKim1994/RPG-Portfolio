using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]
    AudioClip []bgmsound = new AudioClip[10]; //0 : CharacterSelectScene 1 : ChurchBGM 2 : CampBGM 3 : BlacksmithBGM 4 : FirstDungeon 5 : SecondDungeon 6 : 6 : ThirdDungeon
    [SerializeField]
    GameObject bgmPlayer;
   
    public AudioClip bgmreturn(int _in)
    {
        return bgmsound[_in];
    }

    
}
