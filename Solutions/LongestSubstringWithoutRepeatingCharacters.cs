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

// https://leetcode.com/problems/longest-substring-without-repeating-characters/

namespace LeetCode.Solutions;

public class LongestSubstringWithoutRepeatingCharacters
{
    public static int LengthOfLongestSubstring(string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        int i = 0;
        int max = 0;

        Queue<char> queue = new();

        while (i < s.Length)
        {
            char c = s[i];

            if (queue.Contains(c))
            {
                queue.Dequeue();
            }
            else
            {
                queue.Enqueue(c);
                max = Math.Max(max, queue.Count);
                i++;
            }
        }

        return max;
    }
}
