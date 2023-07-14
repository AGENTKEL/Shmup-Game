using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    Gun[] guns;

    public float moveSpeed = 5;

    private void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }



    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = Vector3.Lerp(transform.position, touchPosition, moveSpeed * Time.fixedDeltaTime);

            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }

    }
}
