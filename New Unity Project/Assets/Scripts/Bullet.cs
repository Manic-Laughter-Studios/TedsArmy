using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 5f;
    public float lifetime = 10;
    public int defenceDamage;
    private Transform target;

    public void Find(Transform _target)
    {
        target = _target;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
