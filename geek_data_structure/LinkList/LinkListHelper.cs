namespace geek_data_structure.LinkList;

/// <summary>
/// 单链表之间相关操作
/// </summary>
internal class LinkListHelper
{
    /// <summary>
    /// 合并两个有序单链表
    /// </summary>
    /// <param name="listNodeA"></param>
    /// <param name="listNodeB"></param>
    /// <returns></returns>
    public SingleLinkListNode<int> MergeTowIntLinkLists(SingleLinkListNode<int> listNodeA, SingleLinkListNode<int> listNodeB)
    {
        if (listNodeA == null || listNodeB == null)
        {
            return listNodeA != null ? listNodeA : listNodeB;
        }
        var newHead = new SingleLinkListNode<int>(0);
        var tail = newHead;
        while (listNodeA != null && listNodeB != null)
        {
            if (listNodeA.data < listNodeB.data)
            {
                tail.next = listNodeA;
                listNodeA = listNodeA.next;
            }
            else
            {
                tail.next = listNodeB;
                listNodeB = listNodeB.next;
            }
            tail = tail.next;
        }
        tail.next = listNodeA != null ? listNodeA : listNodeB;
        return newHead.next;
    }

    /// <summary>
    /// 合并K个有序链表
    /// 顺序合并法
    /// </summary>
    /// <param name="listNodes"></param>
    /// <returns></returns>
    public SingleLinkListNode<int> MergeKIntLinkLists(SingleLinkListNode<int>[] listNodes)
    {
        SingleLinkListNode<int> result = null;
        foreach (var _node in listNodes)
        {
            result = MergeTowIntLinkLists(result, _node);
        }
        return result;
    }

    /// <summary>
    /// 合并K个有序链表
    /// 分治,递归的思想。还是归并排序的思想，分成两部分，然后再往上合并
    /// </summary>
    /// <param name="listNodes"></param>
    /// <returns></returns>
    public SingleLinkListNode<int> MergeKIntLinkLists_FenZhi(SingleLinkListNode<int>[] listNodes)
    {
        // SingleLinkListNode<int> result = null;
        // var length = listNodes.Length;
        // if (length <= 1) return listNodes[0];

        // var firstList = listNodes[0];
        // var secondList = listNodes[1];
        // for (int i = 2; i < length; i++)
        // {

        // }
        return MergeRecursion(listNodes, 0, listNodes.Length - 1);
    }

    /// <summary>
    /// 删除中间节点
    /// 通过快慢指针，当快指针为空，或者快指针的next为空时，慢指针slow就是中间节点
    /// </summary>
    /// <param name="head"></param>
    public SingleLinkListNode<int> DeleteMiddleNode(SingleLinkListNode<int> head)
    {
        if (head == null || head.next == null)
        {
            head = null;
            return head;
        }
        var fast = head;
        var slow = head;
        SingleLinkListNode<int> prev = null;
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            prev = slow;
            slow = slow.next;
        }
        prev.next = slow.next;
        return head;
    }

    /// <summary>
    /// 递归合并
    /// </summary>
    /// <param name="listNodes"></param>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    private SingleLinkListNode<int> MergeRecursion(SingleLinkListNode<int>[] listNodes, int l, int r)
    {
        if (l == r)
        {
            return listNodes[l];
        }
        if (l > r)//listNodes为空时，l==0,r==-1
        {
            return null;
        }

        var mid = (l + r) >> 1;//l+r除以2的商
        return MergeTowIntLinkLists(MergeRecursion(listNodes, l, mid), MergeRecursion(listNodes, mid + 1, r));
    }

}
