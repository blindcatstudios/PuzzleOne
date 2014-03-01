using System;
using UnityEngine;
using System.Collections;
using Vectrosity;

public static class VLiner
{
    static readonly Material m_DottedLine;
    static readonly Material m_DottedLine2;
    static readonly Material m_ThickLine;
    const float m_DottedLineThickness = 5.5f;

    static VLiner()
    {
        m_DottedLine = (Material) Resources.Load("HashLine", typeof(Material));
        m_DottedLine2 = (Material)Resources.Load("HashLine2", typeof(Material));
        m_ThickLine = (Material)Resources.Load("ThickLine", typeof(Material));
    }

    public static VectorLine CreateDottedLine(Vector3 start, Vector3 end)
    {
        var myline = new VectorLine("MyLine", new[] { start, end }, m_DottedLine, m_DottedLineThickness, LineType.Continuous);
        myline.SetTextureScale(1.0f);
        myline.Draw3D();
        return myline;
    }

    static int orbitLineResolution = 150;
    public static int segments = 40;

    public static void DrawCircle()
    {
        DrawDottedLine(new Vector3(), 48f);
    }

    public static void DrawCircle(Vector3 position, float radius)
    {
        Vector3[] linePoints = new Vector3[segments + 1];
        
        var myLine = new VectorLine("circle", linePoints, m_ThickLine, m_DottedLineThickness, LineType.Continuous);

        myLine.MakeCircle(position, radius);
        myLine.SetTextureScale(1.0f);

        myLine.Draw3D();
    }

    public static void DrawDottedLine(Vector3 position, float radius)
    {
        Vector3[] linePoints = new Vector3[segments + 1];
        var myLine = new VectorLine("circle", linePoints, m_DottedLine, m_DottedLineThickness, LineType.Continuous);

        myLine.MakeCircle(position, radius);
        myLine.SetTextureScale(1.0f);

        myLine.Draw3D();
    }

}
