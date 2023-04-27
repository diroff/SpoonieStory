public class GradesDisplayer : StatsDisplayer
{
    protected override void DisplayParameterValue(int currentValue, int maxValue)
    {
        base.DisplayParameterValue(currentValue, maxValue);
        _parameterText.text += $" ({CalculateGrade(currentValue)})";
    }

    private string CalculateGrade(int value)
    {
        if (value >= 96)
            return "A+";

        if (value < 96 && value >= 90)
            return "A";

        if (value < 90 && value >= 85)
            return "B+";

        if (value < 85 && value >= 80)
            return "B";

        if (value < 80 && value >= 75)
            return "C+";

        if (value < 75 && value >= 60)
            return "C";

        if (value < 60 && value >= 55)
            return "D+";

        if (value < 55 && value >= 50)
            return "D";

        return "E";
    }
}