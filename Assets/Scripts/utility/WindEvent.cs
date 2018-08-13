
public class WindEvent : GameEvent {
    public WindEvent(float hs, float vs, float hsp, float vsp)
    {
        HorizontalSpeed = hs;
        VerticalSpeed = vs;
        HorizontalStartPoint = hsp;
        VerticalStartPoint = vsp;
    }

    public float HorizontalSpeed { get; set; }

    public float VerticalSpeed { get; set; }

    public float HorizontalStartPoint { get; set; }

    public float VerticalStartPoint { get; set; }
}
