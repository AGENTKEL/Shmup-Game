using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    bool canBeDestroyed = false;


    void Start()
    {
        Level.instance.AddDestructables();
    }


    void Update()
    {
        if (transform.position.x < 20f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            Gun [] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Level.instance.RemoveDestructables();
    }
}
