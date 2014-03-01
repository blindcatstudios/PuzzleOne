using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


public static class Controller
{
    private static readonly List<GameObject> m_CurrentToggles = new List<GameObject>();

    private static void AddToToggle(this GameObject toggle) { m_CurrentToggles.Add(toggle); }

    public static void InitializeNormal(this GameObject toggle, int color, float radialPosition, TogglePosition position)
    {
        toggle.AddToToggle();
        toggle.AddComponent(typeof(ToggleNormal));
		toggle.GrabToggle().SetColor(color);
        toggle.GrabNormal().SetScale();
        SetColor (toggle, color);

		var positions = Position.PositionsFromRadial(radialPosition);
        
		toggle.GrabNormal().SetPositions(positions, position);
    }

	public static void InitializeDual(this GameObject toggle, int color, float radialPosition, TogglePosition position, bool open = false)
    {
		toggle.AddToToggle();
		toggle.AddComponent(typeof(ToggleDual));
		toggle.GrabToggle().SetColor(color);
		toggle.GrabToggle().SetScale();
	    
		SetColor (toggle, color);
		
		var positions = Position.PositionsFromRadial(radialPosition);

		toggle.GrabNormal().SetPositions(positions, position);
    }

    public static void ToggleAll(this GameObject toggle)
    {
        m_CurrentToggles.Where(o => o.GrabToggle().ShouldIActivate(toggle)).ToList().ForEach(o => o.GrabToggle().toggle(toggle));
    }

    public static int GetToggleCount
    {
        get { return m_CurrentToggles.Count; } 
    }

    public static int GetToggleWinPositionCount
    {
        get { return m_CurrentToggles.Count(o => o.GrabToggle().AmIWinPosition()); }
    }

	public static bool IsAnyoneEasing()
	{
		return m_CurrentToggles.Any (o => o.GrabNormal().AmIEasing());
	}

    private static void SetColor (GameObject gameObject, int color)
	{
		switch (color) {
		case ColorID.Red:
			gameObject.renderer.material.color = Color.red;
			break;
		case ColorID.Blue:
			gameObject.renderer.material.color = Color.blue;
			break;
		case ColorID.Green:
			gameObject.renderer.material.color = Color.green;
			break;
		case ColorID.Orange:
			gameObject.renderer.material.color = Color.green;
			break;
		case ColorID.Yellow:
			gameObject.renderer.material.color = Color.yellow;
			break;
		case ColorID.Purple:
			gameObject.renderer.material.color = Color.magenta;
			break;
		}

	}

    public static bool IWon = false;
    public static void ToggleRandom()
    {
        if (IWon)
            return;

        var t = m_CurrentToggles.Where(o => o.GrabType() == typeof(ToggleNormal)).DistinctBy(o => o.GrabNormal().ToggleColor).ToList();
        t.AddRange(m_CurrentToggles.Where(o => o.GrabType() != typeof(ToggleNormal)));

        t[Random.Range(0, t.Count)].ToggleAll();

        IWon = t.All(o => o.GrabNormal().CurrentPosition != TogglePosition.Open);
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>
    (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }
}
