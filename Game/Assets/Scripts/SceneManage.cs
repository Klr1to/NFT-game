using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
	[SerializeField] private int levelID = 1;
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{

			NextLevel(levelID);
		}

	}
	public void NextLevel(int _sceneNumber)
	{
		SceneManager.LoadScene(_sceneNumber);
		Destroy(gameObject);

	}

}
