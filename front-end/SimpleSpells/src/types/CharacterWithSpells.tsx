import { Spell } from "./Spell";
import { CharacterClass } from "./Character";

export type CharacterWithSpells = {
  id: number;
  name: string;
  level: number;
  spellAtkBonus: number;
  class: CharacterClass;
  spells: Spell[];
};
