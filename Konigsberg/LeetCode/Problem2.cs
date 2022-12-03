namespace Konigsberg.LeetCode;

public sealed class Problem2
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 == null)
        {
            return null;
        }

        var sum = (l1?.val ?? 0) + (l2?.val ?? 0);

        if (sum >= 10)
        {
            sum -= 10;

            if (l1.next != null)
            {
                l1.next.val += 1;
            }
            else
            {
                l1.next = new ListNode(1);
            }
        }

        var node = new ListNode(sum);
        node.next = AddTwoNumbers(l1?.next, l2?.next);

        return node;
    }
}

public class ListNode {
    public int val;
    public ListNode? next;

    public ListNode(int[] array)
    {
        val = array.Take(1).Single();
        var nextArray = array.TakeLast(array.Length - 1).ToArray();
        if (nextArray.Length > 0)
        {
            next = new ListNode(nextArray);
        }
    }

    public ListNode(int val = 0, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }

    public int[] ToArray()
    {
        if (next == null)
        {
            return new[] { val };
        }
        else
        {
            return new[] { val }.Concat(next.ToArray()).ToArray();
        }
    }
}