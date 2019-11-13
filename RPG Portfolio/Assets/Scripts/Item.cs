using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   
       public Item(Sprite _image, bool _isempty, int _kind, string _name, int _value, float _damage, float _speed, float _armor, int _num)
        {
            image = _image;
            isempty = _isempty;
            kind = _kind;
            name = _name;
            value = _value;
            damage = _damage;
            speed = _speed;
            armor = _armor;
            num = _num;

        }
        public Sprite image;
        public bool isempty;
        public int kind;
        public string name;
        public int value;
        public float damage;
        public float speed;
        public float armor;
        public int num;

    
}
