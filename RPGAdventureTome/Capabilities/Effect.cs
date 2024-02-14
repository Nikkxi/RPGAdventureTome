namespace RPGAdventureTome.Capabilities
{

    public abstract class Effect
    {
        public abstract void ApplyEffect();
    }
}

namespace RPGAdventureTome.Capabilities.Effects
{
    public class NoEffect : Effect
    {
        public override void ApplyEffect()
        {
            // does nothing
        }
    }
}