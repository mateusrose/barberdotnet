namespace barberdotnet.controllers;
using barberdotnet.model.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.services;
using barberdotnet.model.DTOs;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WeekController
{
    private readonly WeekService _weekService;

    public WeekController(WeekService weekService)
    {
        _weekService = weekService;
    }

    [HttpGet("{year}/{month}/{week}")]
    public async Task<ActionResult<List<DayDTO>>> GetWeekInfo(int year, int month, int week, int barber)
    {
        var list = await _weekService.GetWeekInfo(year, month, week, barber);
        return list;
    }
}