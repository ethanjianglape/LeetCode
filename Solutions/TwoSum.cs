/*
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

// https://leetcode.com/problems/two-sum/description/

namespace LeetCode.Solutions;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        ArgumentNullException.ThrowIfNull(nums);
        ArgumentOutOfRangeException.ThrowIfLessThan(nums.Length, 2);

        for (int i = 0; i < nums.Length; i++)
        {
            int num1 = nums[i];

            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                int num2 = nums[j];

                if (num1 + num2 == target)
                {
                    return [i, j];
                }
            }
        }

        throw new NotImplementedException();
    }
}
