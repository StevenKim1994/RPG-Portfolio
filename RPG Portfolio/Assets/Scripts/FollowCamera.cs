using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    Transform target;
    public float Dist;
    public float Height;
    public float SmoothRotate;

    Transform camera;

    public void Set_Target(GameObject _input)
    {
        target = _input.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = Player.transform;
        camera = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
       
        if(target != null)
        {
            float curraYAngle = Mathf.LerpAngle(camera.eulerAngles.y, camera.eulerAngles.y, SmoothRotate * Time.deltaTime);

            Quaternion rot = Quaternion.Euler(0, curraYAngle, 0);

            camera.transform.position = target.position - (rot * Vector3.forward * Dist) + (Vector3.up * (Height));

            camera.transform.LookAt(target);
        }
    }
}
