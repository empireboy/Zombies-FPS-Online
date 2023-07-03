using System.Collections.Generic;

public class PlayerManager
{
    private List<Player> _players = new List<Player>();

    public void Add(Player player)
    {
        _players.Add(player);
    }

    public void Remove(Player player)
    {
        _players.Remove(player);
    }

    public Player Get(int id)
    {
        return _players[id];
    }
}