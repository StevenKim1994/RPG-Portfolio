using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScripts : MonoBehaviour
{
    private int sTR;
    private int dEX;
    private int iNT;
    private float armor;
    private float damage;
    private string name;

    private float HP = 100f;
    private float MP = 100f;

    private float MoveSpeed;
    private float RotateSpeed;

    private string job;
    private Vector3 oldposition;
    private GameObject target;

    private int HPPo = 0;
    private int MPPo = 0;
    public GameObject Get_Target()
    {
        return target;
    }
    public void Set_Target(GameObject _in)
    {
        target = _in;
    }
    public void Save_Name(string _in)
    {
        name = _in;
    }

    public string Load_Name()
    {
        return name;
    }

    public void Save_Armor(float _in)
    {
        armor = _in;
    }

    public float Load_Armor()
    {
        return armor;
    }

    public void Save_Damage(float _in)
    {
        damage = _in;
    }

    public float Load_Damage()
    {
        return damage;
    }

    public void Save_HP(float _in)
    {
        HP = _in;
    }

    public float Load_HP()
    {
        return HP;
    }

    public void Save_MP(float _in)
    {
        MP = _in;
    }

    public float Load_MP()
    {
        return MP;
    }

    public void Save_STR(int _in)
    {
        sTR = _in;
    }

    public void Save_DEX(int _in)
    {
        dEX = _in;
    }

    public void Save_INT(int _in)
    {
        iNT = _in;
    }

    public int Load_STR()
    {
        return sTR;
    }

    public int Load_DEX()
    {
        return dEX;
    }

    public int Load_INT()
    {
        return iNT;
    }

    public void Save_Job(string _in)
    {
        job = _in;
    }

    public string Load_Job()
    {
        return job;
    }

    public void Set_OldPosition(Vector3 _in)
    {
        oldposition = _in;
    }

    public Vector3 Get_OldPosition()
    {
        return oldposition;
    }

    public int Get_HPPo()
    {
        return HPPo;
    }

    public void Set_HPPo(int _in)
    {
        HPPo = _in;
        // UI부분에도 갯수 업데이트시키기...
    }

    public int Get_MPPo()
    {
        return MPPo;
        // UI부분에도 갯수 업데이트 시키기.
    }

    public void Set_MPPo(int _in)
    {
        MPPo = _in;
    }
}
