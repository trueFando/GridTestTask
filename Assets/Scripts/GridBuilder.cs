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
        GenerateGrid(gridSize);
    }

    private void GenerateGrid(Vector2Int gridSize)
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject newCell = Instantiate(cell);
                newCell.GetComponent<RectTransform>().SetParent(transform, false);
                float posX = (gridAreaSize.x / gridSize.x) * x + (gridAreaSize.x / gridSize.x) * 0.5f;
                float posY = (gridAreaSize.y / gridSize.y) * y + (gridAreaSize.y / gridSize.y) * 0.5f;
                newCell.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
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
