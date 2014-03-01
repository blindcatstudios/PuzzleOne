using UnityEngine;
using System.Collections;

public class CenterCircleTouch : MonoBehaviour
{

    float m_NormalSpeed = 0.0f;
    float m_ActualSpeed;
    float m_MaxSpeed = 2.5f;
    float m_SpeedLoss = 0.005f;
    bool m_Jiggle = false;

    float m_NormalStr = 0.0f;
    float m_ActualStr;
    float m_MaxStr = 0.125f;
    float m_StrLoss = 0.00025f;


    MegaNoise m_MegaNoise;
	// Use this for initialization
    void Start()
    {
        m_MegaNoise = (MegaNoise)gameObject.GetComponent(typeof(MegaNoise));
        //m_MegaNoise.Strength = new Vector3(m_MaxStr, m_MaxStr, m_MaxStr);
        m_MegaNoise.Animate = true;
    }

    // Update is called once per frame
    void Update()
    {

        //float jiggleSpeed = Controller.GetToggleWinPositionCount / (float)Controller.GetToggleCount;
        //jiggleSpeed *= m_MaxSpeed;
        //m_MegaNoise.Freq = jiggleSpeed;
        //Debug.Log("current JiggleSpeed " + jiggleSpeed);
        if (m_Jiggle)
        {
            m_MegaNoise.Freq = m_ActualSpeed;
            m_MegaNoise.Strength = new Vector3(m_ActualStr, m_ActualStr, m_ActualStr);
            if (m_ActualSpeed >= m_NormalSpeed)
                m_ActualSpeed -= m_SpeedLoss;
            if (m_ActualStr >= m_NormalStr)
                m_ActualStr -= m_StrLoss;

            if (m_ActualStr <= m_NormalStr && m_ActualSpeed <= m_NormalSpeed)
                m_Jiggle = false;

        }
    }

    public void OnMouseDown()
    {
		BackgroundParticleSystemController.StartBackground();

//        if (!m_Jiggle)
//        {
//            m_Jiggle = true;
//            m_ActualSpeed = m_MaxSpeed;
//            m_ActualStr = m_MaxStr;
//
//        }


    }
}
