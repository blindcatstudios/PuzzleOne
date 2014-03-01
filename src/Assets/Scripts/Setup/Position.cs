using UnityEngine;
using System.Collections;

public static class Position 
{
	const float closedDiff = 32f;
	const float openDiff = 80;

	public static TogglePositions PositionsFromRadial(float radialPosition, float maxOpenOffset = 15f)
	{
		float x = Mathf.Cos(radialPosition * Mathf.Deg2Rad);
		float y = Mathf.Sin(radialPosition * Mathf.Deg2Rad);

		var closedPosition = new Vector3(0f + (x * closedDiff),0f + (y * closedDiff),0f);
        var max = FindMaxOpen(openDiff, x, y) - maxOpenOffset;
		var openPosition = new Vector3(0f + (x * max),0f + (y * max),0f);

		return new TogglePositions(closedPosition, openPosition);
	}

    

	public static float FindMaxOpen(float maxOpen, float x, float y, float distanceFromCamera = 300f)
	{
        Vector3 v3ViewPort = new Vector3(0, 0, distanceFromCamera);
		Vector3 v3BottomLeft = Camera.main.ViewportToWorldPoint(v3ViewPort);
		v3ViewPort.Set(1,1,300);
		Vector3 v3TopRight = Camera.main.ViewportToWorldPoint(v3ViewPort);

		//Hack to not have toggles so far on the outside left/right
		var width = (Mathf.Abs(v3BottomLeft.x) + Mathf.Abs(v3TopRight.x));
		width = width - ( width / 6f );

		var bounds = new Bounds(new Vector3(),new Vector3(width,Mathf.Abs(v3BottomLeft.y) + Mathf.Abs(v3TopRight.y),10f));
		var currentPosition = new Vector3();
		float currentDiff = closedDiff;
		var max = 1000;
		var current = 0;
		do {
			currentPosition = new Vector3(0f + (x * currentDiff),0f + (y * currentDiff),0f);
			currentDiff++;
			current++;
		} while (bounds.Contains(currentPosition) || current>max);
		return currentDiff;
	}
}

public class TogglePositions 
{
	public Vector3 ClosedPosition;
	public Vector3 OpenPosition;

	public TogglePositions(Vector3 closedPosition, Vector3 openPosition)
	{
		ClosedPosition = closedPosition;
		OpenPosition = openPosition;
	}
}
