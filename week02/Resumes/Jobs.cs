public class Job
{
    public string _role;
    public string _companyName;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_role} ({_companyName}) {_startYear}-{_endYear}");
    }
}