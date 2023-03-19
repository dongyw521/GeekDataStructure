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

var singleLL = new SingleLinkList<int>();
singleLL.AddFirst(1);
singleLL.AddLast(2);
singleLL.AddLast(3);
singleLL.AddLast(4);
Console.WriteLine(singleLL.IsEmpty());
Console.WriteLine(singleLL.NodeCount);
Console.WriteLine(singleLL.Last);



