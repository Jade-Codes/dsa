public class Solution {
    public bool IsMonotonic(int[] nums) {

        if(nums.Length <= 2) return true;

        int direction = 0;

        for (int i=1; i<nums.Length; i++)
        {
            if(direction==0){
                if(nums[i-1] == nums[i]) continue;
                direction = nums[i-1] < nums[i] ? 1 : -1;
                continue;
            }
            if ((nums[i] < nums[i-1]) && direction==1){
                return false;
            }
            if ((nums[i] > nums[i-1]) && direction==-1) {
                return false;
            }
        }
        return true;
    }
}