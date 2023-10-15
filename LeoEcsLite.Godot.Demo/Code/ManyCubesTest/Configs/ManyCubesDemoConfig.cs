using Godot;

namespace LeoEcsIntegrationPrototype.Code.ManyCubesTest.Configs
{
    public class ManyCubesDemoConfig : Node
    {
        [Export] public int NumberOfEntities = 10000;
        [Export] public Resource CubePrefab = null;
        [Export] public float SpawnRadius = 100f;
        [Export] public float MinRotationSpeed = 0.1f;
        [Export] public float MaxRotationSpeed = 0.5f;
        [Export] public float OrbitingSpeed = 1.0f;
    }
}