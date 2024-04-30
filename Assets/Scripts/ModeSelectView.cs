using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeSelectView : MonoBehaviour
{
    [SerializeField] int nRows;
    [SerializeField] int nColumns;

    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI.text = $"{nRows}x{nColumns}";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
