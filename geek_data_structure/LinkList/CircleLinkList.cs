namespace geek_data_structure.LinkList;

internal class CircleLinkList<T>
{
    public SingleLinkListNode<T> Last;

    public int NodeCount { get; private set; } = 0;

    public bool IsEmpty()
    {
        return NodeCount <= 0;
    }

    public void Clear()
    {
        Last = null;
        NodeCount = 0;
    }

    #region 增加
    public void AddFirst(T data)
    {
        var tmpNode = new SingleLinkListNode<T>(data);
        if (IsEmpty())
        {
            Last = tmpNode;
            Last.next = Last;//这个不能丢
        }
        else
        {
            tmpNode.next = Last.next;
            Last.next = tmpNode;
        }
        NodeCount++;
    }

    public void AddLast(T data)
    {
        var tmpNode = new SingleLinkListNode<T>(data);
        if (IsEmpty())
        {
            Last = tmpNode;
            Last.next = Last;
        }
        else
        {
            tmpNode.next = Last.next;
            Last.next = tmpNode;
            Last = tmpNode;
        }
        NodeCount++;
    }

    public bool AddAt(T data, int idx)
    {
        if (idx < 0 || idx > NodeCount) return false;
        if (idx == 0)
        {
            AddFirst(data);
            return true;
        }
        if (idx == NodeCount)
        {
            AddLast(data);
            return true;
        }
        var tmpNode = new SingleLinkListNode<T>(data);
        var prevNode = Last.next;
        var curNode = prevNode.next;
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        tmpNode.next = curNode;
        prevNode.next = tmpNode;
        NodeCount++;
        return true;


    }
    #endregion

    #region 删除
    public bool RemoveFirst()
    {
        if (IsEmpty()) return false;
        if (NodeCount == 1)
        {
            Last = null;
        }
        else
        {
            Last.next = Last.next.next;
        }
        NodeCount--;
        return true;
    }

    public bool RemoveAt(int idx)
    {
        if (IsEmpty()) return false;
        if (idx < 0 || idx >= NodeCount) return false;
        if (idx == 0)
        {
            return RemoveFirst();
        }
        var prevNode = Last.next;
        var curNode = Last.next.next;
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        if (idx == NodeCount - 1)
        {
            prevNode.next = curNode.next;
            Last = prevNode;
        }
        else
        {
            prevNode.next = curNode.next;
        }
        NodeCount--;
        return true;
    }

    public bool RemoveLast()
    {
        return RemoveAt(NodeCount - 1);
    }
    #endregion 
}
