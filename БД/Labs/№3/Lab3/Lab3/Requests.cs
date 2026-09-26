using System;

public class EmployeesAddresses
{
    public int id { get; private set; }
    public string fullName { get; private set; }
    public string address {  get; private set; }
}

public class EmployeesInfo
{
    public int id { get; set; }
    public string fullName { get; private set; }
    public string phoneNumber { get; private set; }
    public decimal salary { get; private set; }
}

public class EmployeesOlderThanFour
{
    public int id { get; private set; }
    public string fullName { get; private set; }
    public int yearsOfService { get; private set; }
}
