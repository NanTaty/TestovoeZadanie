using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using IsoTools.Physics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool isActive = false;

    private int currentPositionIndex;
    
    [SerializeField] private float moveSpeed;

    private List<Vector3> positionList;

    private IsoObject playerIsoObject;

    private GridPosition _gridPosition;
    
    public Action<PickableObject> OnMoveCompleted;

    private PickableObject _pickableObject;
    // Start is called before the first frame update
    void Start()
    {
        playerIsoObject = GetComponent<IsoObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)
        {
            IsoRaycastHit hit;
            Ray ray = IsoWorld.instance.RayFromIsoCameraToIsoPoint(IsoWorld.instance.MouseIsoPosition(Camera.main));
            if (IsoPhysics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<PickableObject>() != null)
                {
                    _gridPosition = LevelGrid.Instance.GetGridPosition(playerIsoObject.tilePosition);
                    _pickableObject = hit.collider.GetComponent<PickableObject>();

                    List<GridPosition> pathGridPositionList = Pathfinding.Instance.FindPath(_gridPosition,
                        _pickableObject.GetPickableObjectGridPosition());

                    if (pathGridPositionList == null)
                    {
                        return;
                    }
                        
                    currentPositionIndex = 0;
                    positionList = new List<Vector3>();
                    List<PickableObject> pickableObjectsOnWay = new List<PickableObject>();
                    int objectCount = 0;
                    foreach (GridPosition pathGridPosition in pathGridPositionList)
                    {
                        if (LevelGrid.Instance.HasAnyObjectAtGridPosition(pathGridPosition))
                        {
                            pickableObjectsOnWay.Add(LevelGrid.Instance.GetObjectAtGridPosition(pathGridPosition));
                            objectCount++;
                            if (objectCount > 1)
                            {
                                pickableObjectsOnWay[0].TriggerGlow();
                                return;
                            }
                        }
                        positionList.Add(LevelGrid.Instance.GetWorldPosition(pathGridPosition));
                    }

                    isActive = true;
                }
            }
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        if (!isActive)
        {
            return;
        }

        Vector3 targetPosition = positionList[currentPositionIndex];
        Vector3 moveDirection = (targetPosition - playerIsoObject.tilePosition).normalized;

        float stoppingDistance = 0.1f;
        if (Vector3.Distance(playerIsoObject.tilePosition, targetPosition) >= stoppingDistance)
        {
            playerIsoObject.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            currentPositionIndex++;
            if (currentPositionIndex >= positionList.Count)
            {
                OnMoveCompleted?.Invoke(_pickableObject);
                isActive = false;
            }
        }
    }
}
