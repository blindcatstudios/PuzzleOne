using System;
using UnityEngine;
using System.Collections;

public static class ScriptGrab
{
    public static Toggle GrabToggle(this GameObject gameObject)
    {
        return (Toggle)gameObject.GetComponent(typeof(Toggle));
    }
    public static ToggleNormal GrabNormal(this GameObject gameObject)
    {
        return (ToggleNormal)gameObject.GetComponent(typeof(ToggleNormal));
    }
    public static ToggleDual GrabDual(this GameObject gameObject)
    {
        return (ToggleDual)gameObject.GetComponent(typeof(ToggleDual));
    }


    public static Type GrabType(this GameObject gameObject)
    {
		if (gameObject.HasComponent(typeof(ToggleDual)))
			return typeof(ToggleDual);
        if (gameObject.HasComponent(typeof(ToggleNormal)))
            return typeof(ToggleNormal);

        return null;
    }

    private static bool HasComponent(this GameObject gameObject, Type ClassType)
    {
        return ((gameObject.GetComponent(ClassType)) != null);
    }

}
