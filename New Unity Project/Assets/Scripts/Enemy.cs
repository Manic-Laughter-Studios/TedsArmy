using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    public string Name;
    public float health;
    public string weaponname;
    public float enemydamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*if () ; //trigger when hit do takedamage*/

        //move fucker

        if (health <= 0) //when the enemies health is <= 0 then destory it
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    //for when reach Jack's bed
    void OnCollisionEnter(Collision col)
    {
        // If the enemy makes it to the end (hits end wall), it will destroy
        if (col.gameObject.name == "Jack")
        {
            Destroy(gameObject);
        }
        else (col.gameObject.tag == "Bullet")
        {
            TakeDamage;
        }
    }
}
