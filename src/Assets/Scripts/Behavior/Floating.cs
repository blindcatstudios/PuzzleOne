using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Floating : MonoBehaviour
{

    float yStep, xStep; //A variable we increment

    float xSpeed = -2.0f;
    float ySpeed = -0.0f;

    float speed = 2.0f;

    float amplitude = 1.5f;
    float actualAmplitude = 1.5f;
    float rampUpSpeed = 0.01f;
    const float randomDiff = 0.8f;

    public Vector3 startingPosition;
    bool m_Floating = false;
    public static void AttachToGameObject(GameObject gameObject)
    {
        var floating = (Floating)gameObject.AddComponent(typeof(Floating));
        floating.StartFloat();
    }

    public static void AttachToGameObject(GameObject gameObject, Vector3 offset, float amp = 1.5f)
    {
        var floating = (Floating)gameObject.GetComponent(typeof(Floating)) ?? (Floating)gameObject.AddComponent(typeof(Floating));
        floating.StartFloat(offset);
        floating.actualAmplitude = amp;
        floating.amplitude = 1.5f;
    }

    void Start() { }

    public void StartFloat()
    {
        m_Floating = false;
        steps = 0.0f;
        stepStep = 0.03f;
        startingPosition = transform.position;
        m_Floating = true;
    }

    private void StartFloat(Vector3 direction)
    {
        m_Floating = false;
        steps = 0.0f;
        stepStep = 0.03f;
        xSpeed = -(direction.x * speed);
        ySpeed = -(direction.y * speed);
        startingPosition = transform.position;
        m_Floating = true;
    }

    public void SetAmp(float amp)
    {
        actualAmplitude = amp;
    }

    float steps = 0.0f;
    float stepStep = 0.03f;
    void FixedUpdate()
    {
        if (!m_Floating)
            return;

        var yy = startingPosition.y + (actualAmplitude * Mathf.Sin(ySpeed * steps));
        var xx = startingPosition.x + (actualAmplitude * Mathf.Sin(xSpeed * steps));
            //Debug.Log(new Vector3(xx, yy, transform.position.z));
            //Debug.Break();
        transform.position = new Vector3(xx, yy, transform.position.z);

        actualAmplitude += rampUpSpeed;
        if (actualAmplitude > amplitude)
            actualAmplitude = amplitude;
        steps += stepStep ;
    }
}
