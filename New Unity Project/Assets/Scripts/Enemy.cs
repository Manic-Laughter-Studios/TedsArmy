﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    public int health = 5;      //clown specific health
    public int enemyDamage;     //damage clown does
    public int defenceDamage;   //damage defence does to clown
    public int speed;           //speed clown moves at
    public int enemyValue;      //currency player gets when clown is destroyed
    public int noEnemies;       //number of clowns

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

    void TakeDamage(int defenceDamage)
    {
        health -= defenceDamage;
    }



    void OnTriggerEnter(Collider other) //function can this be calllllllled i dont know 
    {
        //If the player hit an object with the bulltet tag
        if (other.gameObject.tag == "Bullet")
        {
            //TakeDamage functionnnnn can't figure out how to work it
            //health -= 1;
            Destroy(gameObject);
        }
    }
}
