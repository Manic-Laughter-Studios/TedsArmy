using UnityEngine;
using System.Collections;

public class Defence : MonoBehaviour {

    public Transform target; //which clown the turret aims at
    public float defenceDamage; //the damage the defence does
    public float fireRate; //the rate the defence fires at
    public GameObject Bullet; //the bullet gameobject the defence fires

    public float range = 5f; //range of defence

    public string enemyTag = "Enemy";

    public float fireCountdown = 0f;

    public Transform firePoint;

    public bool uselaser = false;
    public LineRenderer lineRenderer;
    public bool active = false;

    public float turnSpeed = 10f;

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

        //Store the shortest distance to found enemy. if havent found enemy then default is infinity
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

    /*void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(Bullet, firePoint.position, firePoint.rotation);
        Bullet Bullet = bulletGO.GetComponent<Bullet>();

        if (Bullet != null)
            Bullet.Find(target);
    }*/

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected() //this draws your range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
