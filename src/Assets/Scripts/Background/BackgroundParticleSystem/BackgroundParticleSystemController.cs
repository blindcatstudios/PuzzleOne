using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class BackgroundParticleSystemController
{
    const int number = 15;

	private static List<GameObject> gameObjects = new List<GameObject>();

    private static GameObject CreateSphere(Object obj, float y, float i, float x, int ID, bool changeColor = false)
    {
        var sphere = (GameObject)Object.Instantiate(obj);

        //var lerpedColor = Color.Lerp(Color.white, ColorID.DefaultBackgroundColor[ID], 1f);//i / number / 4f);
        sphere.renderer.material.color = ColorID.DefaultBackgroundColor[ID];
        if (changeColor)
            sphere.renderer.material.color = ColorID.DefaultBackgroundColor[ColorID.Blue];
        sphere.transform.localPosition = new Vector3(0, 0, 10f);
        float size = Random.Range(5f, 8f);
        sphere.transform.localScale = new Vector3(size, size, size);
        var endingLocation = RadialToCoordinate(y, i);
		sphere.StartAutoTween(sphere.transform.localPosition, endingLocation, Random.Range(0.6f, 3.2f), EasingType.outElasticBig, x + (i / 50f));//, () => Floating.AttachToGameObject(sphere, offset)); outElasticBig
        return sphere;
    }

    public static void StartBackground()
    {
        //foreach (var item in gameObjects)
        //{
        //    Object.Destroy(item);
        //}
        //gameObjects.Clear();

        
        //Stopwatch watch = new Stopwatch();

        //watch.Start();
        //gameObjects.AddRange(PieSlice.CreatePaintSliceNormal(20f, 40f, ColorID.Blue));
        
        //var spaceBetween = 11f;
        //var color = 0;
        //for (int x = 0; x < 360; x+=40) //slice
        //{
        //    for (float y = x; y < x + 40; y += spaceBetween / 3.3f) //radial
        //    {
        //        for (float i = 0; i < Vector3.Distance(new Vector3(), Position.PositionsFromRadial(y).OpenPosition); i += spaceBetween) //distance
        //        {
        //            if (i > number * spaceBetween * 0.4f && x==40)
        //                gameObjects.Add(CreateSphere(obj, y, i, x / 80f, ColorID.Blue));
        //            else
        //                gameObjects.Add(CreateSphere(obj, y, i, x / 80f, color));
        //        }
        //    }
        //    color++;
        //    if (color > 2)
        //        color = 0;
        //}
        //Debug.Log("elapsed " + watch.ElapsedMilliseconds);
        //watch.Stop();
    }

    private static Vector3 RadialToCoordinate(float radial, float distance)
    {
        float x = Mathf.Cos(radial * Mathf.Deg2Rad);
        float y = Mathf.Sin(radial * Mathf.Deg2Rad);
        
        return new Vector3(0f + (x * distance), 0f + (y * distance), 40f);
    }
}
