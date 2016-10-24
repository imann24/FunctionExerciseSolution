/*
 * Author(s): Isaiah Mann
 * Description: Controls a cube in the CubeGrid
 */

using UnityEngine;

public class CubeBehaviour : MonoBehaviour {
	// Determines how much the cube grows by each time it's clicked
	float growFactor = 2.0f;

	// A reference to the CubeController script
	CubeController controller;

	// An index of the current cube color, -1 by default
	int colorIndex = -1;

	// Set by the controller, tells the cube how many colors there are in the array
	int colorCount;

	// Tracks how many times the cube's been clicked since it last grew
	int clickCountSinceGrowth = 0;

	// A reference to the Cube's Renderer (can be used to set its color)
	Renderer colorer;

	void Start () {
		// Sets the reference to the Cube's Renderer
		colorer  = GetComponent<Renderer>();
	}

	// Used to assign the controller and the colorCount
	public void SetController (CubeController controller, int colorCount) {
		this.controller = controller;
		this.colorCount = colorCount;
	}

	// Called when the cube is clicked on
	void OnMouseDown () {
		// Increase the cube's color index
		colorIndex++;

		// Modulus function to keep the color index from getting out of range
		// More info about modulus: https://msdn.microsoft.com/en-us/library/0w4e0fzs.aspx
		colorIndex %= colorCount;

		// Adds one to the click count
		clickCountSinceGrowth++;

		// Sets the color based on what value the controller returns
		colorer.material.color = controller.GetCubeColor(colorIndex);

		// Checks whether the cube should grow
		if (controller.CubeShouldGrow(clickCountSinceGrowth)) {
			// Calls the cube's grow function
			Grow();

			// Reset the cube's click count
			clickCountSinceGrowth = 0;
		}
	}

	// Makes the cube grow by increasing its scale
	void Grow () {
		transform.localScale *= growFactor;
	}
}
