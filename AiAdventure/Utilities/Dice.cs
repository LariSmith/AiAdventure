namespace AiAdventure.Utilities
{
    public class Dice
    {
        private static Random _random = new Random();

        public static int Roll(int sides)
        {
            return _random.Next(1, sides + 1);
        }
    }
}
