namespace GamesPlatform
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int GetValue()
        {
            if (int.TryParse(Rank, out var v)) return v;
            if (Rank == "A") return 11;
            return 10;
        }
        public string GetImageFileName()
        {
            string s = string.Empty;

            switch (Suit)
            {
                case "Hearts":
                    s = "H";
                    break;
                case "Diamonds":
                    s = "D";
                    break;
                case "Clubs":
                    s = "C";
                    break;
                case "Spades":
                    s = "S";
                    break;
                default:
                    s = string.Empty;
                    break;
            }
            return $"{Rank}{s}.png";
        }
    }
}
