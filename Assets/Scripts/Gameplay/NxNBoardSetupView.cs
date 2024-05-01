using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NxNBoardSetupView : HandlerService
{
    [SerializeField] private FlipCellView flipCellViewPrefab;

    [Tooltip("keep the id unique for all the cells to differentiate them")]
    [SerializeField] private List<FlipCellVariant> flipCells;

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

    public void InitializeBoard(int rows, int columns)
    {
        modeSelectionHandler.gameObject.SetActive(false);
        gameObject.SetActive(true);
        Debug.Log($"Intialize board {rows} , {columns}");
    }
}

[Serializable]

public class FlipCellVariant
{
    public int id;
    public Sprite sprite;
}
