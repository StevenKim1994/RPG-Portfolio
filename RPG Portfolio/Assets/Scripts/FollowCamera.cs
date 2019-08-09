using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    Transform target;
    public float dist = 4f;

    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;

    float x = 0.0f;
    float y = 0.0f;

    float yMinLimit = -20f;
    float yMaxLimit = 80f;

    
    float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }

        if(angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }

    void Start()
    {
        target = Player.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.None;
        Vector3 angles = this.transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0, 0.9f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

        this.transform.rotation = rotation;
        target.rotation = Quaternion.Euler(0, x, 0);
        this.transform.position = position;
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

           rotation = Quaternion.Euler(y, x, 0);
           position = rotation * new Vector3(0, 0.9f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

      

        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("UP");
            dist++;

            if (dist > 9)
            {
                dist = 9;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("DOWN");
            dist--;
            if (dist < 0)
            {
                dist = 0;
            }
        }
    }
}
