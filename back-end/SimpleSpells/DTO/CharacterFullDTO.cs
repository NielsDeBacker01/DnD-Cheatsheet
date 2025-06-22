namespace SimpleSpells.DTOs
{
    public class CharacterFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Level { get; set; }
        public int SpellAtkBonus { get; set; }
        public string Class { get; set; } = null!; 
        public List<SpellDto> Spells { get; set; } = new();
    }
}