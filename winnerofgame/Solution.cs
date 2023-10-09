public class Solution {
    public bool WinnerOfGame(string colors) {
        int aRounds = 0;
        int bRounds = 0;

        for(int i=0; i<colors.Length-2; i++)
        {
            if(colors[i] == colors[i+1] && colors[i] == colors[i+2] && colors[i] == 'A')
            {
                aRounds++;
            }
            else if(colors[i] == colors[i+1] && colors[i] == colors[i+2] && colors[i]  == 'B')
            {
                bRounds++;
            }
        }

        return aRounds > bRounds;
    }
}