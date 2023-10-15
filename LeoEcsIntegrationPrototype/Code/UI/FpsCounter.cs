using Godot;

namespace LeoEcsIntegrationPrototype.Code.UI
{
    public class FpsCounter : Label
    {
        public override void _Process(float delta)
        {
            Text = Engine.GetFramesPerSecond().ToString();
        }
    }
}