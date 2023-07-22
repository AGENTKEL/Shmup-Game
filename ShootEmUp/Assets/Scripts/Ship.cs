using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Gun[] guns;

    public float moveSpeed = 5;
    public float fireRate = 0.2f;
    public float nextFireTime = 0f;

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

            // Check if enough time has passed since the last shot before allowing another shot.
            if (Time.time >= nextFireTime)
            {
                foreach (Gun gun in guns)
                {
                    gun.Shoot();
                }

                // Calculate the time when the ship will be allowed to shoot again.
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            Destroy(gameObject);
            Destroy(destructable.gameObject);
        }
    }
}
