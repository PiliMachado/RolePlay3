using System;
namespace RoleplayGame
{
    public interface IHeroes
    {
        IDefenseItem IItemDef { get; set; }
        int Life { get; set; }
        int VictoryPoints { get; set; }
        void Attack (Character chara);
        void Cure ();
    }
}