namespace Leetcode_Problems.Medium;

public class ListNode {
    public int val;
    public ListNode next;
        
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
    
    public static void PrintListNode(ListNode head) {
        ListNode current = head;
        while (current != null) {
            Console.Write(current.val);
            if (current.next != null) {
                Console.Write(" -> ");
            } else {
                Console.Write(" -> null");
            }
            current = current.next;
        }
        Console.WriteLine();
    }
}



public class AddTwoNumbersSolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode outputNode = new ListNode(0);
        ListNode temp = outputNode;

        int residual = 0;

        while (l1 is not null || l2 is not null)
        {
            if(temp is null) temp = new ListNode();
            
            int sum = residual;
            
            if (l1 is not null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 is not null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            residual = sum / 10;
            sum = sum % 10;

            temp.next = new ListNode(sum);
            temp = temp.next;
        }

        if (residual > 0)
        {
            temp.next = new ListNode(residual);
        }

        return outputNode.next;
    }
    
}
