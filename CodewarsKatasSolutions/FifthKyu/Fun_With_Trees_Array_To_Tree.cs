namespace FifthKyu;

// https://www.codewars.com/kata/57e5a6a67fbcc9ba900021cd

internal class Solution
{
    public static TreeNode? ArrayToTree(int[] array)
    {
        return array.Length == 0 ? null : MakeTreeNode(array, 0);
    }

    private static TreeNode? MakeTreeNode(int[] arr, int index)
    {
        var node = new TreeNode(arr[index]);

        if (index * 2 + 1 < arr.Length)
            node.left = MakeTreeNode(arr, index * 2 + 1);

        if (index * 2 + 2 < arr.Length)
            node.right = MakeTreeNode(arr, index * 2 + 2);

        return node;
    }
}

// Codewars given class
public class TreeNode
{
    public TreeNode? left;
    public TreeNode? right;
    public int value;

    public TreeNode(int value, TreeNode? left, TreeNode? right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int value)
    {
        this.value = value;
    }
}