using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class ThirdBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col) // 여기 계속 수정해야함 19.11.14;
    {
        if (col.gameObject.tag == "User_Weapon")
        {

            if (col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk01") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk02") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk03"))
            {
                //Instantiate(HitParticle, this.gameObject.transform);
                //anim.SetTrigger("Hurt");
                //Set_HP(Get_HP() - 10f);
               // Debug.Log(Get_HP());
               // GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
               // txtclone.GetComponent<FloatingText>().text.text = "-10";
                //txtclone.transform.SetParent(GameObject.Find("UI").transform);
            }
        }


    }

    private void OnMouseDown()
    {
        Debug.Log(this.gameObject.transform.name);
    }
}
