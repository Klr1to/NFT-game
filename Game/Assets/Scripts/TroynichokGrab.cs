using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroynichokGrab : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log(string.Format("Grab {0}", this.name));
			GameObject.FindObjectOfType<TroynichokText>().AddTroynichok();
			Destroy(gameObject);
		}

	}
}
