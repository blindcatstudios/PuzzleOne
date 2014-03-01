using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Ease : MonoBehaviour
{
    Vector3 m_StartingPosition;
    Vector3 m_EndingPosition;
    EasingType m_EasingType;
    Action m_EndingAction;
    float m_StartingTime;
    float m_Duration;
    float m_Delay;

    public bool m_Easing = false;

    public void InitializeEase(Vector3 startingLocation, Vector3 endLocation, float timeInMilliseconds, EasingType easingType, Action endAction = null, float delay = 0)
    {
        m_StartingPosition = startingLocation;
        m_EndingAction = endAction;
        m_EndingPosition = endLocation;
        m_EasingType = easingType;
        m_Duration = timeInMilliseconds;
        m_StartingTime = Time.time;
        m_Delay = delay;
        m_Easing = true;
    }

    public void StartEase()
    {
        m_Easing = true;
    }

    public Vector3 CurrentPosition
    {
        get { return m_StartingPosition; }
    }

    public bool DelayIfNeeded()
    {
        if (m_Delay == 0)
            return false;

        if (Time.time - m_StartingTime < m_Delay)
            return true;

        m_Delay = 0;
        m_StartingTime = Time.time;
        return false;
    }

    public void Update()
    {
        if (!m_Easing || DelayIfNeeded())
            return;

        var progress = Easing.ByType(m_EasingType, Time.time - m_StartingTime, 0, 1, m_Duration);
        if (Time.time - m_StartingTime<=m_Duration)
        {
            var x = (Mathf.Abs(progress) * (m_EndingPosition.x - m_StartingPosition.x)) + m_StartingPosition.x;
            var y = (Mathf.Abs(progress) * (m_EndingPosition.y - m_StartingPosition.y)) + m_StartingPosition.y;
            var z = (Mathf.Abs(progress) * (m_EndingPosition.z - m_StartingPosition.z)) + m_StartingPosition.z;
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            progress = 1;
            var x = (Mathf.Abs(progress) * (m_EndingPosition.x - m_StartingPosition.x)) + m_StartingPosition.x;
            var y = (Mathf.Abs(progress) * (m_EndingPosition.y - m_StartingPosition.y)) + m_StartingPosition.y;
            var z = (Mathf.Abs(progress) * (m_EndingPosition.z - m_StartingPosition.z)) + m_StartingPosition.z;
            transform.position = new Vector3(x, y, z);
            m_Easing = false;
            Kill();
        }
    }

    private void Kill()
    {
        if (m_EndingAction != null)
            m_EndingAction();
        
        Destroy(this);
    }
}

public class ScaleEase : MonoBehaviour
{
    float m_StartingWidth, m_EndingWidth;
    EasingType m_EasingType;
    Action m_EndingAction;
    float m_StartingTime;
    float m_Duration;
    float m_Delay;

    public bool m_Easing = false;

    public void InitializeEase(float startingWidth, float endingWidth, float timeInMilliseconds, EasingType easingType, Action endAction = null, float delay = 0)
    {
        m_StartingWidth = startingWidth;
        m_EndingWidth = endingWidth;
        m_EndingAction = endAction;
        m_EasingType = easingType;
        m_Duration = timeInMilliseconds;
        m_StartingTime = Time.time;
        m_Delay = delay;
        m_Easing = true;
    }

    public void StartEase()
    {
        m_Easing = true;
    }

    public bool DelayIfNeeded()
    {
        if (m_Delay == 0)
            return false;

        if (Time.time - m_StartingTime < m_Delay)
            return true;

        m_Delay = 0;
        m_StartingTime = Time.time;
        return false;
    }

    public void Update()
    {
        if (!m_Easing || DelayIfNeeded())
            return;

        var progress = Easing.ByType(m_EasingType, Time.time - m_StartingTime, 0, 1, m_Duration);
        if (Time.time - m_StartingTime <= m_Duration)
        {
            var scale = (Mathf.Abs(progress) * (m_EndingWidth - m_StartingWidth)) + m_StartingWidth;
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            progress = 1;
            var scale = (Mathf.Abs(progress) * (m_EndingWidth - m_StartingWidth)) + m_StartingWidth;
            transform.localScale = new Vector3(scale, scale, scale);
            m_Easing = false;
            Kill();
        }
    }

    private void Kill()
    {
        if (m_EndingAction != null)
            m_EndingAction();

        Destroy(this);
    }
}

public static class Easing
{
    public static void StartAutoTween(this GameObject gameObject, Vector3 startingLocation, Vector3 endLocation, float timeInMilliseconds, EasingType easingType, Action endAction = null)
    {
        var newEase = gameObject.AddComponent<Ease>() as Ease;
        newEase.InitializeEase(startingLocation, endLocation, timeInMilliseconds, easingType, endAction);
    }

    public static void StartAutoTween(this GameObject gameObject, Vector3 startingLocation, Vector3 endLocation, float timeInMilliseconds, EasingType easingType, float delay, Action endAction = null)
    {
        var newEase = gameObject.AddComponent<Ease>() as Ease;
        newEase.InitializeEase(startingLocation, endLocation, timeInMilliseconds, easingType, endAction, delay);
    }

    public static void StartAutoScaleTween(this GameObject gameObject, float startingScale, float endingScale, float timeInMilliseconds, EasingType easingType, Action endAction = null)
    {
        var newEase = gameObject.AddComponent<ScaleEase>() as ScaleEase;
        newEase.InitializeEase(startingScale, endingScale, timeInMilliseconds, easingType, endAction);
    }

    public static void StartAutoScaleTween(this GameObject gameObject, float startingScale, float endingScale, float timeInMilliseconds, EasingType easingType, float delay, Action endAction = null)
    {
        var newEase = gameObject.AddComponent<ScaleEase>() as ScaleEase;
        newEase.InitializeEase(startingScale, endingScale, timeInMilliseconds, easingType, endAction, delay);
    }

    //public static float ByType(EasingType ease, float currentTime, float startTime, float changeInValue, float duration)
    internal static float ByType(EasingType tt, float t, float b, float c, float d)
    {
        switch (tt)
        {
            case EasingType.simple:
                return simple(t, b, c, d);
            case EasingType.backoutQuartic:
                return backoutQuartic(t, b, c, d);
            case EasingType.inCubic:
                return inCubic(t, b, c, d);
            case EasingType.outCubic:
                return outCubic(t, b, c, d);
            case EasingType.outElasticBig:
                return outElasticBig(t, b, c, d);
            case EasingType.outElasticSmall:
                return outElasticSmall(t, b, c, d);
            case EasingType.outinQuartic:
                return outinQuartic(t, b, c, d);
            case EasingType.ininCubic:
                return ininCubic(t, b, c, d);
            case EasingType.backinQuartic:
                return backinQuartic(t, b, c, d);
        }

        return 0.0f;
    }

    private static float simple(float t, float b, float c, float d)
    {
        return c * t / d + b;
    }

    private static float outElasticSmall(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (33 * tc * ts + -106 * ts * ts + 126 * tc + -67 * ts + 15 * t);
    }

    private static float outElasticBig(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (56 * tc * ts + -175 * ts * ts + 200 * tc + -100 * ts + 20 * t);
    }


    private static float outinQuartic(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (6 * tc + -9 * ts + 4 * t);
    }

    private static float outCubic(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (tc + -3 * ts + 3 * t);
    }

    private static float inCubic(float t, float b, float c, float d)
    {
        float tc = (t /= d) * t * t;
        return b + c * (tc);
    }

    private static float backoutQuartic(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (-2 * ts * ts + 10 * tc + -15 * ts + 8 * t);
    }

    private static float backinQuartic(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (2 * ts * ts + 2 * tc + -3 * ts);
    }

    private static float ininCubic(float t, float b, float c, float d)
    {
        float ts = (t /= d) * t;
        float tc = ts * t;
        return b + c * (tc * ts);
    }
}

public enum EasingType { simple, outElasticSmall, outElasticBig, outinQuartic, outCubic, inCubic, backoutQuartic, ininCubic, backinQuartic };


