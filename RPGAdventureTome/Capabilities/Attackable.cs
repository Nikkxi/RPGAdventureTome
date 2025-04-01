namespace RPGAdventureTome.Capabilities;

public interface Attackable
{

    public abstract void TakeDamage(int damage);
    public abstract void OnDeath();
}