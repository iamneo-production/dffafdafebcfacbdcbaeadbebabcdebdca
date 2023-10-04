using System;
using dotnetapp.Models;

namespace dotnetapp.Service;
public interface IPlayersService
{
    Task<IEnumerable<Player>> GetPlayersList();
    Task<Player> GetPlayerById(int id);
    Task<Player> CreatePlayer(Player player);
    Task UpdatePlayer(Player player);
    Task DeletePlayer(Player player);
}
