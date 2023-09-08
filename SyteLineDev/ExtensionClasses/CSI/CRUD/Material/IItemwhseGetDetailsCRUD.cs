//PROJECT NAME: Material
//CLASS NAME: IItemwhseGetDetailsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IItemwhseGetDetailsCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        (decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag, int? rowCount) ItemwhseLoad(string Item, string Whse, decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag);
        (string Loc, int? rowCount) ItemlocLoad(string Item, string Whse, string Loc);
        (int? ReturnCode, decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag, string Loc, string Infobar) AltExtGen_ItemwhseGetDetailsSp(string AltExtGenSp, string Item, string Whse, decimal? QtyOnHand, decimal? QtyReorder, int? CntInProc, int? CycleFlag, string Loc, string Infobar);
    }
}

