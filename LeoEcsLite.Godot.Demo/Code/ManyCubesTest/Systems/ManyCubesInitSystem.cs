using Godot;
using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Components;
using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Configs;
using LeoEcsIntegrationPrototype.Code.Tools;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsIntegrationPrototype.Code.ManyCubesTest.Systems
{
    public sealed class ManyCubesInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<ManyCubesDemoConfig> _config = default;
        private readonly EcsCustomInject<Node> _root = default;
        
        private readonly EcsPoolInject<SpatialComponent> _spatialPool = default;
        private readonly EcsPoolInject<RotationComponent> _rotationPool = default;
        private readonly EcsPoolInject<OrbitingComponent> _orbitingPool = default;
        
        public void Init(IEcsSystems systems)
        {
            var config = _config.Value;
            if (!string.IsNullOrEmpty(config.CubePrefab.ResourcePath))
            {
                var resourceNode = GD.Load<PackedScene>(config.CubePrefab.ResourcePath);
                
                var world = systems.GetWorld();
                for (var i = 0; i < config.NumberOfEntities; i++)
                {
                    var itemNode = (Spatial)resourceNode.Instance();

                    itemNode.Translation = RandomTool.NextVector3(-config.SpawnRadius, config.SpawnRadius);
                    itemNode.Rotation = RandomTool.NextVector3(-config.SpawnRadius, config.SpawnRadius);

                    _root.Value.AddChild(itemNode);

                    var cubeEntity = world.NewEntity();
                    
                    ref var spatialComponent = ref _spatialPool.Value.Add(cubeEntity);
                    spatialComponent.Spatial = itemNode;
                    
                    ref var rotationComponent = ref _rotationPool.Value.Add(cubeEntity);
                    rotationComponent.Direction = RandomTool.NextVector3(-1f, 1f).Normalized();
                    rotationComponent.Speed = RandomTool.NextFloat(config.MinRotationSpeed, config.MaxRotationSpeed);
                    
                    ref var orbitingComponent = ref _orbitingPool.Value.Add(cubeEntity);
                    orbitingComponent.Speed = config.OrbitingSpeed;
                }
            }
        }
    }
}