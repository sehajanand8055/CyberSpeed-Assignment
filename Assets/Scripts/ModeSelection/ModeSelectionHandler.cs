using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectionHandler : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    void Awake()
    {
        DependencyHandler.Instance.RegisterDependency<ModeSelectionHandler>(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        var modeSelectViews = GetComponentsInChildren<ModeSelectView>();

        var modeselection = DependencyHandler.Instance.GetService<ModeSelectionHandler>();
        Debug.Log($"mode selection is {modeselection.gameObject}");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
