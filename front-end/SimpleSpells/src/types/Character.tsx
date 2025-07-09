export type Character = {
  id: number;
  name: string;
  level: number;
  spellAtkBonus: number;
  class: CharacterClass;
  spellIds: number[];
};

export enum CharacterClass {
  Artificer = "Artificer",
  Barbarian = "Barbarian",
  Bard = "Bard",
  Cleric = "Cleric",
  Druid = "Druid",
  Fighter = "Fighter",
  Monk = "Monk",
  Paladin = "Paladin",
  Ranger = "Ranger",
  Rogue = "Rogue",
  Sorcerer = "Sorcerer",
  Warlock = "Warlock",
  Wizard = "Wizard",
}
