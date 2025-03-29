using System.Collections.Generic;
using System.Threading;

namespace EVE_Isk_per_Hour
{

    public class ThreadingArray
    {
        // Keeps an array of threads if we need to abort update
        private List<Thread> ThreadsArray;

        public ThreadingArray()
        {
            ThreadsArray = new List<Thread>();
        }

        // Adds a thread to the array
        public void AddThread(Thread T)
        {
            ThreadsArray.Add(T);
        }

        // Kills all the threads in the class
        public void StopAllThreads()
        {
            // Kill all the threads
            for (int i = 0, loopTo = ThreadsArray.Count - 1; i <= loopTo; i++)
            {
                if (ThreadsArray[i].IsAlive)
                {
                    ThreadsArray[i].Abort();
                }
            }
        }

        // Returns true if all threads are complete, else false
        public bool Complete()
        {

            foreach (var T in ThreadsArray)
            {
                if (T.ThreadState == System.Threading.ThreadState.Running | T.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                {
                    // Check if the call to stop threads is flagged
                    if (Public_Variables.CancelThreading)
                    {
                        return true;
                    }
                    // Still working on at least 1 thread, so exit
                    return false;
                }
            }

            // Must all be complete
            return true;

        }

    }
}