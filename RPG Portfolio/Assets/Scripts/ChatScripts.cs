using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatScripts : MonoBehaviour
{
    [SerializeField] private InputField InputText;

    [SerializeField] private GameObject Chatbox;

    private ManagerSingleton MGR;
    // Start is called before the first frame update
    void Start()
    {
        MGR = new ManagerSingleton();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Chatbox.GetComponent<Text>().text+= System.DateTime.Now.ToString("HH:mm:ss") + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Name() + " " + InputText.text + '\n';
            Debug.Log("엔터");
        }
    }
}
