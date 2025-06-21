namespace SimpleSpells.DTOs
{
    public class SpellDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int SpellLevel { get; set; }
        public string Vsm { get; set; } = null!;
        public string Requirements { get; set; } = "";
        public string Action { get; set; } = "";
        public string Concentration { get; set; } = "";
        public string Targets { get; set; } = "1";
        public int Range { get; set; }
        public string AOE { get; set; } = "";
        public string Hitcheck { get; set; } = null!;
        public string Effect { get; set; } = null!;
        public string Upcast { get; set; } = "";
        public List<string> Availability { get; set; } = new();
    }
}
