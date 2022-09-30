using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour
{

	public float speed = 10; // скорость пули
	public bool flip = false; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность
	public Transform zRotate; // объект для вращения по оси Z

	public Vector2 GunDir;

	// ограничение вращения
	public float minAngle = -40;
	public float maxAngle = 40;

	private float curTimeout;

	void Start()
	{
	}

	void SetRotation()
	{
		Vector3 mousePosMain = Input.mousePosition;
		mousePosMain.z = Camera.main.transform.position.z;
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		angle = Mathf.Clamp(angle, minAngle, maxAngle);
		zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Debug.Log("Вроде всё ок.");
			Fire();
		}
		else
		{
			curTimeout += Time.deltaTime;
		}

		Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GunDir = mousepos - (Vector2)gunPoint.position;
		gunPoint.right = GunDir;
	}

	Transform GetClosestEnemy(List<Transform> enemies, Transform fromThis)
	{
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = fromThis.position;
		foreach (Transform potentialTarget in enemies)
		{
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if (dSqrToTarget < closestDistanceSqr)
			{
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}
		return bestTarget;
	}

	void Fire()
	{
		curTimeout += Time.deltaTime;
		Debug.Log(curTimeout + " " + fireRate);
		if (curTimeout > fireRate)
		{
			Rigidbody2D BulletIns = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
			BulletIns.AddForce(BulletIns.transform.right * speed);
			curTimeout = 0;

			//Debug.Log("Рил всё ок");
			//Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity);
			//clone.GetComponent<SpriteRenderer>().flipX = flip;

			//clone.velocity = transform.TransformDirection(gunPoint.right * speed * (flip ? -1 : 1));
			//clone.transform.right = gunPoint.right;
		}

		Debug.Log("49 строка не прошла");

	}
}