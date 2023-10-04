using System;
using System.Collections;
using System.Collections.Generic;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Service;
public class PlayersService : IPlayersService
{
    private readonly FootballdbContext _context;

    public PlayersService(FootballdbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetPlayersList()
    {
        return await _context.Players
            .Include(x => x.Position)
            .ToListAsync();
    }

    public async Task<Player> GetPlayerById(int id)
    {
        return await _context.Players
            .Include(x => x.Position)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Player> CreatePlayer(Player player)
{
    // Check if the specified positionid exists in the database
    var existingPosition = await _context.Positions.FirstOrDefaultAsync(p => p.Id == player.Positionid);

    if (existingPosition != null)
    {
        // Position with the specified ID exists; assign it to the player
        player.Position = existingPosition; // Assign the existing position
        player.Positionid = existingPosition.Id; // Update positionid just to be sure

        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player;
    }
    else
    {
        var newPosition = new Position
        {
            Name = "New Position" // Set the name as needed
            // Other properties of Position
        };

        _context.Positions.Add(newPosition);
        await _context.SaveChangesAsync();

        // Now, you can assign the new position's ID to the player
        player.Positionid = newPosition.Id;

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return player;
    }
}
    public async Task UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayer(Player player)
    {
        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }
}