namespace FifthKyu;

// https://www.codewars.com/kata/57dd79bff6df9b103b00010f
// Code won't compile here, needs codewars class
  
public class Is_Perfect
{
    public TreeNode left;
    public TreeNode right;

    public static bool IsPerfect(TreeNode root) => root == null ? true : IsPerfectExtended(root).Item1;
    
    public static (bool, int) IsPerfectExtended(TreeNode root)
    {
        if(root.left == null && root.right == null) return (true, 1);
        if(root.left == null || root.right == null) return (false, 0);
        var (leftChild, rightChild) = (IsPerfectExtended(root.left), IsPerfectExtended(root.right));
        return ((leftChild.Item1 && rightChild.Item1) && leftChild.Item2 == rightChild.Item2, leftChild.Item2 + rightChild.Item2 + 1);
    }
    
    public static TreeNode Leaf()
    {
        return new TreeNode();
    }

    public static TreeNode Join(TreeNode left, TreeNode right)
    {
        return new TreeNode().WithChildren(left, right);
    }

    public TreeNode WithLeft(TreeNode left)
    {
        this.left = left;
        return this;
    }

    public TreeNode WithRight(TreeNode right)
    {
        this.right = right;
        return this;
    }

    public TreeNode WithChildren(TreeNode left, TreeNode right) 
    {
        this.left = left;
        this.right = right;
        return this;
    }

    public TreeNode WithLeftLeaf() 
    {
        return WithLeft(Leaf());
    }

    public TreeNode WithRightLeaf()
    {
        return WithRight(Leaf());
    }

    public TreeNode WithLeaves() 
    {
        return WithChildren(Leaf(), Leaf());
    }
}