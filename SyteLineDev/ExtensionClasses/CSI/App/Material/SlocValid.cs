//PROJECT NAME: CSIMaterial
//CLASS NAME: SlocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISlocValid
    {
        int SlocValidSp(string Item,
                        string Whse,
                        string Loc,
                        ref string Lot,
                        ref string Infobar,
                        ref string ImportDocId);
    }

    public class SlocValid : ISlocValid
    {
        readonly IApplicationDB appDB;

        public SlocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SlocValidSp(string Item,
                               string Whse,
                               string Loc,
                               ref string Lot,
                               ref string Infobar,
                               ref string ImportDocId)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            LotType _Lot = Lot;
            InfobarType _Infobar = Infobar;
            ImportDocIdType _ImportDocId = ImportDocId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SlocValidSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Lot = _Lot;
                Infobar = _Infobar;
                ImportDocId = _ImportDocId;

                return Severity;
            }
        }
    }
}
