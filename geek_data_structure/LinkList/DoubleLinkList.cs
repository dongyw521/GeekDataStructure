namespace geek_data_structure.LinkList;

/// <summary>
/// 双链表
/// </summary>
/// <typeparam name="T"></typeparam>
internal class DoubleLinkList<T>
{
    public DoubleLinkListNode<T> First;
    public DoubleLinkListNode<T> Last;
    public int NodeCount { get; private set; } = 0;

    public bool IsEmpty()
    {
        return NodeCount <= 0;
    }

    public void Clear()
    {
        First = null;
        Last = null;
        NodeCount = 0;
    }

    #region 新增
    public void AddFirst(T data)
    {
        var tmpNode = new DoubleLinkListNode<T>(data);
        if (IsEmpty())
        {
            First = tmpNode;
            Last = tmpNode;
        }
        else
        {
            tmpNode.next = First;
            First.prev = tmpNode;
            First = tmpNode;//不要忘记修改First
        }
        NodeCount++;
    }

    public void AddLast(T data)
    {
        var tmpNode = new DoubleLinkListNode<T>(data);
        if (IsEmpty())
        {
            First = tmpNode;
            Last = tmpNode;
        }
        else
        {
            Last.next = tmpNode;
            tmpNode.prev = Last;
            Last = tmpNode;
        }
        NodeCount++;
    }

    public bool AddAt(T data, int idx)
    {
        if (idx <= 0 || idx > NodeCount) return false;
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
        var prevNode = First;
        var curNode = First.next;
        var tmpNode = new DoubleLinkListNode<T>(data);
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        tmpNode.next = curNode;
        prevNode.next = tmpNode;
        tmpNode.prev = prevNode;
        curNode.prev = tmpNode;
        NodeCount++;
        return true;
    }
    #endregion

    #region 删除
    public bool RemoveFirst()
    {
        if (IsEmpty()) return false;
        if (NodeCount > 1)
        {
            First = First.next;
            First.prev = null;
        }
        else
        {
            First = null;
            Last = null;
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

        var prevNode = First;
        var curNode = First.next;
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        if (idx == NodeCount - 1)
        {
            prevNode.next = null;
            Last = prevNode;
        }
        else
        {
            curNode.next.prev = prevNode;
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

internal class DoubleLinkListNode<T>
{
    public T data;
    public DoubleLinkListNode<T> prev;
    public DoubleLinkListNode<T> next;

    public DoubleLinkListNode(T _data)
    {
        data = _data;
    }

}
