//PROJECT NAME: Codes
//CLASS NAME: IsFeatureActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
    public class IsFeatureActive : IIsFeatureActive
    {
        readonly IApplicationDB appDB;


        public IsFeatureActive(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            int? FeatureActive,
            string InfoBar) IsFeatureActiveSp(
            string ProductName = "CSI",
            string FeatureID = null,
            int? FeatureActive = 0,
            string InfoBar = null)
        {
            ProductNameType _ProductName = ProductName;
            ApplicationFeatureIDType _FeatureID = FeatureID;
            ListYesNoType _FeatureActive = FeatureActive;
            InfobarType _InfoBar = InfoBar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IsFeatureActiveSp";

                appDB.AddCommandParameter(cmd, "ProductName", _ProductName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FeatureID", _FeatureID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FeatureActive", _FeatureActive, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                FeatureActive = _FeatureActive;
                InfoBar = _InfoBar;

                return (Severity, FeatureActive, InfoBar);
            }
        }

        public int? IsFeatureActiveFn(
            string ProductName,
            string FeatureID)
        {
            ProductNameType _ProductName = ProductName;
            ApplicationFeatureIDType _FeatureID = FeatureID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[IsFeatureActive](@ProductName, @FeatureID)";

                appDB.AddCommandParameter(cmd, "ProductName", _ProductName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FeatureID", _FeatureID, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
