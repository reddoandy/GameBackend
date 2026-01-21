using GameBackend.Models;


namespace GameBackend.Services
{
    public class MatchMakingService
    {

        private static readonly List<string> WaitingPlayers = new();
        private static readonly object LockObj = new();


        public MatchResponse Enqueue(string EosId)
        {
            lock (LockObj)
            {
                WaitingPlayers.Add(EosId);

                Console.WriteLine($"[MatchMaking] Player queued:{EosId}");

                if (WaitingPlayers.Count >= 2)
                {
                    var players = WaitingPlayers.Take(2).ToArray();
                    WaitingPlayers.RemoveRange(0, 2);

                    var matchId = Guid.NewGuid().ToString();


                    Console.WriteLine($"[MatchMaking] Match created: {matchId}");

                    return new MatchResponse
                    {
                        Matched = true
                    };
                }

                return new MatchResponse
                {
                    Matched = false
                };
            }
        }
    }
}
