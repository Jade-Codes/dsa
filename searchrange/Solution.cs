public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        return new int[2] { Array.IndexOf(nums,target), Array.LastIndexOf(nums, target) };
    }
}