using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem<GridObject> gridSystem;
    private GridPosition gridPosition;
    private List<PickableObject> _pickableObjects;


    public GridObject(GridSystem<GridObject> gridSystem, GridPosition gridPosition)
    {
        this.gridPosition = gridPosition;
        this.gridSystem = gridSystem;
        _pickableObjects = new List<PickableObject>();
    }

    public void AddObject(PickableObject pickableObject)
    {
        _pickableObjects.Add(pickableObject);
    }

    public void RemoveObject(PickableObject pickableObject)
    {
        _pickableObjects.Remove(pickableObject);
    }

    public PickableObject GetObject()
    {
        if (HasAnyObject())
        {
            return _pickableObjects[0];
        }
        else
        {
            return null;
        }
    }

    public bool HasAnyObject()
    {
        return _pickableObjects.Count > 0;
    }
}
