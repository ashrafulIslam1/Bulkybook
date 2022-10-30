﻿namespace Bulkybook.Models;

public class Attendance
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public DateTime InOutTime { get; set; }
    public string Remarks { get; set; }

}
