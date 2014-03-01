using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class MiniSpheres : MonoBehaviour
{
    List<GameObject> m_List = new List<GameObject>();

    int m_NumberOfSpheres = 18;
	void Start ()
	{
	    this.transform.position = new Vector3();
        for (int i = 0; i < m_NumberOfSpheres; i++)
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            var size = Random.Range(1f, 2.5f);
            sphere.transform.localScale = new Vector3(size, size, size);
            sphere.transform.parent = this.transform;
            sphere.renderer.material.color = Color.red;
            var location = new Vector3();
            var kill = false;
            for (int j = 0; j < 5000; j++)
            {
                location = CalculatePoint(new Vector3());
                if (!TouchingAnotherCircle(location, size / 10f))
                    break;
                if (j > 4800)
                    kill = true;
            }
            sphere.transform.localPosition = location;
            

            if (kill)
                Destroy(sphere);
            else
                m_List.Add(sphere);
        }
        this.transform.position = new Vector3(76, -13, 0);

        foreach (var sphere in m_List)
        {
            Floating.AttachToGameObject(sphere, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));

            //Vector3 Strength = new Vector3(0.5f, 0.5f, 0.5f);
            //float Freq = 0.25f;
            //sphere.AddComponent(typeof(MegaNoise));
            //var noise = (MegaNoise)sphere.GetComponent(typeof(MegaNoise));
            //noise.Strength = Strength;
            //noise.Animate = true;
            //noise.Freq = Freq;
            //noise.Phase = Random.Range(0f, 100f);
            
        }
        //Debug.Log("tesssssss " + this.transform.localPosition + "    fdswgvergerg " + this.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    bool SphereIntersect(Vector3 c1, float r1, Vector3 c2, float r2)
    {
      Vector3 dist = c1 - c2;
      float distSq = DotProduct(dist, dist);
   
      if(distSq > ((r1 + r2) * (r1 + r2)))
        return false; // no intersection
 
      return true; // intersection
    }

    private float DotProduct(Vector3 lhs, Vector3 rhs)
    {
      return lhs.x * rhs.x + lhs.y * rhs.y;
    }

    private bool TouchingAnotherCircle(Vector3 sphereLocation, float sphereSize)
    {
        foreach (var gameObject in m_List)
        {
            if (SphereIntersect(gameObject.transform.position, gameObject.transform.localScale.x, sphereLocation, sphereSize))
                return true;
        }

        return false;
    }

    private Vector3 CalculatePoint(Vector3 origin)
    {
        var angle = Random.Range(0f, 1f) * Mathf.PI * 2f;
        var radius = Math.Sqrt(Random.Range(0f,1f)) * 4.5f;
        var x = origin.x + radius * Math.Cos(angle);
        var y = origin.y + radius * Math.Sin(angle);
        return new Vector3((int)x, (int)y, origin.z);
    }
}
