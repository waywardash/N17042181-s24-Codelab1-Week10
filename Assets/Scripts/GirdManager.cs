using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdManager : MonoBehaviour
{
    public Sprite sprite; // spritefor the grid tiles
    public float[,] Grid; // 2D array to store the grid values
    private int Vertical, Horizontal, Columns, Rows; // Variables to determine grid size
    
    // Start is called before the first frame update
    void Start()
    {
        // Calculate the vertical size of the grid based on the camera's orthographic size
        Vertical = (int)Camera.main.orthographicSize;
        // Calculate the horizontal size of the grid based on the vertical size and screen aspect ratio
        Horizontal = Vertical * (Screen.width / Screen.height);
        // Calculate the total number of columns in the grid
        Columns = Horizontal * 2;
        // Calculate the total number of rows in the grid
        Rows = Vertical * 2;
        // Initialize the grid with the calculated size
        Grid = new float[Columns, Rows];

        // Loop through each cell in the grid
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                // Generate a random value for the current grid cell
                Grid[i, j] = Random.Range(0, 10);
                // Spawn a tile at the current grid cell position with the generated value
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    // Function to spawn a tile at the specified grid position with the given value
    private void SpawnTile(int x, int y, float value)
    {
        // new GameObject for the tile
        GameObject g = new GameObject("x: " + x + "y: " + y);
        // Set the position of the tile based on its grid coordinates
        g.transform.position = new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
        // Add a SpriteRenderer component to the tile GameObject
        var s = g.AddComponent<SpriteRenderer>();
        // Set the sprite of the SpriteRenderer to the specified sprite
        s.sprite = sprite;
        // Set the color of the sprite based on the value of the grid cell
        s.color = new Color(value, value, value);
    }
}
