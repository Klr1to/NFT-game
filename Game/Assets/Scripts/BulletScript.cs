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
		Debug.Log(colliderofplayer);
		Debug.Log(coll.ToString());
		if (!coll.isTrigger && coll.ToString() != "Hero (UnityEngine.BoxCollider2D)") // ����� ���� �� ����������� �� �������
		{
			switch (coll.tag)
			{
				case "Enemy_1":
					// ���-��...
					break;
				case "Enemy_2":
					// ���-�� ���...
					break;
			}

			Destroy(gameObject);
		}
	}
}

