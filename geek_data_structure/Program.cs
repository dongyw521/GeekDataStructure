// See https://aka.ms/new-console-template for more information
using geek_data_structure.Tree;
using geek_data_structure.LinkList;

Console.WriteLine("Hello, World!");

// var lt = new LinkTwoWayTree<int>();
// var myTree = lt.BuildIntTree(1, 3);
// Console.WriteLine($"根节点：{myTree.val}");
// lt.PrintTree(myTree);

// var ltt = new LinkThreeWayTree<int>();
// var myThreeTree = ltt.BuildIntThreeWayTree(1, 3);
// Console.WriteLine($"根节点：{myThreeTree.Val}");
// ltt.PrintTree(myThreeTree);

// var singleLL = new SingleLinkList<int>();
// singleLL.AddFirst(1);
// singleLL.AddLast(4);
// singleLL.AddLast(6);
// singleLL.AddLast(9);
// Console.WriteLine(singleLL.IsEmpty());
// Console.WriteLine(singleLL.NodeCount);
// Console.WriteLine(singleLL.Last);
// singleLL.Print();
// Console.WriteLine();
//singleLL.ReverseSingleLinkList();
// Console.WriteLine(singleLL.First);
// Console.WriteLine(singleLL.Last);
// singleLL.Print();
// Console.WriteLine();

// var singleLL2 = new SingleLinkList<int>();
// singleLL2.AddFirst(3);
// singleLL2.AddLast(10);
// singleLL2.AddLast(12);
// singleLL2.AddLast(14);
// singleLL2.Print();
// Console.WriteLine();

// var _helper = new LinkListHelper();
// var newHead = _helper.MergeTowIntLinkLists(singleLL.First, singleLL2.First);

// var mergedSingleLL = new SingleLinkList<int>();
// mergedSingleLL.First = newHead;
// mergedSingleLL.NodeCount = singleLL.NodeCount + singleLL2.NodeCount;
// mergedSingleLL.Print();
// Console.WriteLine();
var searchTTree = new SearchTwoWayTree<string>();
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 10, Value = "ten" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 14, Value = "fourteen" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 6, Value = "six" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 7, Value = "three" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 13, Value = "seven" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 15, Value = "two" });
searchTTree.Insert(new SearchTwoWayTreeNode<string>() { Key = 5, Value = "eight" });
searchTTree.InOrder(searchTTree.RootNode);
Console.WriteLine();
searchTTree.PreOrder(searchTTree.RootNode);
Console.WriteLine();
searchTTree.LastOrder(searchTTree.RootNode);
Console.WriteLine();
searchTTree.LayerOrder(searchTTree.RootNode);
searchTTree.LayerZOrder(searchTTree.RootNode);
// Console.WriteLine();
// Console.WriteLine(searchTTree.FindMax().Value);
// Console.WriteLine(searchTTree.FindMin().Value);
// Console.WriteLine(searchTTree.FindByKey(8)?.Value);
// searchTTree.DeleteNode(14);
// searchTTree.InOrder(searchTTree.RootNode);
// Console.WriteLine();






