//PROJECT NAME: CSIProduct
//CLASS NAME: CurrentMaterialsBflushLocV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICurrentMaterialsBflushLocV
    {
        int CurrentMaterialsBflushLocVSp(string Item,
                                         string WC,
                                         string Whse,
                                         byte? Backflush,
                                         string MatlBflushLoc,
                                         string LocalParamBflushLoc,
                                         string BflushLoc,
                                         ref string Infobar);
    }

    public class CurrentMaterialsBflushLocV : ICurrentMaterialsBflushLocV
    {
        readonly IApplicationDB appDB;

        public CurrentMaterialsBflushLocV(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CurrentMaterialsBflushLocVSp(string Item,
                                                string WC,
                                                string Whse,
                                                byte? Backflush,
                                                string MatlBflushLoc,
                                                string LocalParamBflushLoc,
                                                string BflushLoc,
                                                ref string Infobar)
        {
            ItemType _Item = Item;
            WcType _WC = WC;
            WhseType _Whse = Whse;
            ListYesNoType _Backflush = Backflush;
            LocType _MatlBflushLoc = MatlBflushLoc;
            LocType _LocalParamBflushLoc = LocalParamBflushLoc;
            LocType _BflushLoc = BflushLoc;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CurrentMaterialsBflushLocVSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlBflushLoc", _MatlBflushLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocalParamBflushLoc", _LocalParamBflushLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BflushLoc", _BflushLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
