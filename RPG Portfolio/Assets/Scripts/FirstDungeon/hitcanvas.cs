using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitcanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hit;
    public void Start()
    {
        Instantiate(hit);
    }
}
