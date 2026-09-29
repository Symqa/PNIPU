using System;

public class EmployeesAddresses
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string address {  get; set; }
}

public class EmployeesInfo
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string phoneNumber { get; set; }
    public decimal salary { get; set; }
}

public class EmployeesOlderThanFour
{
    public int id { get; set; }
    public string fullName { get; set; }
    public int yearsOfService { get; set; }
}
