using Football;

namespace RestApiAssignment.Manager
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer{Id = _nextId++, Age = 21, Name ="Ronaldo", ShirtNumber= 7},
            new FootballPlayer{Id = _nextId++, Age = 25, Name ="Messi", ShirtNumber= 10},
            new FootballPlayer{Id = _nextId++, Age = 26, Name ="Torres", ShirtNumber= 9},
            new FootballPlayer{Id = _nextId++, Age = 27, Name ="Febregas", ShirtNumber= 4},
        };

        public List<FootballPlayer> GetAll(string? nameFilter)
        {
            List<FootballPlayer> result = new List<FootballPlayer>(Data);
            if (nameFilter != null)
            {
                result = result.FindAll(player => player.Name.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase));
            }
            
            return result;
        }

        public FootballPlayer? GetById(int id)
        {
            return Data.Find(football => football.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;
            Data.Remove(player);
            return player;
        }

        public FootballPlayer? Update(int id, FootballPlayer updates)
        {
            FootballPlayer? player = Data.Find(player1 => player1.Id == id);
            if (player == null) return null;

            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }

    }
}
