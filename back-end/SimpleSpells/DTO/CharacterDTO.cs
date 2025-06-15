namespace SimpleSpells.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
        public int SpellAtkBonus { get; set; }
        public string Class { get; set; } = null!; 
        public List<int> SpellIds { get; set; } = new();
    }
}