using Godot;
using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsIntegrationPrototype.Code.ManyCubesTest.Systems
{
    public class CubeOrbitingSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SpatialComponent, OrbitingComponent>> _rotationFilter = default;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var cubeEntity in _rotationFilter.Value)
            {
                ref var spatialComponent = ref _rotationFilter.Pools.Inc1.Get(cubeEntity);
                var translation = spatialComponent.Spatial.Translation;
                ref var orbitingComponent = ref _rotationFilter.Pools.Inc2.Get(cubeEntity);
                var speed = orbitingComponent.Speed * Time.DeltaTime;

                var x = Mathf.Cos(speed) * translation.x - Mathf.Sin(speed) * translation.z;
                var z = Mathf.Sin(speed) * translation.x + Mathf.Cos(speed) * translation.z;
                var newTranslation = new Vector3(x, translation.y, z);
                spatialComponent.Spatial.Translation = newTranslation;
            }
        }
    }
}