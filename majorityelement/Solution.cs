public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int numTimes = nums.Length;
        List<int> numList = new List<int>();

        for (int i=0; i<nums.Length; i++)
        {
            if(numList.Contains(nums[i])) continue;

            var countOfNums = nums.Count(_ => _ == nums[i]);

            if(numTimes - countOfNums < 0) break;

            if(countOfNums > nums.Length/3)
            {
                numList.Add(nums[i]);
                numTimes = numTimes - countOfNums;
            }
        }

        return numList;
    }
}