// https://leetcode.com/problems/two-sum/description/

namespace LeetCode;

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
