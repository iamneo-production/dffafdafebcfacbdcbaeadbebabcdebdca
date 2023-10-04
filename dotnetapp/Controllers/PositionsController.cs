using Microsoft.AspNetCore.Mvc;
using dotnetapp.Service;
using dotnetapp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly IPositionsService _positionService;

    public PositionsController(IPositionsService positionService)
    {
        _positionService = positionService;
    }

    // GET: api/Positions
    [HttpGet]
    public async Task<IEnumerable<Position>> Get()
    {
        return await _positionService.GetPositionsList();
    }
}