/*
 * Author(s): Isaiah Mann
 * Description: Creates an interactable grid of cubes
 */

using UnityEngine;

public class CubeController : MonoBehaviour {
	// Determines how many cubes are created
	// To be set in the Inspector
	public int gridWidth = 10;
	public int gridHeight = 10;

	// A 2D Array to store the cubes
	GameObject[,] grid;

	// How many colors there are
	int colorCount = 6;

	// Use this for initialization
	void Start () {
		// Initializes the array of cubes
		grid = new GameObject[gridWidth, gridHeight];

		// Creates the cubes in a nested cor loop
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				// Calls the CreateCubeAtPosition function
				grid[x, y] = CreateCubeAtPosition(x - gridWidth / 2 + 0.5f, y - gridHeight / 2 + 1.5f, 0);
			}
		}
	}

	GameObject CreateCubeAtPosition (float x, float y, float z) {
		// Creates a cube
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Sets the parent of the cube to this gameObject
		cube.transform.SetParent(transform);

		//Adds a script to make the cube clickable
		cube.AddComponent<CubeBehaviour>().SetController(this, colorCount);

		// Sets the cubes position to equal the three floats passed in
		cube.transform.position = new Vector3(x, y, z);

		// Returns the cube that was just created
		return cube;
	}

	public Color GetCubeColor (int colorIndex) {
		// Creats an array of cube colors
		Color[] colors = new Color[colorCount];

		// Checks if the colorIndex is in the range of the array
		if (colorIndex >= 0 && colorIndex < colors.Length) {
			// Sets the colors in the array
			colors[0] = Color.red;
			// Sets color to orange (halfway between red and yellow)
			colors[1] = Color.Lerp(Color.red, Color.yellow, 0.5f);
			colors[2] = Color.yellow;
			colors[3] = Color.green;
			colors[4] = Color.blue;
			colors[5] = Color.magenta;

			// Returns the color at the matching index
			return colors[colorIndex];
		} else {
			// Returns black if the color index is invalid
			return Color.black;
		}
	}

	// Checks whether the cube should grow based on how many times it's been clicked 
	public bool CubeShouldGrow (int clickCount) {
		// Checks if the click count is larger than the colorCount
		if (clickCount > colorCount) {
			return true;
		} else {
			return false;
		}
	}
}
