using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private GridPosition pickableObjectGridPosition;

    private IsoObject pickableIsoObject;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        pickableIsoObject = GetComponent<IsoObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        pickableObjectGridPosition = LevelGrid.Instance.GetGridPosition(pickableIsoObject.tilePosition);
        
        LevelGrid.Instance.AddObjectAtGridPosition(pickableObjectGridPosition, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GridPosition GetPickableObjectGridPosition()
    {
        return pickableObjectGridPosition;
    }

    private void OnDestroy()
    {
        LevelGrid.Instance.RemoveObjectAtGridPosition(pickableObjectGridPosition, this);
    }

    public void TriggerGlow()
    {
        _animator.SetTrigger("glow");
    }
}
