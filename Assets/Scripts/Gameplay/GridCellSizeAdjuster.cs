using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCellSizeAdjuster : HandlerService
{
    private RectTransform targetArea;  // Assign the panel RectTransform here

    private GridLayoutGroup gridLayoutGroup;


    public override void Initialize()
    {
        DependencyHandler.Instance.RegisterDependency<GridCellSizeAdjuster>(this);
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        targetArea = GetComponent<RectTransform>();
    }

    public override void MakeRegistrations()
    {

    }

    public void UpdateCellSize()
    {
        float targetWidth = targetArea.rect.width;
        float targetHeight = targetArea.rect.height;

        int childCount = transform.childCount;

        int columns = Mathf.CeilToInt(Mathf.Sqrt(childCount));
        int rows = Mathf.CeilToInt((float)childCount / columns);

        float cellWidth = (targetWidth - (columns - 1) * gridLayoutGroup.spacing.x - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right) / columns;
        float cellHeight = (targetHeight - (rows - 1) * gridLayoutGroup.spacing.y - gridLayoutGroup.padding.top - gridLayoutGroup.padding.bottom) / rows;

        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}

