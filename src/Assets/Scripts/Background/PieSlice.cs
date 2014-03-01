using System.Collections.Generic;
using UnityEngine;

public static class PieSlice
{
    const float spaceBetween = 11f;
    const int number = 15;
    static Object m_PaintObject;

    static PieSlice()
    {
        m_PaintObject = Resources.Load("bgSphere", typeof(GameObject));    
    }

    public static IEnumerable<GameObject> CreatePaintSliceNormal(float centerRadial, float distance, int colorID, float delay = 0f)
    {
        var radialStart = centerRadial - (distance / 2f);
        var radialEnd = centerRadial + (distance / 2f);
        var gameObjects = new List<GameObject>();

        for (float y = radialStart; y < radialEnd; y += spaceBetween / 3.3f) //radial
        {
            float xx = Mathf.Cos(y * Mathf.Deg2Rad);
            float yy = Mathf.Sin(y * Mathf.Deg2Rad);
            float max = FindMaxOpen(centerRadial, xx, yy, (Mathf.Abs(Camera.main.transform.localPosition.z) - 20f)) + 10f;
            for (float i = 0; i < max + spaceBetween ; i += spaceBetween) //distance
            {
                gameObjects.Add(CreateSphere(m_PaintObject, y, i, delay, colorID));
            }
        }

        return gameObjects;
    }

    public static IEnumerable<GameObject> CreatePaintSliceDual(float centerRadial, float distance, int colorID1, int colorID2, float delay = 0f)
    {
        var radialStart = centerRadial - (distance / 2f);
        var radialEnd = centerRadial + (distance / 2f);
        var gameObjects = new List<GameObject>();
        for (float y = radialStart; y < radialEnd; y += spaceBetween / 3.3f) //radial
        {
            float xx = Mathf.Cos(y * Mathf.Deg2Rad);
            float yy = Mathf.Sin(y * Mathf.Deg2Rad);
            float max = FindMaxOpen(centerRadial, xx, yy, (Mathf.Abs(Camera.main.transform.localPosition.z) - 20f)) + 10f;
            for (float i = 0; i < max + spaceBetween; i += spaceBetween) //distance
            {
                gameObjects.Add(CreateSphere(m_PaintObject, y, i, delay, i > (max + spaceBetween) * 0.5f ? colorID2 : colorID1));
            }
        }

        return gameObjects;
    }

    private static float FindMaxOpen(float maxOpen, float x, float y, float distanceFromCamera = 300f)
    {
        Vector3 v3ViewPort = new Vector3(0, 0, distanceFromCamera);
        Vector3 v3BottomLeft = Camera.main.ViewportToWorldPoint(v3ViewPort);
        v3ViewPort.Set(1, 1, 300);
        Vector3 v3TopRight = Camera.main.ViewportToWorldPoint(v3ViewPort);
        
        var width = (Mathf.Abs(v3BottomLeft.x) + Mathf.Abs(v3TopRight.x));

        var bounds = new Bounds(new Vector3(), new Vector3(width, Mathf.Abs(v3BottomLeft.y) + Mathf.Abs(v3TopRight.y), 10f));
        var currentPosition = new Vector3();
        float currentDiff = 0;
        var max = 1000;
        var current = 0;
        do
        {
            currentPosition = new Vector3(0f + (x * currentDiff), 0f + (y * currentDiff), 0f);
            currentDiff++;
            current++;
        } while (bounds.Contains(currentPosition) || current > max);
        
        return currentDiff;
    }

    private static GameObject CreateSphere(Object obj, float y, float i, float x, int ID, bool changeColor = false)
    {
        var sphere = (GameObject)Object.Instantiate(obj);

        sphere.renderer.material.color = ColorID.DefaultBackgroundColor[ID];
        if (changeColor)
            sphere.renderer.material.color = ColorID.DefaultBackgroundColor[ColorID.Blue];
        sphere.transform.localPosition = new Vector3(0, 0, 60f);
        float size = Random.Range(5f, 8f);
        sphere.transform.localScale = new Vector3(size, size, size);
        var endingLocation = RadialToCoordinate(y, i);
        sphere.StartAutoTween(sphere.transform.localPosition, endingLocation, Random.Range(0.6f, 3.2f), EasingType.outElasticBig, x + (i / 50f));//, () => Floating.AttachToGameObject(sphere, offset)); outElasticBig
        return sphere;
    }

    public static void CreatePieSliceNormal(float radial, int total, int colorID)
    {

        var radialOne = radial - (360f / total / 2f);
        var radialTwo = radial + (360f / total / 2f);

        var startVectorLeft = RadialToCoordinate(radialOne, 0);
        var startVectorRight = RadialToCoordinate(radialTwo, 0);
        var endVectorLeft = RadialToCoordinate(radialOne, 200);
        var endVectorRight = RadialToCoordinate(radialTwo, 200);

        VLiner.CreateDottedLine(startVectorLeft, endVectorLeft);
        VLiner.CreateDottedLine(startVectorRight, endVectorRight);
        
        //var backgroundColorSlice = new GameObject();
        var backgroundColorSlice = GameObject.CreatePrimitive(PrimitiveType.Plane);


        var mat = (Material)Resources.Load("slice", typeof(Material));
        //backgroundColorSlice.AddComponent(typeof(MeshRenderer));
        //backgroundColorSlice.renderer.material = mat;

        backgroundColorSlice.transform.localPosition = new Vector3(0, 0, 20);
        Vector2[] vertices2D = new Vector2[] {
            new Vector2(),
            endVectorLeft,
            endVectorRight
        };
        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        backgroundColorSlice.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = backgroundColorSlice.GetComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;
        filter.renderer.material = mat;

		backgroundColorSlice.renderer.material.color = ColorID.DefaultBackgroundColor[colorID];//new Color(250f/255f,190f/255f,192f/255f);
    }

    private static Vector3 RadialToCoordinate(float radial, float distance)
    {
        float x = Mathf.Cos(radial * Mathf.Deg2Rad);
        float y = Mathf.Sin(radial * Mathf.Deg2Rad);

        return new Vector3(0f + (x * distance), 0f + (y * distance), 20f);
    }
}
