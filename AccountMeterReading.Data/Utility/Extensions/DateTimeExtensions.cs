﻿using System;
using System.Globalization;

public static class DateTimeExtensions
{
    public static DateTime ToDateTime(this string s,
              string format = "ddMMyyyy", string cultureString = "tr-TR")
    {
        try
        {
            var r = DateTime.ParseExact(
                s: s,
                format: format,
                provider: CultureInfo.GetCultureInfo(cultureString));
            return r;
        }
        catch (FormatException)
        {
            throw;
        }
        catch (CultureNotFoundException)
        {
            throw; // Given Culture is not supported culture
        }
    }
}