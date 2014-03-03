using UnityEngine;
using System.Collections;

public class ColorLerping : MonoBehaviour
{
    Color m_StartColor, m_EndColor;
    float m_StartingTime, m_Duration, m_Delay;
    bool m_Lerping = false;
	Gradient g;

    public void StartLerp(Color start, Color end, float timeInSeconds, float delay)
    {
        m_StartColor = start;
        m_EndColor = end;
        m_Duration = timeInSeconds;
        m_Lerping = true;
        m_StartingTime = Time.time;
        m_Delay = delay;


		GradientColorKey[] gck;
		GradientAlphaKey[] gak;
		g = new Gradient();
		// Populate the color keys at the relative time 0 and 1 (0 and 100%)
		gck = new GradientColorKey[2];
		gck[0].color = start;
		gck[0].time = 0.0f;
		gck[1].color = end;
		gck[1].time = 1.0f;
		// Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
		gak = new GradientAlphaKey[2];
		gak[0].alpha = 1.0f;
		gak[0].time = 0.0f;
		gak[1].alpha = 0.0f;
		gak[1].time = 1.0f;
		g.SetKeys(gck, gak);
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

//        	gameObject.renderer.material.color = Color.Lerp(m_StartColor, m_EndColor, progress);

		gameObject.renderer.material.color = g.Evaluate(progress);

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
		ColorLerping newEase = toggle.gameObject.GetComponent<ColorLerping>();
		if (newEase == null)
			newEase = toggle.gameObject.AddComponent<ColorLerping>();

        newEase.StartLerp(start, end, time, delay);
    }
}
