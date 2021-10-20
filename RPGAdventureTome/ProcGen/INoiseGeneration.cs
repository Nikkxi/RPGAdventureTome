namespace AdventureTome.ProcGen
{
    public interface INoiseGeneration
    {
        double GenerateNoise(double x, double y, double z);
        double OctaveNoise(double x, double y, double z, int octaves, double persistance);
    }
}