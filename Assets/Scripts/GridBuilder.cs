using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private GameObject cell;

    [SerializeField] private InputField widthInputField;
    [SerializeField] private InputField heightInputField;

    private Vector2 gridAreaSize; // размер пространства на экране, в которое вписываем сетку

    private Text[,] gridOfLetters;

    private void Start()
    {
        gridAreaSize = GetGridAreaSize();
        GetComponent<RectTransform>().sizeDelta = gridAreaSize;
    }

    private void SetGridSize()
    {
        int width, height;
        int.TryParse(widthInputField.text, out width);
        int.TryParse(heightInputField.text, out height);
        gridSize.x = width;
        gridSize.y = height;
    }

    public void GenerateGrid()
    {
        ClearGrid();
        SetGridSize();
        gridOfLetters = new Text[gridSize.x, gridSize.y];
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                GameObject newCell = Instantiate(cell);
                newCell.GetComponent<RectTransform>().SetParent(transform, false);
                float posX = (gridAreaSize.x / gridSize.x) * x + (gridAreaSize.x / gridSize.x) * 0.5f;
                float posY = (gridAreaSize.y / gridSize.y) * y + (gridAreaSize.y / gridSize.y) * 0.5f;
                newCell.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY);
                gridOfLetters[x, y] = newCell.GetComponent<Text>();
            }
        }
        GridFiller.FillWithRandomLetters(gridOfLetters);
    }

    public void MixGrid()
    {
        print("works");
        Vector3[,] newPositions = GridFiller.GetNewPositions(gridOfLetters);
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                gridOfLetters[x, y].GetComponent<LetterMovement>().StartMovement(newPositions[x, y]);
            }
        }
    }

    private Vector2 GetGridAreaSize()
    {
        float shareOfGridSpaceY = 0.7f; // часть высоты экрана, зан€та€ сеткой
        float height = Camera.main.pixelHeight * shareOfGridSpaceY;
        float width = Camera.main.pixelWidth;

        return new Vector2(width, height);
    }

    private void ClearGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Destroy(gridOfLetters[x, y].gameObject);
            }
        }
        gridOfLetters = null;
    }
}
