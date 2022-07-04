using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class GridFiller 
{
    private readonly static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public static void FillWithRandomLetters(Text[,] grid, int xLen, int yLen)
    {
        for (int x = 0; x < xLen; x++)
        {
            for (int y = 0; y < yLen; y++)
            {
                grid[x, y].text = GetRandomLetter().ToString();
            }
        }
    }

    private static char GetRandomLetter()
    {
        return letters[Random.Range(0, letters.Length)];
    }
}