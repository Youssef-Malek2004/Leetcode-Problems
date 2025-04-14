namespace Leetcode_Problems.Medium;

public class SwapNodesInPairsSolution
{
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null)
            return head;

        var temp = head.next;
        head.next = head.next.next;
        temp.next = head;
        head = temp;

        var current = head.next;
        while(current.next != null && current.next.next != null){
            temp = current.next.next;
            current.next.next = current.next.next.next;
            temp.next = current.next;
            current.next = temp;

            current = current.next.next;
        }

        return head;
        
    }
}