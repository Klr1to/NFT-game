using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{

	public float speed = 10; // �������� ����
	public Rigidbody2D bullet; // ������ ����� ����
	public Transform gunPoint; // ����� ��������
	public float fireRate = 1; // ����������������
	public Transform zRotate; // ������ ��� �������� �� ��� Z

	// ����������� ��������
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
			Debug.Log("����� �� ��.");
			Fire();
		}
		else
		{
			curTimeout = 100;
		}

		if (zRotate) SetRotation();
	}

	void Fire()
	{
		curTimeout += Time.deltaTime;
		Debug.Log(curTimeout+" "+fireRate);
		if (curTimeout > fireRate)
		{
			Debug.Log("��� �� ��");
			curTimeout = 0;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;

			clone.velocity = transform.TransformDirection(gunPoint.right * speed);
			clone.transform.right = gunPoint.right;
		}

		Debug.Log("49 ������ �� ������");

	}
}