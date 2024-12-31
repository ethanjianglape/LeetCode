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

// https://leetcode.com/problems/count-ways-to-build-good-strings/description/

using System.Text;

namespace LeetCode.Solutions;

public class CountWaysToBuildGoodStrings
{
    public static int CountGoodStrings(int low, int high, int zero, int one)
    {
        const int mod = 1000000007;

        // dp (standing for "dynamic programming") will be used to calculate how many good strings
        // can be made for each string length. So the index of this array is the length of the
        // strings it is representing, and the value is how many strings there are.
        //
        // An example: low = 2, high = 4, zero = 1, one = 2
        // dp[0] = 1: because there is only 1 possible string of length 0, which is "", regardless of the values of low, high, zero, and one.
        // dp[1] = 1: "0"
        // dp[2] = 2: "00", "11"
        // dp[3] = 3: "000", "011", "110"
        // dp[4] = 5: "0000", "0011", "0110", "1100", "1111"
        //
        // Note that we are not actually creating or storing these strings anywhere, the only thing we care about is
        // what length they 'would' be if we actually did generate each one.
        int[] dp = new int[high + 1];

        dp[0] = 1;

        // Now that dp has been initialized, it should look like this: [1, 0, 0, 0, ..., 0].
        // Next we are going to loop through every possible string length, which is from 1 to high.
        for (int stringLength = 1; stringLength <= high; stringLength ++)
        {
            // A good way to think about this loop is that we are building "imaginary" strings as we go along.
            // But the actual values of the string like "000", "1100", "11", won't really be created.
            //
            // To start with, we begin with stringLength = 1, which will be every possible good string that only
            // has a length of 1. In order to get to a string of length 1.
            //
            // Now it's time to check if it would actually be possible to make any strings of length 1 based on
            // the values of 'zero' and 'one'.
            //
            // We do this by simply checking if our current stringLength is >= zero or one.
            // Here is why this works:
            // If our current stringLength is 1, and the value of 'zero' is 2, meaning we would be appending "00" to
            // our imaginary string, then this would not work, because that would make our string too long. But for the
            // value of 'one' which is 1, we would be appending "1", which will work.
            if (stringLength >= zero)
            {
                // If we have determined that it would be possible to add 'zero' to our current imaginary string
                // of length 'stringLength' what we need to do is determine how many string there existed in the chain
                // to get here.
                //
                // Remember that dp[index] tells us how many good strings exist for any string of length 'index',
                // so getting the value of dp[stringLength - zeros] tells us how many good strings already existed
                // before we decided to add 'zero'.
                // 
                // Based on the example shown above, if we are currently on stringLength = 1 and since zero = 1 then we would
                // be trying to add a single "0" to an empty string "". How many good string exist for the empty string?
                // This was our hard-coded base case up above, which is dp[0] = 1. To get to that valy dynamically, we just
                // do stringLength - zero, which here will be 1 - 1 == 0, so we add dp[0] to dp[stringLength].
                //
                // This ultimately tells us that if we start with "" and try to add a single "0" to it, we will end up with
                // a single good string, hence dp[1] = 1 as listed up above.
                dp[stringLength] += dp[stringLength - zero];
            }

            if (stringLength >= one)
            {
                dp[stringLength] += dp[stringLength - one];
            }

            dp[stringLength] %= mod;
        }

        int result = 0;

        for (int length = low; length <= high; length++)
        {
            result += dp[length];
            result %= mod;
        }

        return result;
    }

    public static int Build(int stringLength, int minLength, int maxLength, int numZeros, int numOnes)
    {
        int score = stringLength >= minLength &&
                    stringLength <= maxLength ? 1 : 0;

        if (stringLength >= maxLength)
        {
            return score;
        }

        stringLength += numZeros;
        score += Build(stringLength, minLength, maxLength, numZeros, numOnes);
        stringLength -= numZeros;

        stringLength += numOnes;
        score += Build(stringLength, minLength, maxLength, numZeros, numOnes);
        stringLength -= numOnes;

        return score;
    }
}
