using System.Reflection;

namespace dotNetRFassignment.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}