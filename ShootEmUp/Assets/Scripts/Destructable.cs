using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    bool canBeDestroyed = false;


    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.x < 20f)
        {
            canBeDestroyed = true;
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
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
