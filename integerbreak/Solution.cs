public class Solution {
    public int IntegerBreak(int n) {

        if(n==2) return 1;   

        if(n==3) return 2;

        int currentValue = n;
        int maximisedProduct = 1;
        
        while(currentValue > 0)
        {
            if(currentValue==4)
            {
                maximisedProduct*=4;
                currentValue-=4;
            }
            else if(currentValue==3)
            {
                maximisedProduct*=3;
                currentValue-=3;
            }
            else if(currentValue==2)
            {
                maximisedProduct*=2;
                currentValue-=2;
            }
            else 
            {
                maximisedProduct*=3;
                currentValue-=3;
            }
        } 

        return maximisedProduct;
    }
}