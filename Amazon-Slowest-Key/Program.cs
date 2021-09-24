using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazon_Slowest_Key
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] releaseTimes = new int[] { 9, 29, 49, 50 };
            string keysPressed = "cbcd";
           
            Console.WriteLine(SlowestKey(releaseTimes, keysPressed));
        }

        static char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            int max = 0;
            List<Press> LP = new List<Press>();
            for (int i = 0; i < releaseTimes.Length; i++)
            {

                int time = 0;
                if (i == 0)
                    time = releaseTimes[i];
                else
                    time = releaseTimes[i] - releaseTimes[i - 1];
                if (time > max)
                    max = time;
                LP.Add(new Press(time , keysPressed[i]));
            }

            List<Press> LS = LP.OrderBy(x => x.time).ThenBy(x=>x.Key).ToList();
            LS.Reverse();
            return LS[0].Key;
        }
    }

    public class Press
    {
        public int time;
        public char Key;

        public Press(int time, char key)
        {
            this.Key = key;
            this.time = time;
        }
    }
}
