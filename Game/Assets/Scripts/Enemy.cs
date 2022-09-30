using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float Max_HP = 10;
	private float HP = 10;

	private AudioSource deathsound;

	void Start()
	{
		HP = Max_HP;
		deathsound = transform.Find("DeathSound").GetComponent<AudioSource>();
	}

	void Update()
	{

	}

	public void OnShooted()
	{
		HP--;
		transform.Find("HealthBar").Find("health").GetComponent<Image>().fillAmount = HP / Max_HP;
		if (HP <= 0)
		{
			deathsound.Play();
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.gameObject.name);
	}
}
