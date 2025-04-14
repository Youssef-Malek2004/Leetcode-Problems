namespace Leetcode_Problems.Hard;

public class ReverseNodesInKGroupSolution
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
    }
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(head == null || head.next == null)
            return head;
        
        var counter = 0;
        var current = head;
        while(current != null){
            current = current.next;
            counter++;
        }

        if(counter < k)
            return head;

        current = new ListNode();
        current.next = head;

        var temp = current;

        while(counter >= k){
            var saved = GetSavedIndex(current.next,k);
            var partitioned = GetPartition(current.next,k);
            var Reversed = ReverseList(partitioned);
            current.next = Reversed;
            counter -= k;
            var LastElementReversed = GetLastElement(Reversed);
            LastElementReversed.next = saved;
            current = LastElementReversed;
        }

        return temp.next;
    }
    public ListNode GetLastElement(ListNode node){
        var current = node;
        while(current.next != null)
            current = current.next;
        return current;
    }
    public ListNode GetSavedIndex(ListNode node, int k){
        if(node is null)
            return null;

        var returned = node;

        while(k > 0){
            returned = returned.next;
            k--;
        }

        return returned;
    }
    public ListNode GetPartition(ListNode node, int k){
        var returnedHead = node;
        var current = node;
        while(k > 1){
            current = current.next;
            k--;
        }
        current.next = null;
        return returnedHead;
    }
    public ListNode ReverseList(ListNode head){
        if(head == null || head.next == null)
            return head;

        var current = head;
        while(current.next != null)
            current = current.next;

        ReverseListHelper(head);
        head.next = null;

        return current;
    }
    public void ReverseListHelper(ListNode node){
        if(node.next == null)
            return;
        ReverseListHelper(node.next);
        node.next.next = node;
    }
}