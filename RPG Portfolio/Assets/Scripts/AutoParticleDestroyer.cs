using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParticleDestroyer : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();      
    }

    // Update is called once per frame
    void Update()
    {
        if(ps)
        {
            if(!ps.IsAlive())
            {
                Destroy(this.gameObject);
            }
        }

    }
}
