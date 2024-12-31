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

// https://leetcode.com/problems/reverse-integer/

namespace LeetCode.Solutions;

internal class ReverseInteger
{
    public static int Reverse(int x)
    {
        if (x > -10 && x < 10)
        {
            return x;
        }

        if (x == int.MinValue)
        {
            return 0;
        }

        uint reversed = 0;
        bool isNegative = x < 0;

        x = Math.Abs(x);

        while (x > 0)
        {
            uint digit = (uint)x % 10;

            try
            {
                checked
                {
                    reversed *= (uint)10;
                    reversed += digit;
                }
            }
            catch (OverflowException)
            {
                return 0;
            }

            x /= 10;
        }

        uint max = (uint)int.MaxValue;

        if (reversed >= max)
        {
            return 0;
        }

        return isNegative ? -(int)reversed : (int)reversed;
    }
}
