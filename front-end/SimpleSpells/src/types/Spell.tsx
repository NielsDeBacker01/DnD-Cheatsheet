export type Spell = {
  id: number;
  name: string;
  url: string;
  spellLevel: number;
  vsm: string;
  requirements: string;
  targets: string;
  range: number;
  aoe: string;
  hitcheck: CheckType;
  effect: string;
  upcast: string;
  availabilty: SpellSource;
};

export enum CheckType {Guaranteed,Spell_Attack,Weapon_Attack,Strength_Saving_Throw,Dexterity_Saving_Throw,Constitution_Saving_Throw,Wisdom_Saving_Throw,Intelligence_Saving_Throw,Charisma_Saving_Throw,Flat_Saving_Throw}
export enum SpellSource {Artificer,Barbarian,Bard,Cleric,Druid,Fighter,Monk,Paladin,Ranger,Rogue,Sorcer,Warlock,Wizard}