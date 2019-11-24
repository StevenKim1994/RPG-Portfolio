// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTableScript : MonoBehaviour
{
    struct Weapon
    {

        string Name;

        int RecommandLevel;

        float Range;

        float Damage;
        float Speed;

        int Durability;

        int BuyValue;
        int SellValue;
        
    }

    struct Armor
    {
        string Name;

        int RecommandLevel;

        float Defense;

        int Durability;

        int BuyValue;
        int SellValue;
    }

}
