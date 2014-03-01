using UnityEngine;
using System.Collections;

public class ToggleDual : ToggleNormal
{
    public int Color1;
    public int Color2;

    public override void SetColor(int color)
    {
        switch (color)
        {
            case ColorID.Purple:
                Color1 = ColorID.Blue;
                Color2 = ColorID.Red;
                break;
            case ColorID.Orange:
                Color1 = ColorID.Red;
                Color2 = ColorID.Yellow;
                break;
            case ColorID.Green:
                Color1 = ColorID.Blue;
                Color2 = ColorID.Yellow;
                break;
        }
    }


    public override bool ShouldIActivate(GameObject sender)
    {
        if (sender.GrabType() == typeof(ToggleNormal))
            return (sender.GrabNormal().ToggleColor == Color1 || sender.GrabNormal().ToggleColor == Color2);
        else if (sender.GrabType() == typeof(ToggleDual))
            return sender.GrabDual().Color1 == Color1 || sender.GrabDual().Color2 == Color2 || sender.GrabDual().Color2 == Color1 || sender.GrabDual().Color1 == Color2;

        return false;
    }

    public override bool AmIWinPosition()
    {
        return false;
    }
}
