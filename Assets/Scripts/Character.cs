using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _characterController.OnMoveCompleted += OnMoveCompleted;
    }

    private void OnMoveCompleted(PickableObject obj)
    {
        Destroy(obj.gameObject, 1f);
    }
}
