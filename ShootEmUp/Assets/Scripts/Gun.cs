using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;
    Vector2 direction;


    private void Start()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
    }


    void Update()
    {
        
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet =  go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}
