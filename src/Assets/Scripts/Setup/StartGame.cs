using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public GameObject[] DummyObjects;

	public GameObject prefabNormal;
    private const int dumbNumberOfToggles = 12;

	void Start ()
	{
	    //DummyObjects[DummyObjects.Length - 1].InitializeDual(ColorID.Purple);
		int randomStart = Random.Range(10,340);
		bool oneDual = false;
		bool twoDual = false;
		int previousColor = -1;
	    int delay = 0;
	    int i;
        for (i = randomStart; i < randomStart + 319; i += 360 / dumbNumberOfToggles)
        {
			if (oneDual) 
			{
				oneDual = false;
				var dualObject = (GameObject)Instantiate(prefabNormal);
				int dualColor;
				dualColor = ColorID.Green;
				
				dualObject.InitializeDual(dualColor, i, TogglePosition.Closed);
                PieSlice.CreatePaintSliceNormal(i, 360f / dumbNumberOfToggles, ColorID.Green, delay / 2f);
				continue;
			}
			if (!oneDual && twoDual){
				twoDual = false;
				var dualObject = (GameObject)Instantiate(prefabNormal);
				int dualColor;
				dualColor = ColorID.Purple;
				
				dualObject.InitializeDual(dualColor, i, TogglePosition.Open);
                //dualObject.GrabToggle().CurrentZone = new LockedZone(2);
                //((LockedZone)dualObject.GrabToggle().CurrentZone).DrawZone(dualObject.GrabDual().PositionOpened);
                PieSlice.CreatePaintSliceNormal(i, 360f / dumbNumberOfToggles, ColorID.Purple, delay / 2f);
				continue;
			}
            var gameObject = (GameObject)Instantiate(prefabNormal);
			int color;
			do {
				color = ColorID.RandomPrimaryColor();
			} while (previousColor == color);
			previousColor = color;

            gameObject.InitializeNormal(color, i, TogglePosition.Closed);
            PieSlice.CreatePaintSliceNormal(i, 360f / dumbNumberOfToggles, color, delay / 2f);
            delay++;
        }

        var gameObject2 = (GameObject)Instantiate(prefabNormal);
        int color2;
        do
        {
            color2 = ColorID.RandomPrimaryColor();
        } while (previousColor == color2 || color2 == ColorID.Red);
	    //Debug.Log("gbjwbgjwt " + color2);
        gameObject2.InitializeNormal(color2, i, TogglePosition.Open);
	    gameObject2.GrabToggle().CurrentZone = new DualColorZone(color2, ColorID.Red);
        PieSlice.CreatePaintSliceDual(i, 360f / dumbNumberOfToggles, color2,ColorID.Red, delay / 2f);
	    
	    VLiner.DrawCircle();
	}

    public void PressRandom()
    {
        Controller.ToggleRandom();
    }

    // Update is called once per frame
	void Update () {
	
	}
}
