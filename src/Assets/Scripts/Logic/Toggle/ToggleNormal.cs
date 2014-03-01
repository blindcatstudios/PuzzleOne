using UnityEngine;
using System.Collections;

public enum TogglePosition { Open, Closed };

public class ToggleNormal : Toggle, IDualPosition
{
    public int ToggleColor { get; set; }

    public Vector3 PositionOpened { get; set; }
    public Vector3 PositionClosed { get; set; }
    public TogglePosition CurrentPosition { get; set; }
    public int badInt = 0;

    float badStartingWidth = 10;
    float badScaleDifference = 3f;

    const float c_FloatMin = 1.5f;
    const float c_FloatMax = 5.5f;

    public override void toggle(GameObject sender)
    {
        if (CurrentZone != null && !CurrentZone.Leave(this, sender.GrabToggle()))
            return;

        var startingPosition = gameObject.transform.localPosition;
        var endLocation = CurrentPosition == TogglePosition.Closed ? PositionOpened : PositionClosed;

        var offset = Vector3.Normalize(endLocation - startingPosition);
        gameObject.StartAutoTween(startingPosition,
                                  endLocation,
                                  Random.Range(1f, 1f),
                                  EasingType.outCubic,
                                  () => EndEase(offset));

        var scaleStart = CurrentPosition == TogglePosition.Closed ? badStartingWidth - badScaleDifference : badStartingWidth + badScaleDifference;
        var scaleEnd = CurrentPosition == TogglePosition.Open ? badStartingWidth - badScaleDifference : badStartingWidth + badScaleDifference;
        gameObject.StartAutoScaleTween(scaleStart,
                                       scaleEnd,
                                       Random.Range(1f, 1f),
                                       EasingType.outCubic,
                                       //badInt / 33f,
                                       () =>
                                       {
                                           //CurrentPosition = SwapPosition(CurrentPosition);
                                           //Floating.AttachToGameObject(gameObject, offset);
                                       });
    }

    void EndEase(Vector3 offset)
    {
        CurrentPosition = SwapPosition(CurrentPosition);
        Floating.AttachToGameObject(gameObject, offset, CurrentPosition == TogglePosition.Open ? c_FloatMin : c_FloatMax);
    }

    public override void SetColor(int color)
    {
        ToggleColor = color;
    }

    public override void SetScale()
    {
        var scale = CurrentPosition == TogglePosition.Closed ? badStartingWidth - badScaleDifference : badStartingWidth + badScaleDifference;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    TogglePosition SwapPosition(TogglePosition currentPosition)
    {
        if (currentPosition == TogglePosition.Closed)
            return TogglePosition.Open;
        else
            return TogglePosition.Closed;
    }

    public void SetPositions(TogglePositions positions, TogglePosition startingPosition)
    {
        PositionOpened = positions.OpenPosition;
        PositionClosed = positions.ClosedPosition;

        CurrentPosition = startingPosition;

        gameObject.transform.localPosition = startingPosition == TogglePosition.Closed ? PositionClosed : PositionOpened;
        SetScale();
    }

    public override bool ShouldIActivate(GameObject sender)
    {
        if (sender.GrabType() == typeof(ToggleNormal))
            return (sender.GrabNormal().ToggleColor == ToggleColor);
        else if (sender.GrabType() == typeof(ToggleDual))
            return (sender.GrabDual().Color1 == ToggleColor || sender.GrabDual().Color2 == ToggleColor);

        return false;
    }

    public override bool AmIWinPosition()
    {
        return CurrentPosition == TogglePosition.Closed;
    }

    public void OnMouseDown()
    {
        if (!Controller.IsAnyoneEasing())
            gameObject.ToggleAll();
    }

    public bool AmIEasing()
    {
        var ease = (Ease)gameObject.GetComponent(typeof(Ease));
        return ease != null && ease.m_Easing;
    }

    public Color CurrentActualColor;

    public void Update()
    {

    }

}
