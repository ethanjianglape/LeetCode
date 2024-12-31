/**
 * This file is part of the LeetCode project.
 *  Copyright (C) 2024 Ethan Jiang-Lape
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

// https://leetcode.com/problems/string-to-integer-atoi/

namespace LeetCode.Solutions;

internal class StringToInteger
{
    public static int MyAtoi(string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        s = s.Trim();

        if (s.Length == 0)
        {
            return 0;
        }

        bool isNegative = s[0] == '-';
        bool isExplicitPositive = s[0] == '+';
        int result = 0;

        if (isNegative || isExplicitPositive)
        {
            s = s[1..];
        }

        foreach (char c in s)
        {
            if (c < '0' || c > '9')
            {
                break;
            }

            int digit = c - '0';

            try
            {
                checked
                {
                    result *= 10;
                    result += digit;
                }
            }
            catch (OverflowException)
            {
                return isNegative ? int.MinValue : int.MaxValue;
            }

        }

        return isNegative ? -result : result;
    }
}
