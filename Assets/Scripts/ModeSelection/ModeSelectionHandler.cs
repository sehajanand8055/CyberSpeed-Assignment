using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectionHandler : HandlerService
{
    [SerializeField] private Button startGameButton;

    public Action<int, int> OnModeSelected;

    public override void Initialize()
    {
        DependencyHandler.Instance.RegisterDependency<ModeSelectionHandler>(this);
    }
    // Start is called before the first frame update
    public override void MakeRegistrations()
    {
        var modeSelectViews = GetComponentsInChildren<ModeSelectView>();

        var modeselection = DependencyHandler.Instance.GetService<ModeSelectionHandler>();
        Debug.Log($"mode selection is {modeselection.gameObject}");

        startGameButton.onClick.AddListener(() =>
        {
            OnModeSelected?.Invoke(5, 6);
        });
    }


}
