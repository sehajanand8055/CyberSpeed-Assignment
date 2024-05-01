using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCellView : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;

    private int uniqueId;

    public void InitCell(int id, Sprite sprite)
    {
        uniqueId = id;
        image.sprite = sprite;
    }
}
