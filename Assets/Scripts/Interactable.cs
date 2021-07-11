using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    public Color ColorApplyer;

    [SerializeField]
    protected string actionDescription;

    private GameObject actionPanel;
    private GameObject restrictionPanel;
    private Text actionDescriptionText;

    private bool used = false;

    [SerializeField]
    private bool isRestricted = false;
    protected bool restrictionsMet = false;

    private void Awake()
    {
        meshRenderers.AddRange(GetComponentsInChildren<MeshRenderer>());
        actionPanel = GameObject.Find("ActionPanel");
        restrictionPanel = GameObject.Find("InfoPanel");
        actionDescriptionText = actionPanel.GetComponentInChildren<Text>();
    }

    public void SetEnabled()
    {
        if (used)
            return;

        foreach (var ren in meshRenderers)
        {
            ren.material.color += ColorApplyer;
        }
    }

    public void SetDisabled()
    {
        if (used)
            return;

        foreach (var ren in meshRenderers)
        {
            ren.material.color -= ColorApplyer;
        }
    }

    public void ShowPanel()
    {
        if (used)
            return;

        if (!isRestricted || restrictionsMet)
        {
            actionDescriptionText.text = actionDescription;
            actionPanel.SetActive(true);
        }
        else
        {
            restrictionPanel.SetActive(true);
        }
    }

    public virtual void Interact()
    {
        if (isRestricted && !restrictionsMet)
            return;

        if (used)
            return;

        used = true;
    }
}
