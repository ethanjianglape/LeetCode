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

// https://leetcode.com/problems/median-of-two-sorted-arrays/

namespace LeetCode.Solutions;

public class MedianOfTwoSortedArrays
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        ArgumentNullException.ThrowIfNull(nums1);
        ArgumentNullException.ThrowIfNull(nums2);

        int i = 0;
        int j = 0;

        List<double> merged = new(nums1.Length + nums2.Length);

        while (i < nums1.Length && j < nums2.Length)
        {
            int num1 = nums1[i];
            int num2 = nums2[j];

            if (num1 < num2)
            {
                merged.Add(num1);
                i++;
            }
            else
            {
                merged.Add(num2);
                j++;
            }
        }

        while (i < nums1.Length)
        {
            merged.Add(nums1[i++]);
        }

        while (j < nums2.Length)
        {
            merged.Add(nums2[j++]);
        }

        int length = merged.Count;
        int index = length / 2;

        if (length % 2 == 0)
        {
            return (merged[index] + merged[index - 1]) / 2;
        }

        return merged[index];
    }
}
