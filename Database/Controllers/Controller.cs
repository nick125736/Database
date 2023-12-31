﻿using Dapper;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class asdController : ControllerBase
    {
        private readonly String _connectString = DBUtil.ConnectionString();

        [HttpGet]
        public async Task<IEnumerable<Calendar>> GetCalendars()
        {
            string sqlQuery = "SELECT * FROM MyCalendar";
            using (var connection = new SqlConnection(_connectString))
            {
                var Calendars = await connection.QueryAsync<Calendar>(sqlQuery);
                return Calendars.ToList();
            }
        }
        [HttpGet("{id}")]
        public async Task<Calendar> GetCalendar(int id)
        {
            string sqlQuery = "SELECT * FROM MyCalendar WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var Calendar = await connection.QueryFirstOrDefaultAsync<Calendar>(sqlQuery,
                    new { Id = id });
                if (Calendar == null)
                {
                    return new Calendar();
                }
                return Calendar;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCalendar(Calendar Calendar)
        {
            string sqlQuery = "INSERT INTO MyCalendar (Name, Sex, Birth, Address)  VALUES (@Name, @Sex, @Birth, @Address)";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, Calendar);
                return Ok();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCalendar(Calendar Calendar)
        {
            string sqlQuery = "UPDATE MyCalendar SET Name = @Name, Sex = @Sex, Birth = @Birth, Address=@Address WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, Calendar);
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            string sqlQuery = "DELETE FROM MyCalendar WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
                return Ok();
            }
        }


    }
}
