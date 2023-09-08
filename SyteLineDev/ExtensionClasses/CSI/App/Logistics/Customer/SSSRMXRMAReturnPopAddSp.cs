//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRMAReturnPopAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXRMAReturnPopAdd
    {
        int SSSRMXRMAReturnPopAddSp(string RmaNum,
                                    short? RmaLine,
                                    string Item,
                                    string CoNum,
                                    short? CoLine,
                                    short? CoRelease,
                                    ref decimal? MatlCost,
                                    ref decimal? LbrCost,
                                    ref decimal? FovCost,
                                    ref decimal? VovCost,
                                    ref decimal? OutCost,
                                    ref string Infobar);
    }

    public class SSSRMXRMAReturnPopAdd : ISSSRMXRMAReturnPopAdd
    {
        readonly IApplicationDB appDB;

        public SSSRMXRMAReturnPopAdd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXRMAReturnPopAddSp(string RmaNum,
                                           short? RmaLine,
                                           string Item,
                                           string CoNum,
                                           short? CoLine,
                                           short? CoRelease,
                                           ref decimal? MatlCost,
                                           ref decimal? LbrCost,
                                           ref decimal? FovCost,
                                           ref decimal? VovCost,
                                           ref decimal? OutCost,
                                           ref string Infobar)
        {
            RmaNumType _RmaNum = RmaNum;
            RmaLineType _RmaLine = RmaLine;
            ItemType _Item = Item;
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CoReleaseType _CoRelease = CoRelease;
            CostPrcType _MatlCost = MatlCost;
            CostPrcType _LbrCost = LbrCost;
            CostPrcType _FovCost = FovCost;
            CostPrcType _VovCost = VovCost;
            CostPrcType _OutCost = OutCost;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXRMAReturnPopAddSpSp";

                appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RmaLine", _RmaLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FovCost", _FovCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "VovCost", _VovCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                MatlCost = _MatlCost;
                LbrCost = _LbrCost;
                FovCost = _FovCost;
                VovCost = _VovCost;
                OutCost = _OutCost;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
