using barberdotnet.model.converter;
using barberdotnet.repository;

namespace barberdotnet.services;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.model.DTOs;



public class WeekService
{
    private readonly DayToDTO _dayConverter;
    private readonly WeekRepo _repository;
    private readonly IDayService _dayService;

    public WeekService(DayToDTO dayConverter, WeekRepo repository, IDayService dayService)
    {
        _dayService = dayService;
        _dayConverter = dayConverter;
        _repository = repository;
    }
    public async Task<ActionResult<List<DayDTO>>> GetWeekInfo(int year, int month, int week, int barber)
    {
        var weekList = await _repository.GetAllFromWeekBarber(year, month, week, barber);
        var list = new List<DayDTO>();
        foreach (var day in weekList)
        {
            var barbers = await _dayService.GetByDate(year, month, (int) day.MonthDay);
            list.Add(_dayConverter.ToDTO(day,barbers));
        }
         

        return list;
    } 
}