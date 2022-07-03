using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private GameObject cell;

    public Vector2Int GridSize 
    { 
        get => gridSize; 
    }

    private Vector2 gridAreaSize; // размер пространства на экране, в которое вписываем сетку

    private void Start()
    {
        gridAreaSize = GetGridAreaSize();
        gridSize = new Vector2Int(2, 2);
        GenerateGrid(gridSize);
    }

    private void GenerateGrid(Vector2Int gridSize)
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject newCell = Instantiate(cell);
                newCell.transform.parent = transform;
                newCell.transform.localScale = Vector3.one;
                newCell.transform.localPosition = new Vector3(x * (gridAreaSize.x / gridSize.x), y * (gridAreaSize.y / gridSize.y), 0);
            }
        }
    }

    private Vector2 GetGridAreaSize()
    {
        float height = Camera.main.pixelHeight * 0.7f;
        float width = Camera.main.pixelWidth;

        return new Vector2(width, height);
    }
}
