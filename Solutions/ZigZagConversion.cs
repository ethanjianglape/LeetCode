using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions;

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

// https://leetcode.com/problems/zigzag-conversion/

internal class ZigZagConversion
{
    public string Convert(string s, int numRows)
    {
        ArgumentNullException.ThrowIfNull(s);

        if (s.Length <= 2 || numRows == 1)
        {
            return s;
        }

        bool movingDown = true;
        int row = 0;

        List<StringBuilder> rows = [];

        for (int i = 0; i < numRows; i++)
        {
            rows.Add(new StringBuilder());
        }

        foreach (char c in s)
        {
            rows[row].Append(c);

            if (movingDown)
            {
                row++;

                if (row >= numRows)
                {
                    row = numRows - 2;
                    movingDown = false;
                }
            }
            else
            {
                row--;

                if (row < 0)
                {
                    row = 1;
                    movingDown = true;
                }
            }
        }

        return string.Join("", rows);
    }
}
