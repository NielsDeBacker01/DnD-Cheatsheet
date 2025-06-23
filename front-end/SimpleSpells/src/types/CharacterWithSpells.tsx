import { Spell } from "./Spell";

export type CharacterWithSpells = {
  id: number;
  name: string;
  level: number;
  spellAtkBonus: number;
  class: CharacterClass;
  spells: Spell[];
};

export enum CharacterClass { Artificer, Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard}