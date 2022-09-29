using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class BulletScript : MonoBehaviour
{
	public Collider2D colliderofplayer; // префаб нашей пули
	void Start()
	{
		// уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
		Destroy(gameObject, 20);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log(colliderofplayer);
		Debug.Log(coll.ToString());
		if (!coll.isTrigger && coll.ToString() != "Hero (UnityEngine.BoxCollider2D)") // чтобы пуля не реагировала на триггер
		{
			switch (coll.tag)
			{
				case "Enemy_1":
					// что-то...
					break;
				case "Enemy_2":
					// что-то еще...
					break;
			}

			Destroy(gameObject);
		}
	}
}

