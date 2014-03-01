using UnityEngine;
using System.Collections;

public class ColorLerping : MonoBehaviour
{
    Color m_StartColor, m_EndColor;
    float m_StartingTime, m_Duration, m_Delay;
    bool m_Lerping = false;

    public void StartLerp(Color start, Color end, float timeInSeconds, float delay)
    {
        m_StartColor = start;
        m_EndColor = end;
        m_Duration = timeInSeconds;
        m_Lerping = true;
        m_StartingTime = Time.time;
        m_Delay = delay;
    }

    private bool DelayIfNeeded()
    {
        if (m_Delay == 0)
            return false;

        if (Time.time - m_StartingTime < m_Delay)
            return true;

        m_Delay = 0;
        m_StartingTime = Time.time;
        return false;
    }

    void Update()
    {
        if (!m_Lerping || DelayIfNeeded())
            return;

        var progress = (Time.time - m_StartingTime) / m_Duration;
        gameObject.renderer.material.color = Color.Lerp(m_StartColor, m_EndColor, progress);

        if (Time.time - m_StartingTime > m_Duration)
            Kill();
    }

    private void Kill()
    {
        m_Lerping = false;
        Destroy(this);
    }


}

public static class ColorLerp
{
    public static void AddColorLerp(this Toggle toggle, Color start, Color end, float time, float delay = 0.0f)
    {
        var newEase = toggle.gameObject.AddComponent<ColorLerping>();
        newEase.StartLerp(start, end, time, delay);
    }
}
