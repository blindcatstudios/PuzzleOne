using UnityEngine;
using System.Collections;
using Vectrosity;

public abstract class Toggle : MonoBehaviour
{
    public Zone CurrentZone { get; set; }

    public abstract void toggle(GameObject sender);

    public abstract bool ShouldIActivate(GameObject sender);

    public abstract bool AmIWinPosition();

	public abstract void SetColor(int color);

	public abstract void SetScale();

}

public interface IDualPosition
{
    Vector3 PositionOpened { get; set; }
    Vector3 PositionClosed { get; set; }
    TogglePosition CurrentPosition { get; set; }
}

public abstract class Zone
{
    public abstract bool Leave(Toggle toggle, Toggle toggleSender);
}

public class DualColorZone : Zone
{
    readonly int m_ColorIn;
    readonly int m_ColorOut;

    public DualColorZone(int colorIDin, int colorIDout)
    {
        m_ColorIn = colorIDin;
        m_ColorOut = colorIDout;
    }

    public override bool Leave(Toggle toggle, Toggle sender)
    {
        int toColor = -1;
        int fromColor = -1;
        if (toggle is IDualPosition && ((IDualPosition)toggle).CurrentPosition == TogglePosition.Open)
        {
            toColor = m_ColorIn;
            fromColor = m_ColorOut;
        }
        else
        {
            toColor = m_ColorOut;
            fromColor = m_ColorIn;
        }

        toggle.SetColor(toColor);
        toggle.AddColorLerp(ColorID.DefaultColors[fromColor], ColorID.DefaultColors[toColor], 0.3f, 0.8f);
        return true;
    }
}

public class LockedZone : Zone
{
    //0 closed  1 open  2 both
    readonly int m_Position;
    public LockedZone(int position)
    {
        m_Position = position;
    }

    public override bool Leave(Toggle toggle, Toggle sender)
    {
        if (toggle == sender)
            return true;

        switch (m_Position)
        {
            case 0:
                if (toggle is IDualPosition)
                    return ((IDualPosition)toggle).CurrentPosition == TogglePosition.Closed;
                break;
            case 1:
                if (toggle is IDualPosition)
                    return ((IDualPosition)toggle).CurrentPosition != TogglePosition.Closed;
                break;
            case 2:
                if (toggle is IDualPosition)
                    return false;
                break;
        }
        return false;
    }

    public void DrawZone(Vector3 position)
    {
        VLiner.DrawCircle(position, 12f);
    }
}
