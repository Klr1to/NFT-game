using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DoorLevelLoadTrigger : MonoBehaviour
{
	[SerializeField] public int levelID = 1;

	void NextLevel(int _sceneNumber)
	{
		SceneManager.LoadScene(_sceneNumber);
		Destroy(gameObject);
		Debug.Log("Чтото произошло");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{

			NextLevel(levelID);
		}

	}
}
