using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class GridFiller 
{
    private readonly static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public static void FillWithRandomLetters(Text[,] grid)
    {
        int xLen = grid.GetLength(0), yLen = grid.GetLength(1); 
        for (int x = 0; x < xLen; x++)
        {
            for (int y = 0; y < yLen; y++)
            {
                grid[x, y].text = GetRandomLetter().ToString();
            }
        }
    }

    public static Vector3[,] GetNewPositions(Text[,] grid)
    {
        Vector3[,] newPositions = new Vector3[grid.GetLength(0), grid.GetLength(1)];
        int xLen = grid.GetLength(0), yLen = grid.GetLength(1);

        for (int x = xLen -1; x > 0; x--)
        {
            for (int y = yLen -1; y > 0; y--)
            {
                int m = Random.Range(0, x + 1);
                int n = Random.Range(0, y + 1);

                Text temp = grid[x, y];
                grid[x, y] = grid[m, n];
                grid[m, n] = temp;
            }
        }

        for (int x = 0; x < xLen; x++)
        {
            for (int y = 0; y < yLen; y++)
            {
                newPositions[x, y] = grid[x, y].GetComponent<RectTransform>().anchoredPosition;
            }
        }

        return newPositions;
    }

    private static char GetRandomLetter()
    {
        return letters[Random.Range(0, letters.Length)];
    }
}