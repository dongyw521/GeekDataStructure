using System.Reflection.Metadata;
namespace geek_data_structure.Tree;

/// <summary>
/// 二叉查找树
/// 参考：https://blog.csdn.net/weixin_38170862/article/details/99628985
/// </summary>
/// <typeparam name="T"></typeparam>
public class SearchTwoWayTree<T>
{
    public SearchTwoWayTreeNode<T> RootNode { get; set; }

    /// <summary>
    /// 新增节点
    /// </summary>
    /// <param name="node"></param>
    public void Insert(SearchTwoWayTreeNode<T> node)
    {
        if (RootNode == null)
        {
            RootNode = node;
        }
        else
        {
            var currNode = RootNode;
            while (true)
            {
                var _parentNode = currNode;
                if (node.Key < currNode.Key)
                {
                    currNode = currNode.Left;
                    if (currNode == null)
                    {
                        _parentNode.Left = node;
                        break;
                    }
                }
                else
                {
                    currNode = currNode.Right;
                    if (currNode == null)
                    {
                        _parentNode.Right = node;
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 中序遍历
    /// </summary>
    public void InOrder(SearchTwoWayTreeNode<T> _rootNode)
    {
        // while (_rootNode.Left != null)
        // {
        //     _rootNode = RootNode.Left;
        // }
        // Console.Write(_rootNode.Key);

        if (_rootNode != null)
        {
            InOrder(_rootNode.Left);
            Console.Write(_rootNode.Key + " ");
            InOrder(_rootNode.Right);
        }

    }

    /// <summary>
    /// 前序遍历
    /// </summary>
    /// <param name="_rootNode"></param>
    public void PreOrder(SearchTwoWayTreeNode<T> _rootNode)
    {
        if (_rootNode != null)
        {
            Console.Write(_rootNode.Key + " ");
            PreOrder(_rootNode.Left);
            PreOrder(_rootNode.Right);
        }
    }

    /// <summary>
    /// 后序遍历
    /// </summary>
    /// <param name="_rootNode"></param>
    public void LastOrder(SearchTwoWayTreeNode<T> _rootNode)
    {
        if (_rootNode != null)
        {
            LastOrder(_rootNode.Left);
            LastOrder(_rootNode.Right);
            Console.Write(_rootNode.Key + " ");
        }
    }

    /// <summary>
    /// 按层遍历，从上到下，从左到右
    /// 需要借助队列来实现
    /// </summary>
    /// <param name="_rootNode"></param>
    public void LayerOrder(SearchTwoWayTreeNode<T> _rootNode)
    {
        if (_rootNode != null)
        {
            Queue<SearchTwoWayTreeNode<T>> _queue = new Queue<SearchTwoWayTreeNode<T>>();
            _queue.Enqueue(_rootNode);
            while (_queue.Any())
            {
                //var qsize = _queue.Count();
                //Console.WriteLine(qsize);
                var tmpNode = _queue.Dequeue();
                Console.Write($"{tmpNode.Key} ");
                if (tmpNode.Left != null)
                {
                    _queue.Enqueue(tmpNode.Left);
                }
                if (tmpNode.Right != null)
                {
                    _queue.Enqueue(tmpNode.Right);
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Z型按层遍历
    /// 需要借助双端队列，每一层节点都放到一个双端队列里，最后再把所有的双端队列放到一个list里。
    /// </summary>
    /// <param name="_rootNode"></param>
    public void LayerZOrder(SearchTwoWayTreeNode<T> _rootNode)
    {
        if (_rootNode != null)
        {
            //正常队列
            Queue<SearchTwoWayTreeNode<T>> _queue = new Queue<SearchTwoWayTreeNode<T>>();

            //双端队列其实就是一个双链表，把双端队列放到一个List里
            //[[10],[14,6],[5,7,13,15]]
            List<LinkedList<SearchTwoWayTreeNode<T>>> linkedList = new List<LinkedList<SearchTwoWayTreeNode<T>>>();

            bool isLeftOrder = true;
            _queue.Enqueue(_rootNode);

            while (_queue.Any())
            {
                var qsize = _queue.Count();
                //Console.WriteLine(qsize);
                var _linkedList = new LinkedList<SearchTwoWayTreeNode<T>>();
                for (int i = 0; i < qsize; i++)
                {
                    var _item = _queue.Dequeue();
                    if (isLeftOrder)
                    {
                        _linkedList.AddLast(_item);
                    }
                    else
                    {
                        _linkedList.AddFirst(_item);
                    }

                    if (_item.Left != null)
                    {
                        _queue.Enqueue(_item.Left);
                    }
                    if (_item.Right != null)
                    {
                        _queue.Enqueue(_item.Right);
                    }
                }
                linkedList.Add(_linkedList);
                isLeftOrder = !isLeftOrder;

                #region 错误代码
                // var tmpNode = _queue.Dequeue();
                // Console.Write($"{tmpNode.Key} ");
                // var parentLayer = tmpNode.Layer;
                // SearchTwoWayTreeNode<T> _left = tmpNode.Left;
                // SearchTwoWayTreeNode<T> _right = tmpNode.Right;
                // if (parentLayer % 2 != 0)
                // {
                //     if (_right != null)
                //     {
                //         _right.Layer = parentLayer + 1;
                //         _queue.Enqueue(_right);
                //     }
                //     if (_left != null)
                //     {
                //         _left.Layer = parentLayer + 1;
                //         _queue.Enqueue(_left);
                //     }
                // }
                // else
                // {
                //     if (_left != null)
                //     {
                //         _left.Layer = parentLayer + 1;
                //         _queue.Enqueue(_left);
                //     }
                //     if (_right != null)
                //     {
                //         _right.Layer = parentLayer + 1;
                //         _queue.Enqueue(_right);
                //     }
                // }

                // var _node = _linkedList.First;
                // for (_node = _linkedList.First; _node != null; _node = _node.Next)
                // {
                //     Console.Write($"{_node.Value.Key} ");
                // }

                // foreach (var _itm in _linkedList)
                // {
                //     Console.Write($"{_itm.Key} ");
                // }
                #endregion
            }

            foreach (var _l0 in linkedList)
            {
                foreach (var _l1 in _l0)
                {
                    Console.Write($"{_l1.Key} ");
                }
            }
            Console.WriteLine();
        }

    }

    /// <summary>
    /// 找出最大值
    /// </summary>
    /// <returns></returns>
    public SearchTwoWayTreeNode<T> FindMax()
    {
        /*
        var current = RootNode;
        while (current.Right != null)
        {
            current = current.Right;
        }
        return current.Key;
        */


        var currNode = RootNode;
        var parentNode = currNode;
        while (currNode != null)
        {
            parentNode = currNode;
            currNode = currNode.Right;
        }
        return parentNode;


    }

    /// <summary>
    /// 找到最小值
    /// </summary>
    /// <returns></returns>
    public SearchTwoWayTreeNode<T> FindMin()
    {
        /*
        var current = RootNode;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current.Key;
        */


        var currNode = RootNode;
        var parentNode = currNode;
        while (currNode != null)
        {
            parentNode = currNode;
            currNode = currNode.Left;
        }
        return parentNode;
    }

    /// <summary>
    /// 查找节点
    /// </summary>
    /// <param name="_key"></param>
    /// <returns></returns>
    public SearchTwoWayTreeNode<T> FindByKey(int _key)
    {
        var currNode = RootNode;
        while (true)
        {
            if (_key < currNode.Key)
            {
                if (currNode.Left == null)
                {
                    return null;
                }
                currNode = currNode.Left;
            }
            else if (_key > currNode.Key)
            {
                if (currNode.Right == null)
                {
                    return null;
                }
                currNode = currNode.Right;
            }
            else
            {
                return currNode;
            }
        }
        /*
        var currNode = RootNode;
        if (_key == currNode.Key)
        {
            return currNode;
        }
        else if (_key < currNode.Key)
        {
            while (currNode.Key != _key && currNode.Left != null)
            {
                currNode = currNode.Left;//如果节点在左子树里面的右边树就找不到了
            }
        }
        else
        {
            while (currNode.Key != _key && currNode.Right != null)
            {
                currNode = currNode.Right;//如果节点在右子树里面的左边树就找不到了
            }
        }
        if (currNode.Key == _key)
            return currNode;
        else
            return null;
        */
    }

    /// <summary>
    /// 删除节点，先查找节点，并需要一个变量来存储待删除节点的父节点，再删除，删除时需要判断节点孩子情况：
    /// 分为四种情况：无左右孩子；有左没有右，有右没有左，左右都有
    /// 左右孩子都有时最复杂：删除规则是，待删除节点的左孩子移动到待删除节点的位置；待删除节点的右子树挂到待删除节点的左子树中
    /// 最深的那个右叶子节点的右边。
    /// </summary>
    /// <param name="_key"></param>
    /// <returns></returns>
    public bool DeleteNode(int _key)
    {
        SearchTwoWayTreeNode<T> parentNode = null;
        var currNode = RootNode;
        var isFinded = false;
        while (true)
        {
            if (_key < currNode.Key)
            {
                if (currNode.Left == null)
                {
                    break;
                }
                parentNode = currNode;
                currNode = currNode.Left;
            }
            else if (_key > currNode.Key)
            {
                if (currNode.Right == null)
                {
                    break;
                }
                parentNode = currNode;
                currNode = currNode.Right;
            }
            else
            {
                isFinded = true;
                break;
            }
        }
        Console.WriteLine($"isFinded:{isFinded}");
        if (!isFinded) return false;

        if (currNode.Left == null && currNode.Right == null)
        {
            if (currNode == RootNode)
            {
                RootNode = null;
            }
            else
            {
                if (currNode.Key < parentNode.Key)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }
            }
            return true;
        }

        if (currNode.Left != null && currNode.Right == null)
        {
            if (currNode == RootNode)
            {
                RootNode = RootNode.Left;

            }
            else
            {
                if (currNode.Key < parentNode.Key)
                {
                    parentNode.Left = currNode.Left;

                }
                else
                {
                    parentNode.Right = currNode.Left;
                }
            }
            return true;
        }

        if (currNode.Left == null && currNode.Right != null)
        {
            if (currNode == RootNode)
            {
                RootNode = RootNode.Right;
            }
            else
            {
                if (currNode.Key < parentNode.Key)
                {
                    parentNode.Left = currNode.Right;
                }
                else
                {
                    parentNode.Right = currNode.Right;
                }
            }
            return true;
        }

        if (currNode.Left != null && currNode.Right != null)
        {
            if (currNode == RootNode)
            {
                var _root = RootNode.Left;
                var _left = RootNode.Left;
                while (_left.Right != null)
                {
                    _left = _left.Right;
                }
                _left.Right = RootNode.Right;
                RootNode = _root;
            }
            else
            {
                Console.WriteLine($"父key:{parentNode.Key}");
                if (currNode.Key < parentNode.Key)
                {
                    var _lroot = currNode.Left;
                    var _left = currNode.Left;
                    while (_left.Right != null)
                    {
                        _left = _left.Right;
                    }
                    _left.Right = currNode.Right;
                    parentNode.Left = _lroot;

                }
                else
                {
                    Console.WriteLine($"子key:{currNode.Key}");
                    var _rroot = currNode.Left;
                    var _left = currNode.Left;
                    while (_left.Right != null)
                    {
                        _left = _left.Right;
                    }
                    _left.Right = currNode.Right;
                    parentNode.Right = _rroot;

                }
            }
            return true;
        }
        return true;
    }


}

public class SearchTwoWayTreeNode<T>
{
    public int Key { get; set; }
    public T Value { get; set; }

    public int Layer { get; set; }

    public SearchTwoWayTreeNode<T> Left { get; set; }
    public SearchTwoWayTreeNode<T> Right { get; set; }

}
