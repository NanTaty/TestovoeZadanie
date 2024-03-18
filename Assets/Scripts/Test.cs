using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using IsoTools.Examples.Kenney;
using IsoTools.Internal;
using IsoTools.Physics;
using UnityEngine;

public class Test : MonoBehaviour
{
    private GridPosition _gridPosition;
    [SerializeField] private int x, y;

    private void Awake()
    {
    }

    private void Start()
    {
        _gridPosition = new GridPosition(x, y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(LevelGrid.Instance.HasAnyObjectAtGridPosition(_gridPosition) + ": " + _gridPosition);
        }
    }
}
