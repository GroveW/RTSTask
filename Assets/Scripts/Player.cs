using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool hasKey = false;

    public bool HasKey { get => hasKey; }

    [SerializeField]
    private Image keyImg;
    [SerializeField]
    private Sprite keySprite;

    public void TakeKey()
    {
        hasKey = true;

        keyImg.sprite = keySprite;
    }
}
