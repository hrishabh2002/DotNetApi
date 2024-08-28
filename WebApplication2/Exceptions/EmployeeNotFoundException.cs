﻿namespace WebApplication2.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(int id)
            : base($"Employee with ID {id} was not found.")
        {
        }
    }
}
