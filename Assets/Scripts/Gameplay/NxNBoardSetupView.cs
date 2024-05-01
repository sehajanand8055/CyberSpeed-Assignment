using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NxNBoardSetupView : HandlerService
{
    [SerializeField] private FlipCellView flipCellViewPrefab;

    [Tooltip("keep the id unique for all the cells to differentiate them")]
    [SerializeField] private List<FlipCellVariant> flipCells;
    [SerializeField] private Transform playGround;

    private ModeSelectionHandler modeSelectionHandler;

    public override void Initialize()
    {
        Debug.Log("Awake of NxN");
        DependencyHandler.Instance.RegisterDependency<NxNBoardSetupView>(this);
    }

    public override void MakeRegistrations()
    {
        Debug.Log($"{this} Intialized");
        modeSelectionHandler = DependencyHandler.Instance.GetService<ModeSelectionHandler>();
        modeSelectionHandler.OnModeSelected += InitializeBoard;
    }

    private void InitializeBoard(int rows, int columns)
    {
        modeSelectionHandler.gameObject.SetActive(false);
        gameObject.SetActive(true);
        SpawnCells(rows * columns);
        GridCellSizeAdjuster gridCellSizeAdjuster = DependencyHandler.Instance.GetService<GridCellSizeAdjuster>();
        gridCellSizeAdjuster.UpdateCellSize();
    }

    private void SpawnCells(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var randomFlipCellVariant = flipCells[UnityEngine.Random.Range(0, flipCells.Count)];
            Instantiate(flipCellViewPrefab).InitCell(randomFlipCellVariant.id, randomFlipCellVariant.sprite, playGround);
        }
    }
}

[Serializable]

public class FlipCellVariant
{
    public int id;
    public Sprite sprite;
}
