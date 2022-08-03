using CM.Events;

public interface IKillable
{
    event SimpleEvent OnKill;

    void Kill();
}