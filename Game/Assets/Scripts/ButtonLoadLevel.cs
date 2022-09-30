using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLoadLevel : MonoBehaviour
{
    public Button button ;
    public int levelID;

    // Update is called once per frame
    void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener( delegate() { NextLevel(levelID); } );
    }
    void NextLevel(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
        Destroy(gameObject);
    }
}
