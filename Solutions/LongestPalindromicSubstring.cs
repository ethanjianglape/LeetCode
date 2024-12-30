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

// https://leetcode.com/problems/longest-palindromic-substring/description/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions;

public class LongestPalindromicSubstring
{
    public static string? LongestPalindrome(string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        if (s.Length == 0 || s.Length == 1)
        {
            return s;
        }

        string longestPalindrome = "";

        for (int i = 0; i < s.Length; i++)
        {
            char ci = s[i];

            for (int j = i + longestPalindrome.Length; j < s.Length; j++)
            {
                char cj = s[j];

                if (ci != cj)
                {
                    continue;
                }

                int left = i;
                int right = j + 1;
                string substring = s[left..right];

                if (IsPalindrome(substring) && substring.Length > longestPalindrome.Length)
                {
                    longestPalindrome = substring;
                }
            }
        }

        return longestPalindrome;
    }

    public static bool IsPalindrome(string s)
    {
        if (s.Length == 0 || s.Length == 1)
        {
            return true;
        }

        int l = 0;
        int r = s.Length - 1;

        while (l < r)
        {
            char lc = s[l++];
            char rc = s[r--];

            if (lc != rc)
            {
                return false;
            }
        }

        return true;
    }
}
