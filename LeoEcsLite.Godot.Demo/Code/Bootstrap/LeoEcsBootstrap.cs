using Godot;
using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Configs;
using LeoEcsIntegrationPrototype.Code.ManyCubesTest.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsIntegrationPrototype.Code.Bootstrap
{
    public class LeoEcsBootstrap : Node
    {
        private EcsWorld _world;
        private IEcsSystems _systems;
    
        public override void _Ready()
        {
            var manyCubesTestConfig = GetNode<ManyCubesDemoConfig>("ManyCubesDemoConfig");
            
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems
                .Add(new ManyCubesInitSystem())
                .Add(new CubeRotationSystem())
                .Add(new CubeOrbitingSystem())
                .Inject(manyCubesTestConfig, this)
                .Init();
        }

        public override void _Process(float delta)
        {
            _systems.Run();
        }
        
        public override void _ExitTree()
        {
            _systems.Destroy();
            _systems = null;
            
            _world.Destroy();
            _world = null;
        }
    }
}

