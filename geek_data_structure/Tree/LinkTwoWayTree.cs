namespace geek_data_structure.Tree;

// <summary>
/// 三向链表实现满二叉树
/// 参考：https://segmentfault.com/q/1010000042505563
/// </summary>
public class LinkTwoWayTree<T>
{
    public readonly ListNode<T> root;

    public LinkTwoWayTree(T val, int depth)
    {
        if (depth <= 0)
            throw new ArgumentException("树的层数错误，层数必须大于0");
        var rootNode = new ListNode<T>();
        rootNode.val = val;
        if (depth > 1)
        {
            rootNode.LeftChild = CreateSubTree(rootNode, default(T), depth - 1);
            rootNode.RightChild = CreateSubTree(rootNode, default(T), depth - 1);
        }
        root = rootNode;
    }

    private ListNode<T> CreateSubTree(ListNode<T> parent, T val, int depth)
    {
        var tmpNode = new ListNode<T>();
        tmpNode.Parent = parent;
        tmpNode.val = val;
        if (depth > 1)
        {
            tmpNode.LeftChild = CreateSubTree(tmpNode, default(T), depth - 1);
            tmpNode.RightChild = CreateSubTree(tmpNode, default(T), depth - 1);
        }
        return tmpNode;
    }

    public void PrintTree(ListNode<T> rt)
    {
        if (rt != null)
        {
            Console.WriteLine($"{rt.Parent}----->{rt.val}");
            if (rt.LeftChild != null)
                PrintTree(rt.LeftChild);
            if (rt.RightChild != null)
                PrintTree(rt.RightChild);
        }
        else
        {
            Console.WriteLine($"树为空，没有数据");
        }
    }

    #region 用于演示
    public LinkTwoWayTree()
    {

    }

    public ListNode<int> BuildIntTree(int val, int depth)
    {
        if (depth <= 0)
            throw new ArgumentException("树的层数错误，层数必须大于0");
        var rootNode = new ListNode<int>();
        rootNode.val = val;
        if (depth > 1)
        {
            rootNode.LeftChild = CreateIntSubTree(rootNode, val *= 2, depth - 1);
            rootNode.RightChild = CreateIntSubTree(rootNode, val += 1, depth - 1);
        }
        return rootNode;
    }

    private ListNode<int> CreateIntSubTree(ListNode<int> parent, int val, int depth)
    {
        var tmpNode = new ListNode<int>();
        tmpNode.Parent = parent;
        tmpNode.val = val;
        if (depth > 1)
        {
            tmpNode.LeftChild = CreateIntSubTree(tmpNode, val *= 2, depth - 1);
            tmpNode.RightChild = CreateIntSubTree(tmpNode, val += 1, depth - 1);
        }
        return tmpNode;
    }



    


    /*
    public ListNode<int> BuildValIntTree(int val, ListNode<int>? parent, int layerCount)
    {
        var tmpNode = new ListNode<int>();
        tmpNode.val = val;
        tmpNode.Parent = parent;
        if (--layerCount > 0)
        {
            tmpNode.LeftChild = BuildValIntTree(val *= 2, tmpNode, layerCount);
            tmpNode.RightChild = BuildValIntTree(val += 1, tmpNode, layerCount);
        }
        return tmpNode;
    }

    public void PrintTree<T>(ListNode<T>? nodeItem) where T : struct
    {
        Console.WriteLine($"{nodeItem?.Parent}-->{nodeItem}");
        if (nodeItem?.LeftChild != null)
            PrintTree<T>(nodeItem?.LeftChild);
        if (nodeItem?.RightChild != null)
            PrintTree<T>(nodeItem?.RightChild);
    }
    */
    #endregion
}

public class ListNode<T>
{
    public T val { get; set; }
    public ListNode<T>? LeftChild { get; set; }
    public ListNode<T>? RightChild { get; set; }
    public ListNode<T>? Parent { get; set; }

    public override string ToString()
    {
        return val.ToString();
    }
}
