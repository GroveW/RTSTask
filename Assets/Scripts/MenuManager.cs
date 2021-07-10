using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text bestTimeText;

    void Start()
    {
        bestTimeText.text = "Best Time: " + PlayerPrefs.GetFloat("BestTime");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
