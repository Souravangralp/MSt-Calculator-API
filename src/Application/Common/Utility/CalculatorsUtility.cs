namespace CalculatorAPI.Application.Common.Utility;

public static class CalculatorsUtility
{
    /// <summary>
    /// This method is used to round the number to two decimal places
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static double RoundOff(this double? number)
    {
        return number is null ? 0.00 : Math.Round(number ?? 0.00, 2);
    }

    /// <summary>
    /// Reference https://www.magicbricks.com/acre-to-hectare-pppfa
    /// </summary>
    /// <param name="squareMeters"></param>
    /// <returns></returns>
    public static double SquareMetersToHectares(double squareMeters)
    {
        double hectares = squareMeters * 0.0001;
        return RoundOff(hectares);

        //return Math.Ceiling(hectares * 100) / 100; // Rounding up to two decimal places
    }

    /// <summary>
    /// Reference https://www.magicbricks.com/acre-to-hectare-pppfa
    /// </summary>
    /// <param name="acres"></param>
    /// <returns></returns>
    public static double AcresToHectares(double acres)
    {
        double hectares = acres / 2.471052;
        return RoundOff(hectares);

        //return Math.Ceiling(hectares * 100) / 100;
    }

    public static double RoundToNearestMultipleOfFive(double value)
    {
        // Calculate the remainder when dividing by 5
        var remainder = value % 5;

        // If remainder is 3 or more, round up; otherwise, round down
        if (remainder >= 3)
        {
            return Math.Ceiling(value / 5) * 5;
        }
        else
        {
            return Math.Floor(value / 5) * 5;
        }
    }
}
