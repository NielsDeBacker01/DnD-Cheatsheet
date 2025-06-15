export type Spell = {
  id: number;
  name: string;
  url: string;
  spellLevel: number;
  vsm: string;
  requirements: string;
  targets: string;
  range: number;
  aeo: string;
  hitcheck: string;
  effect: string;
  upcast: string;
};

export type CheckType = 
    | "Guaranteed"
    | "Spell_Attack"
    | "Weapon_Attack"
    | "Strength_Saving_Throw"
    |  "Dexterity_Saving_Throw"
    |  "Constitution_Saving_Throw"
    |  "Wisdom_Saving_Throw" 
    |  "Intelligence_Saving_Throw"
    |  "Charisma_Saving_Throw"
    |  "Flat_Saving_Throw";
