using Godot;

public abstract class Time : Node
{
    public static float DeltaTime;

    public override void _Process(float delta)
    {
        DeltaTime = delta;
    }
}