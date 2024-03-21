using System;
using System.Collections;
using System.Collections.Generic;
using IsoTools;
using IsoTools.Examples.Kenney;
using IsoTools.Internal;
using IsoTools.Physics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    void Start()
    {
        CheckTilePositions();
    }

    void CheckTilePositions()
    {
        BoundsInt bounds = _tilemap.cellBounds;
        TileBase[] allTiles = _tilemap.GetTilesBlock(bounds);

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, bounds.z);
                TileBase tile = allTiles[(x - bounds.xMin) + (y - bounds.yMin) * bounds.size.x];

                if (tile != null)
                {
                    Vector3 worldPos = _tilemap.CellToWorld(cellPos);
                    Debug.Log("Tile at position (" + x + ", " + y + ") has world position: " + worldPos);
                    Debug.Log("Tile vector int pos: " + cellPos);
                }
            }
        }
    }
}
