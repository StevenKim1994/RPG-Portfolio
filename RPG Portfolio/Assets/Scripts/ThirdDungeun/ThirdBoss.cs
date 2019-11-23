using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class ThirdBoss : MonoBehaviour
{
    [SerializeField] GameObject DropBox;
    [SerializeField] GameObject HitPartcle;

    NavMeshAgent nav;
    Transform Target;
    ManagerSingleton MGR = new ManagerSingleton();
    UISingleton UI = new UISingleton();
    float hP = 0f;
    float mP = 100f;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(hP <= 0f)
        {
            state = 1; // 죽음
            Instantiate(DropBox, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 10f, this.gameObject.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(state == 0) // 살아있을떄만
        nav.destination = Target.position;
        nav.enabled = true;
    }
    private void OnTriggerEnter(Collider col) // 여기 계속 수정해야함 19.11.14;
    {
        if (col.gameObject.tag == "User_Weapon")
        {
            Debug.Log("충돌!!");
            //if (col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk01") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk02") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk03"))
            //{

                //Instantiate(HitParticle, this.gameObject.transform);
                //anim.SetTrigger("Hurt");
                //Set_HP(Get_HP() - 10f);
               // Debug.Log(Get_HP());
               // GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
               // txtclone.GetComponent<FloatingText>().text.text = "-10";
                //txtclone.transform.SetParent(GameObject.Find("UI").transform);
            //}
        }


    }

    private void OnMouseDown()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_Target(this.gameObject);


    }

    private void OnMouseOver()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().AttackCursor();
    }

    private void OnMouseExit()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().DefaultCursor();
    }
}
