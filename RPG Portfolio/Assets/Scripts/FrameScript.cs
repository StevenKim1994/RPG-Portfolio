using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameScript : MonoBehaviour
{
    [SerializeField] GameObject hpBar;
    [SerializeField] GameObject mpBar;
    [SerializeField] GameObject portrait;

    void Start()
    {
        if(this.gameObject.name == "UnitFrame") // 이 스크립트가 적용된 오브젝트가 플레이어일때 ...
        {

        }

        else if(this.gameObject.name =="TargetFrame")// 이 스크립트가 적용된 오브젝트가 타겟일때 ...
        {


        }
    }

    void SetData(float _hp, float _mp)
    {

    }
}
