using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsIntegrationPrototype.Code.ManyCubesTest.Systems
{
    public sealed class CubeRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpatialComponent, RotationComponent>> _rotationFilter = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var cubeEntity in _rotationFilter.Value)
            {
                ref var spatialComponent = ref _rotationFilter.Pools.Inc1.Get(cubeEntity);
                ref var rotationComponent = ref _rotationFilter.Pools.Inc2.Get(cubeEntity);
                spatialComponent.Spatial.Rotate(rotationComponent.Direction, rotationComponent.Speed * Time.DeltaTime);
            }
        }
    }
}