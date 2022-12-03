namespace Konigsberg.LeetCode;

public sealed class Problem2
{
    public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 == null)
        {
            return null;
        }

        var sum = (l1?.Val ?? 0) + (l2?.Val ?? 0);

        if (sum >= 10)
        {
            sum -= 10;

            if (l1.Next != null)
            {
                l1.Next.Val += 1;
            }
            else
            {
                l1.Next = new ListNode(1);
            }
        }

        var node = new ListNode(sum);
        node.Next = AddTwoNumbers(l1?.Next, l2?.Next);

        return node;
    }
}

public sealed class ListNode {
    public int Val;
    public ListNode? Next;

    public ListNode(int[] array)
    {
        Val = array.Take(1).Single();
        var nextArray = array.TakeLast(array.Length - 1).ToArray();
        if (nextArray.Length > 0)
        {
            Next = new ListNode(nextArray);
        }
    }

    public ListNode(int val = 0, ListNode? next = null) {
        Val = val;
        Next = next;
    }

    public int[] ToArray() => Next == null ? new[] { Val } : new[] { Val }.Concat(Next.ToArray()).ToArray();
}