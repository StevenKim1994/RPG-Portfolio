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

    private float HP;
    private float MP;

    private float MoveSpeed;
    private float RotateSpeed;

    private string job;

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
}
