namespace geek_data_structure.LinkList;

/// <summary>
/// 单链表
/// </summary>
/// <typeparam name="T"></typeparam>
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

    public int NodeCount { get; set; } = 0;

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

    public void Print()
    {
        if (!IsEmpty())
        {
            Console.Write($"{First}");
            PrintNextNode(First.next);
        }
    }

    private void PrintNextNode(SingleLinkListNode<T> next)
    {
        Console.Write($"-->{next}");
        if (next.next != null)
            PrintNextNode(next.next);
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

    #region 单链表反转
    public void ReverseSingleLinkList()
    {
        if (this.IsEmpty())
            throw new Exception("原链表为空，反转错误");

        #region 自己实现
        /*自己实现
        var prevNode = First;
        var curNode = First.next;
        var nextNode = curNode.next;
        for (int i = 1; i < NodeCount; i++)
        {
            curNode.next = prevNode;
            if (i < NodeCount - 1)
            {
                prevNode = curNode;
                curNode = nextNode;
                nextNode = nextNode.next;
            }
        }
        First.next = null;
        var tmp = First;
        First = Last;
        Last = tmp;
        */
        #endregion

        #region 力扣迭代方式
        /*力扣迭代方式
        SingleLinkListNode<T> prevNode = null;
        SingleLinkListNode<T> currNode = First;
        Last = First;
        while (currNode != null)
        {
            var nextNode = currNode.next;
            currNode.next = prevNode;
            prevNode = currNode;
            currNode = nextNode;
        }
        First = prevNode;
        */
        #endregion

        #region 力扣递归方式，有点归并排序的意思
        /*力扣递归方式*/
        Last = First;
        First = _ReverseLinkList(First);
        #endregion

    }

    /// <summary>
    /// 力扣上递归实现单链表反转，有点归并排序的意思
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    private SingleLinkListNode<T> _ReverseLinkList(SingleLinkListNode<T> head)
    {
        if (head == null || head.next == null)
        {
            return head;//终止条件，直到返回最后一个元素
        }
        var p = _ReverseLinkList(head.next);
        head.next.next = head;//层层往上归的时候，head都不同，一直到第一个元素。
        head.next = null;//第一个元素需要这样设置，其实递归中的其他元素不用这个null
        return p;

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
