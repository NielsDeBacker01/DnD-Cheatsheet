export type Character = {
  id: number;
  name: string;
  level: number;
  spellAtkBonus: number;
  class: CharacterClass;
  spellIds: number[];
};

export enum CharacterClass { Artificer, Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard}