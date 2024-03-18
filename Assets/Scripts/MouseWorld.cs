using System.Collections;
using System.Collections.Generic;
using IsoTools;
using IsoTools.Physics;
using UnityEngine;

//Test click
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;

    private IsoWorld _isoWorld;

    private void Awake()
    {
        instance = this;
        _isoWorld = GetComponent<IsoWorld>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the game world
            Ray ray = _isoWorld.RayFromIsoCameraToIsoPoint(_isoWorld.MouseIsoPosition(Camera.main));
            Vector3 clickedTile = _isoWorld.MouseIsoTilePosition(Camera.main);
            Debug.Log("Mouse clicked on tile: " + clickedTile);
            IsoRaycastHit hit;
            if(IsoPhysics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    // Perform actions based on the object hit
                    GameObject objectHit = hit.collider.gameObject;
                    Debug.Log("Mouse clicked on: " + objectHit.name);
                }
            }
        }
    }
}
