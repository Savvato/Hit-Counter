namespace HitCounter
{
    using System.Collections.Concurrent;

    public class HitCounter
    {
        private const long Period = 5 * 60; // 5 minutes
        private ConcurrentDictionary<long, long> hits = new ConcurrentDictionary<long, long>();

        public void Hit(long timestamp)
        {
            hits.AddOrUpdate(
                key: timestamp, 
                addValueFactory: key => 1, 
                updateValueFactory: (timestamp, counter) => ++counter);            
        }

        public long GetHits(long timestamp)
        {
            long counter = 0;
            long pastLimit = timestamp - Period;
            for (long moment = timestamp; moment > pastLimit; moment--)
            {
                if (hits.ContainsKey(moment)) 
                    counter += hits[moment];
            }
            return counter;
        }
    }
}