using System;
using System.Collections;
using System.Collections.Generic;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Service;
public class PositionsService : IPositionsService
{
    private readonly FootballdbContext _context;

    public PositionsService(FootballdbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Position>> GetPositionsList()
    {
        return await _context.Positions
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync();
    }
}