namespace geek_data_structure.Tree;

/// <summary>
/// 四向链表表示三叉树
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkThreeWayTree<T>
{
    public readonly LinkTreeNode<T> root;
    public LinkThreeWayTree(T val, int depth)
    {
        if (depth <= 0)
            throw new ArgumentException("树的高度指定错误，需要大于等于1");
        var rootNode = new LinkTreeNode<T>(val);
        if (depth > 1)
        {
            rootNode.Left = CreateSubTree(rootNode, default(T), depth - 1);
            rootNode.Middle = CreateSubTree(rootNode, default(T), depth - 1);
            rootNode.Right = CreateSubTree(rootNode, default(T), depth - 1);
        }
        root = rootNode;
    }

    /// <summary>
    /// 创建子树
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="val"></param>
    /// <param name="depth"></param>
    /// <returns></returns>
    private LinkTreeNode<T> CreateSubTree(LinkTreeNode<T> parent, T val, int depth)
    {
        var tmpNode = new LinkTreeNode<T>(val);
        tmpNode.Parent = parent;
        tmpNode.Val = val;
        if (depth > 1)
        {
            tmpNode.Left = CreateSubTree(tmpNode, default(T), depth - 1);
            tmpNode.Right = CreateSubTree(tmpNode, default(T), depth - 1);
            tmpNode.Middle = CreateSubTree(tmpNode, default(T), depth - 1);
        }
        return tmpNode;
    }

    /// <summary>
    /// 打印节点
    /// </summary>
    /// <param name="rootNode"></param>
    public void PrintTree(LinkTreeNode<T> rt)
    {
        if (rt != null)
        {
            Console.WriteLine($"{rt.Parent}---->{rt.Val}");
            if (rt.Left != null)
                PrintTree(rt.Left);
            if (rt.Right != null)
                PrintTree(rt.Right);
            if (rt.Middle != null)
                PrintTree(rt.Middle);
        }
        else
        {
            Console.WriteLine($"树已空，无法打印");
        }
    }

    #region 用于演示

    public LinkThreeWayTree()
    {

    }

    public LinkTreeNode<int> BuildIntThreeWayTree(int val, int depth)
    {
        if (depth <= 0)
            throw new ArgumentException("树的高度指定错误，需要大于等于1");
        var rootNode = new LinkTreeNode<int>(val);
        if (depth > 1)
        {
            rootNode.Left = CreateIntSubTree(rootNode, val * 3 - 1, depth - 1);
            rootNode.Middle = CreateIntSubTree(rootNode, val * 3, depth - 1);
            rootNode.Right = CreateIntSubTree(rootNode, val * 3 + 1, depth - 1);
        }
        return rootNode;
    }

    private LinkTreeNode<int> CreateIntSubTree(LinkTreeNode<int> parent, int val, int depth)
    {
        var tmpNode = new LinkTreeNode<int>(val);
        tmpNode.Parent = parent;
        if (depth > 1)
        {
            tmpNode.Left = CreateIntSubTree(tmpNode, val * 3 - 1, depth - 1);
            tmpNode.Right = CreateIntSubTree(tmpNode, val * 3, depth - 1);
            tmpNode.Middle = CreateIntSubTree(tmpNode, val * 3 + 1, depth - 1);
        }
        return tmpNode;
    }

    /// <summary>
    /// 打印节点
    /// </summary>
    /// <param name="rootNode"></param>
    public void PrintIntTree(LinkTreeNode<T> rootNode)
    {
        Console.WriteLine($"{rootNode.Parent}---->{rootNode.Val}");
        if (rootNode.Left != null)
            PrintIntTree(rootNode.Left);
        if (rootNode.Right != null)
            PrintIntTree(rootNode.Right);
        if (rootNode.Middle != null)
            PrintIntTree(rootNode.Middle);

    }

    #endregion
}

public class LinkTreeNode<T>
{
    public T Val { get; set; }
    public LinkTreeNode<T>? Parent { get; set; }
    public LinkTreeNode<T>? Left { get; set; }
    public LinkTreeNode<T>? Middle { get; set; }
    public LinkTreeNode<T>? Right { get; set; }

    public LinkTreeNode(T val)
    {
        Val = val;
    }

    public override string ToString()
    {
        return Val.ToString();
    }
}
