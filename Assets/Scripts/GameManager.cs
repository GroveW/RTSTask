using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text currentTimeText;
    private float currentTime = 0.0f;

    private MouseInteractions mouseInteractions;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTimer), 0.0f, 1.0f);
        mouseInteractions = GetComponentInParent<MouseInteractions>();
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
}
