using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable : MonoBehaviour
{
    private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    public Color ColorApplyer;

    [SerializeField]
    private InputAction mouseHover;

    private void Awake()
    {
        meshRenderers.AddRange(GetComponentsInChildren<MeshRenderer>());
    }
}
