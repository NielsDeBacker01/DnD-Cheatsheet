import { useEffect } from "react";
import { Spell } from "../../types/Spell";
import "./SpellBlock.css"

type SpellBlockProps = {
    spell: Spell;
};

//displays a list of spells to add/remove for the current character
function SpellBlock({spell}:SpellBlockProps) {

    useEffect(() => {
    }, []);

    return(
        <div className="spell-block rounded-xl m-2 w-[25rem] border-4">
            <div className="flex border-b-2">
                <div className="w-[50%] border-r-2 border-graydark flex items-center p-2">
                    <a className="underline text-orange-400 mr-1 font-bold" href={spell.url}>{spell.name.split("{")[0]}</a>
                    <p className="text-xs text-zinc-400">({spell.vsm}: {spell.requirements})</p>
                    <p className="ml-auto font-bold">{spell.spellLevel}</p>
                </div>
                <div className="w-[50%] items-center p-2 overflow-hidden">
                    <div className="flex">
                        <p className="text-xs text-zinc-400">Con: ({spell.concentration})</p>
                        <p className="text-xs text-zinc-400">III: {spell.targets}</p>
                        <p className="text-xs text-zinc-400">Che: {spell.hitcheck}</p>
                    </div>
                    <div className="flex">
                        <p className="text-xs text-zinc-400">Ft: {spell.range}</p>
                        <p className="text-xs text-zinc-400">AOE: {spell.aoe}</p>
                        <p className="text-xs text-zinc-400">Act: {spell.action}</p>
                    </div>
                </div>
            </div>
            <div className="flex border-b-2 p-2">
                <p>{spell.effect}</p>
            </div>
            <div className="flex">
                <p className="text-xs text-zinc-400 p-2">Upcast: {spell.upcast}</p>
            </div>            
        </div>
    );
}

export default SpellBlock;