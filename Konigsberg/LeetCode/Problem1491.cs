namespace Konigsberg.LeetCode;

public sealed class Problem1491
{
    public double Average(int[] salary)
    {
        var salaryList = salary.ToList();
        salaryList.Sort();
        salaryList.RemoveAt(salary.Length - 1);
        salaryList.RemoveAt(0);
        return salaryList.Average();
    }
}