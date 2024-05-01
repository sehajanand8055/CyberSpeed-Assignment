using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardMatchingView : HandlerService
{
    [SerializeField] private Sprite whiteImage;
    private Stack<int> cardStack;

    private List<FlipCellView> flipCellViews;
    private int cardMatches = 0;

    private int currentCardFlippedCount = 0;
    public override void Initialize()
    {
        cardStack = new Stack<int>();
        flipCellViews = new List<FlipCellView>();
        Debug.Log("registered matching view ");
        DependencyHandler.Instance.RegisterDependency<CardMatchingView>(this);
    }

    public override void MakeRegistrations()
    {

    }

    public bool ShouldFlipCard()
    {
        return currentCardFlippedCount < 2;
    }

    public void OnCardFlipped(FlipCellView flipCellView)
    {
        currentCardFlippedCount++;
        flipCellViews.Add(flipCellView);
        if (currentCardFlippedCount == 2)
        {
            CheckForCardMatch(flipCellView);
        }
    }

    private void CheckForCardMatch(FlipCellView flipCellView)
    {
        Debug.Log($"distinct count {flipCellViews.Distinct().Count()}");
        var cardsMatched = flipCellViews[0] == flipCellViews[1];
        StartCoroutine(WaitForSeconds(1f, () =>
        {
            foreach (var cell in flipCellViews)
            {
                cell.Reset(whiteImage);
                if (cardsMatched)
                {
                    cell.DissapearCell();
                }
            }
            if (cardsMatched)
            {
                cardMatches++;
            }
            flipCellViews.Clear();
            currentCardFlippedCount = 0;
        }));
    }


    private IEnumerator WaitForSeconds(float time, Action onComplete)
    {
        yield return new WaitForSeconds(time);
        onComplete?.Invoke();
    }
}
