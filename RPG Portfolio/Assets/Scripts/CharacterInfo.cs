using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] GameObject CharacterInfoCanvas;
    // Start is called before the first frame update
 
    public void UpdateData() // 정보창 열떄 마다 호출해야댐
    {

    }

    public void ExitBtn()
    {
        CharacterInfoCanvas.SetActive(false);
    }

    public void OpenBtn()
    {
        CharacterInfoCanvas.SetActive(true);
        UpdateData();
    }
}
