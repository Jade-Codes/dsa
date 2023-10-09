public class Solution {
    public bool Find132pattern(int[] nums) 
    {
        if(nums.Length < 3) return false;

        int lastNumber = int.MinValue;
        Stack<int> stack = new Stack<int>();

        for(int i=nums.Length-1; i>=0; i--)
        {
            if (nums[i] < lastNumber) return true;

            while (stack.Count > 0 && nums[i] > stack.Peek())
            {
                lastNumber = stack.Peek();
                stack.Pop();
            }

            stack.Push(nums[i]);
        }

        return false;
    }
}