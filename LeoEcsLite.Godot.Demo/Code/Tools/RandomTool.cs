using System.Runtime.CompilerServices;
using Godot;

namespace LeoEcsIntegrationPrototype.Code.Tools
{
    public class RandomTool
    {
        private static readonly RandomNumberGenerator _random;
    
        static RandomTool()
        {
            _random = new RandomNumberGenerator();
            _random.Randomize();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NextFloat(float from,float to)
        {
            return _random.RandfRange(from, to);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 NextVector3(float from,float to)
        {
            return new Vector3(_random.RandfRange(from, to), 
                _random.RandfRange(from, to), 
                _random.RandfRange(from, to));
        }
    }
}