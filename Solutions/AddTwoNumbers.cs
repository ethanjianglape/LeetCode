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

// https://leetcode.com/problems/add-two-numbers/

namespace LeetCode.Solutions;

public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
 

public class AddTwoNumbers
{
    public ListNode? Solution(ListNode? l1, ListNode? l2)
    {
        ArgumentNullException.ThrowIfNull(l1);
        ArgumentNullException.ThrowIfNull(l2);

        bool carry = false;

        ListNode? root = null;
        ListNode? prev = null;

        while (l1 != null || l2 != null || carry)
        {
            int val1 = l1?.val ?? 0;
            int val2 = l2?.val ?? 0;
            int sum = val1 + val2 + (carry ? 1 : 0);

            carry = sum >= 10;

            if (carry)
            {
                sum -= 10;
            }

            ListNode node = new(sum);

            root ??= node;

            if (prev != null)
            {
                prev.next = node;
            }

            l1 = l1?.next;
            l2 = l2?.next;
            prev = node;
        }

        return root;
    }
}
