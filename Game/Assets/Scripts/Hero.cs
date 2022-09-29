using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
	[SerializeField] private float speed = 3f;
	[SerializeField] private int hp = 1;
	[SerializeField] private float jumpForce = 3f;
	public bool isflipped = false;
	private Rigidbody2D rigidbody;
	private SpriteRenderer sprite;
	private bool Grounded = false;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		CheckGround();
	}

	private void Update()
	{
		if (Input.GetButton("Horizontal"))
			Run();

		if (Input.GetButtonDown("Vertical") && Grounded)
			Jump();
	}

	private void CheckGround()
	{
		Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		Grounded = collider.Length > 1;
	}

	private void Run()
	{
		Vector3 runDirectory = transform.right * Input.GetAxis("Horizontal");
		//Debug.Log(Input.GetAxis("Horizontal"));
		transform.position = Vector3.MoveTowards(transform.position, transform.position + runDirectory, speed * Time.deltaTime);

		sprite.flipX = runDirectory.x < 0;
		if (runDirectory.x<0) { Gunflip(true); };
		if (runDirectory.x > 0) { Gunflip(false); }
	}
	private void Gunflip(bool status)
	{
		if (status == true) 
			GameObject.Find("pistol").GetComponent<GunScript>().speed = -10;
			SpriteRenderer sprited = GameObject.Find("pistol").GetComponentInChildren<SpriteRenderer>();
			sprited.flipX = !sprited.flipX;


		if (status == false) { GameObject.Find("pistol").GetComponent<GunScript>().speed = 10; }
	}

	private void Jump()
	{
		rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); 
	}
}
