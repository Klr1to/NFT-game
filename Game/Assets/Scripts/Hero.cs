using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Hero : MonoBehaviour
{
	[SerializeField] private float speed = 3f;
	[SerializeField] public float maxhp = 3f;
	[SerializeField] private float jumpForce = 3f;
	public bool isflipped = false;
	private Rigidbody2D rigidbody;
	private SpriteRenderer sprite;
	private Animator animator;

	private bool Grounded = false;
	private float hp;
	private void Awake()
	{
		hp = maxhp;
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		CheckGround();
	}
	private void Update()
	{
		if (Input.GetButton("Horizontal"))
		{
			Run();
			animator.SetBool("isRunning", true);
		}
		else
		{
			animator.SetBool("isRunning", false);
		}

		if (Input.GetButtonDown("Vertical") && Grounded)
			Jump();

		animator.SetBool("isAttacking", Input.GetKeyDown("space"));

		//if (Grounded)
		animator.SetBool("isJumping", !Grounded);
	}

	private void CheckGround()
	{
		Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		Grounded = collider.Length > 1;
	}

	private float GetSpeedMultiplier()
	{
		return Input.GetKey(KeyCode.LeftControl) ? 2 : 1;
	}

	private void Run()
	{
		Vector3 runDirectory = transform.right * Input.GetAxis("Horizontal");
		//Debug.Log(Input.GetAxis("Horizontal"));
		transform.position = Vector3.MoveTowards(transform.position, transform.position + runDirectory, speed * GetSpeedMultiplier() * Time.deltaTime);

		sprite.flipX = runDirectory.x < 0;
		GameObject.Find("pistol").GetComponent<GunScript>().flip = runDirectory.x < 0;
	}

	private void Jump()
	{
		rigidbody.AddForce(transform.up * GetSpeedMultiplier() * jumpForce, ForceMode2D.Impulse);
		animator.SetBool("isJumping", true);
	}

	public void TakeDamage()
	{
		hp--;
		Debug.Log("Сейчас филл =" + hp / maxhp + "HP =" + hp + "MaxHP =" + maxhp);
		GameObject.Find("PlayerHealth").GetComponent<Image>().fillAmount = hp / maxhp;
		if (hp <= 0)
			SceneManager.LoadScene(3);
	}
}
