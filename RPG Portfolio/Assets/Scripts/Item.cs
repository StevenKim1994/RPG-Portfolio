// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] GameObject tooltipUI;
       public Item(Sprite _image, bool _isempty, int _kind, string _name, int _value, float _damage, float _speed, float _armor, int _num , string _desc)
        {
            image = _image;
            isempty = _isempty;
            kind = _kind; // 0 : 이면 소모품(물약) 1 : 이면 방어구 2 : 이면 무기임.
            name = _name;
            value = _value;
            damage = _damage;
            speed = _speed;
            armor = _armor;
            num = _num;
            description = _desc;

        }

   public  Item data;
        public Sprite image;
        public bool isempty;
        public int kind;
        public string name;
        public int value;
        public float damage;
        public float speed;
        public float armor;
        public int num;
    public string description;

    public void set_data(Item _in)
    {
        image = _in.image;
        isempty = _in.isempty;
        kind = _in.kind; // 0 : 이면 소모품(물약) 1 : 이면 방어구 2 : 이면 무기임.
        name = _in.name;
        value = _in.value;
        damage = _in.damage;
        speed = _in.speed;
        armor = _in.armor;
        num = _in.num;
        description = _in.description;
        data = _in;
    }

    public Item get_data()
    {
        return data;
    }
}
