using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using UnityEngine;

//Скрипт который вешается на все тайлы
public class GridTile : MonoBehaviour
{
    [SerializeField] private bool isWalkable;


    private IsoObject gridIsoObject;

    private GridPosition _gridPosition;

    private void Start()
    {
        gridIsoObject = GetComponent<IsoObject>();
        _gridPosition = LevelGrid.Instance.GetGridPosition(gridIsoObject.tilePosition);
        Pathfinding.Instance.SetWalkableGridPosition(_gridPosition, isWalkable);

    }
}
