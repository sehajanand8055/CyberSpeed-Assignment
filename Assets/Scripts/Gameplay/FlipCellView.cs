using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FlipCellView : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;

    private int uniqueId;
    private CardMatchingView cardMatchingView;
    private Sprite revealSprite;

    public void InitCell(int id, Sprite sprite, Transform parent)
    {
        Debug.Log("Cell instantiated");
        uniqueId = id;
        revealSprite = sprite;
        transform.SetParent(parent);
        SetCardMatcher();
    }

    public void SetCardMatcher()
    {
        cardMatchingView = DependencyHandler.Instance.GetService<CardMatchingView>();
        button.onClick.AddListener(ListenButton);
    }

    public void DissapearCell()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    public void ListenButton()
    {
        if (!cardMatchingView.ShouldFlipCard())
            return;

        cardMatchingView.OnCardFlipped(this);
        image.sprite = revealSprite;
    }

    public void Reset(Sprite whiteSprite)
    {
        Debug.Log("reset cells");
        image.sprite = whiteSprite;
    }

    public IEnumerator FlipAnimation(Action onComplete)
    {
        yield break;
    }

}
