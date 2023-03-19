namespace geek_data_structure.LinkList;

internal class SingleLinkList<T>
{
    /// <summary>
    /// 头结点
    /// </summary>
    public SingleLinkListNode<T> First;

    /// <summary>
    /// 尾结点
    /// </summary>
    public SingleLinkListNode<T> Last;

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
    public void AddFirst(T _data)
    {
        var tmpNode = new SingleLinkListNode<T>(_data);
        if (IsEmpty())
        {
            First = tmpNode;
            Last = tmpNode;
        }
        else
        {
            tmpNode.next = First;
            First = tmpNode;
        }

        NodeCount++;
    }

    public void AddLast(T _data)
    {

        var tmpNode = new SingleLinkListNode<T>(_data);
        if (IsEmpty())
        {
            First = tmpNode;
            Last = tmpNode;
        }
        else
        {
            Last.next = tmpNode;
            Last = tmpNode;//需要重新修改尾结点
        }

        NodeCount++;
    }

    public bool AddAt(T _data, int idx)
    {
        if (idx < 0 || idx > NodeCount)
        {
            //return false;
            throw new ArgumentException("插入位置有误");
        }
        if (idx == 0)
        {
            AddFirst(_data);
            return true;
        }
        if (idx == NodeCount)
        {
            AddLast(_data);
            return true;
        }


        var tmpNode = new SingleLinkListNode<T>(_data);
        // SingleLinkListNode<T> prevNode = First;
        // for (int i = 1; i < NodeCount; i++)
        // {
        //     var curNode = First.next;
        //     if (i == idx)
        //     {
        //         break;
        //     }
        //     else
        //     {
        //         prevNode = curNode;
        //         curNode = curNode.next;
        //     }
        // }

        //更好的方式
        var prevNode = First;
        var curNode = First.next;
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        tmpNode.next = prevNode.next;
        prevNode.next = tmpNode;
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
        }
        else
        {
            First = null;
            Last = null;
        }
        NodeCount--;
        return true;
    }

    public bool RemoveLast()
    {
        return RemoveAt(NodeCount - 1);
    }

    public bool RemoveAt(int idx)
    {
        if (IsEmpty()) return false;
        if (idx < 0 || idx >= NodeCount) return false;
        if (idx == 0) return RemoveFirst();
        var prevNode = First;
        var curNode = First.next;
        for (int i = 1; i < idx; i++)
        {
            prevNode = prevNode.next;
            curNode = curNode.next;
        }
        if (idx == NodeCount - 1)
        {
            Last = prevNode;
            prevNode.next = null;
        }
        else
        {
            prevNode.next = curNode.next;
        }
        NodeCount--;
        return true;

    }
    #endregion

    #region 检测是否有环
    public bool HasCycle()
    {
        var ret = false;
        if (IsEmpty() || NodeCount == 1) ret = false;
        else
        {
            var fastNode = First;
            var slowNode = First;
            while (fastNode != null && fastNode.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;
                if (fastNode == slowNode)
                {
                    ret = true;
                    break;
                }
            }
        }
        return ret;
    }
    #endregion

}

/// <summary>
/// 节点
/// </summary>
/// <typeparam name="T"></typeparam>
internal class SingleLinkListNode<T>
{
    public T data;
    public SingleLinkListNode<T> next;

    public SingleLinkListNode(T _data)
    {
        data = _data;
    }

    public override string ToString()
    {
        return data.ToString();
    }
}
