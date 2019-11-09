using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originPos;
    
    void Start()
    {
        originPos = transform.localPosition;
    }

    public IEnumerator Shake(float _amount, float _duration, Transform _target)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = _target.gameObject.transform.position * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

    }

    public void ShakeStart(Transform _in)
    {
        StartCoroutine(Shake(2f,2f,_in));
    }
}
