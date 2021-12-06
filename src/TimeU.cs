using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RAX_Utilities
{
    class TimeU
    {

        /*Console-application*/
        public static void Pace(int times, int delay, DateTime start, string id)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine('.' + Math.Round((DateTime.Now - start).TotalMilliseconds) + $"ms (from {id})");
                Task.Delay(delay).Wait();
            }
            Console.WriteLine($"Pace - delay:{delay}ms, iterations: {times}, {id} end at: {Math.Round((DateTime.Now - start).TotalMilliseconds, 2)}ms");
        }
        public static async Task PaceAsync(int times, int delay, DateTime start, string id)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine('.' + Math.Round((DateTime.Now - start).TotalMilliseconds) + $"ms (from {id})");
                await Task.Delay(delay);
            }
            Console.WriteLine($"PaceAsync - delay:{delay}ms, iterations: {times}, {id} end at: {Math.Round((DateTime.Now - start).TotalMilliseconds, 2)}ms");
        }
    }
}
