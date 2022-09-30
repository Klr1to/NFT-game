using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private AudioSource kicksound;
    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float agrodist;
    void Start()
    {
        physic = transform.GetComponent<Rigidbody2D>();
        kicksound = transform.Find("KickSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancetoplayer = Vector2.Distance(transform.position, player.position);
        if (distancetoplayer < agrodist)
        {
            StartVisely();
        }
        else 
        {
            StopVisely();
        }
    }
    void StartVisely() {
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-10, 0);
        }
        else if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(10, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<Hero>().TakeDamage();
            kicksound.Play();
        }
    }
    void StopVisely()
    {
        physic.velocity = new Vector2(0, 0);
    }
}
