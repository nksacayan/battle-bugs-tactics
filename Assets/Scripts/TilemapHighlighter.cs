using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHighlighter
{
    private Tilemap highlightMap;
    private Tile highlightTile;

    public TilemapHighlighter(Tilemap highlightMap, Tile highlightTile)
    {
        this.highlightMap = highlightMap;
        this.highlightTile = highlightTile;
    }

    // Uses BFS to highlight all tiles within a radius of a starting position
    public void HighlightMovement(Vector2 startPosition, int range)
    {
        Queue<Vector2> frontier = new Queue<Vector2>();
        HashSet<Vector2> visited = new HashSet<Vector2>();
        Vector2[] directionVectors = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        frontier.Enqueue(startPosition);

        // BFS only as far as movement range
        for (int i = 0; i <= range; i++)
        {
            // Loop once for each radius
            int numNodes = frontier.Count;
            for (int j = 0; j < numNodes; j++)
            {
                Vector2 currentPosition = frontier.Dequeue();

                // Highlight current
                HighlightTileAtWorldPosition(currentPosition);
                
                // Loop through directions to search adjacent
                foreach (Vector2 directionVector in directionVectors)
                {
                    Vector2 searchVector = currentPosition + directionVector;
                    if (!visited.Contains(searchVector))
                    {
                        frontier.Enqueue(searchVector);
                    }
                }

                visited.Add(currentPosition);
            }
        }
    }

    public void ClearMovementHighlight()
    {
        highlightMap.ClearAllTiles();
    }

    public void RefreshMovementHighlight(Vector2 position, int range)
    {
        ClearMovementHighlight();
        HighlightMovement(position, range);
    }

    private void SetTileAtWorldPosition(Vector2 worldPosition, Tilemap tilemap, Tile tile)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        tilemap.SetTile(cellPosition, tile);
    }

    private void HighlightTileAtWorldPosition(Vector2 worldPosition)
    {
        Vector3Int cellPosition = highlightMap.WorldToCell(worldPosition);
        highlightMap.SetTile(cellPosition, highlightTile);
    }

}
