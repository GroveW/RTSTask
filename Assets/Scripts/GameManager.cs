using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text currentTimeText;
    private float currentTime = 0.0f;

    private MouseInteractions mouseInteractions;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text bestTimeText;
    [SerializeField]
    private Text timeText;

    [SerializeField]
    private GameObject doorPrefab;
    [SerializeField]
    private GameObject chestPrefab;

    [SerializeField]
    private float roomWidth;
    [SerializeField]
    private float roomDepth;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTimer), 0.0f, 1.0f);
        mouseInteractions = GetComponentInParent<MouseInteractions>();

        roomWidth /= 2.0f;
        roomDepth /= 2.0f;

        Vector3 randomPos = new Vector3(Random.Range(-roomWidth, roomWidth), 0.0f, Random.Range(-roomDepth, roomDepth));

        Key key = Instantiate(chestPrefab, randomPos, chestPrefab.transform.rotation).GetComponentInChildren<Key>();

        int randomRoomSide = Random.Range(0, 4);

        Door door = null;

        Quaternion rotation = Quaternion.identity;

        switch (randomRoomSide)
        {
            case 0:
                // top side
                randomPos = new Vector3(Random.Range(-roomWidth, roomWidth), 0.0f, roomDepth);
                rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                break;

            case 1:
                // bottom side
                randomPos = new Vector3(Random.Range(-roomWidth, roomWidth), 0.0f, -roomDepth);
                rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                break;
            case 2:
                // left side
                randomPos = new Vector3(-roomWidth, 0.0f, Random.Range(-roomDepth, roomDepth));
                break;
            case 3:
                // top side
                randomPos = new Vector3(roomWidth, 0.0f, Random.Range(-roomDepth, roomDepth));
                rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                break;
        }

        door = Instantiate(doorPrefab, randomPos, rotation).GetComponent<Door>();

        key.door = door;
    }

    private void UpdateTimer()
    {
        currentTime++;

        currentTimeText.text = "Time: " + currentTime;
    }

    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);

        mouseInteractions.InteractableChosen = null;
    }

    public void UseInteractable(GameObject panel)
    {
        var interactable = mouseInteractions.InteractableChosen;

        if (interactable)
        {
            interactable.Interact();
        }

        panel.SetActive(false);
    }    

    public void FinishGame()
    {
        CancelInvoke(nameof(UpdateTimer));

        if (currentTime < PlayerPrefs.GetFloat("BestTime") || PlayerPrefs.GetFloat("BestTime") == 0)
        {
            PlayerPrefs.SetFloat("BestTime", currentTime);
        }

        gameOverPanel.SetActive(true);

        bestTimeText.text = "Best time: " + PlayerPrefs.GetFloat("BestTime");
        timeText.text = "Your time: " + currentTime;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
