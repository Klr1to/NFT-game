using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class BulletScript : MonoBehaviour
{
	public Collider2D colliderofplayer; // ������ ����� ����
	void Start()
	{
		// ���������� ������ �� ��������� ���������� ������� (������), ���� ���� ������ �� ������
		Destroy(gameObject, 20);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!coll.isTrigger && !coll.gameObject.CompareTag("Player")) // ����� ���� �� ����������� �� �������
		{
			switch (coll.tag)
			{
				case "Enemy":
					coll.gameObject.GetComponent<Enemy>().OnShooted();
					break;
				case "Enemy_2":
					// ���-�� ���...
					break;
			}

			Destroy(gameObject);
		}
	}
}

