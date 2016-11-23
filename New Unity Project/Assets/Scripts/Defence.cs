using UnityEngine;
using System.Collections;

public class Defence : MonoBehaviour {

    public Transform target; //which clown the turret aims at
    public float defenceDamage; //the damage the defence does
    public float fireRate; //the rate the defence fires at
    public GameObject bullet; //the bullet gameobject the defence fires

    public float range = 20f;

    public string enemyTag = "Enemy";

    public float fireCountdown = 0f;

    public Transform firePoint;

    public bool uselaser = false;
    public LineRenderer lineRenderer;
    public bool active = false;

    void Start()
    {
        //UpdateTarget is called 2X a second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Find the nearest target.
    void UpdateTarget()
    {
        //Find gameObject with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //Store the shortest distance to found enemy
        float shortestDistance = Mathf.Infinity;
        //Store nearest Enemy
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            //Get disntance to enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //is the distance shorter than the distance found before?
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //if we found an enemy and the shortest distance is in our range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            //Then target that enemy
            target = nearestEnemy.transform;
        }
        else
        {
            //if they leave range..then stop targeting them
            target = null;
        }
    }


    void Update()
    {
        if (!active)
        {
            return;
        }
        //if no traget is present... dont do anything
        if (target == null)
        {
            if (uselaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }

        LockOnTarget();
        if (uselaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Find(target);
    }

    void OnDrawGizmosSelected()
    {
        //Range is noe colored red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
