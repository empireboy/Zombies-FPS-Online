public interface IShootable
{
    event TransformEvent OnStartShooting;
    event TransformEvent OnStopShooting;

    void StartShooting();
    void StopShooting();
}