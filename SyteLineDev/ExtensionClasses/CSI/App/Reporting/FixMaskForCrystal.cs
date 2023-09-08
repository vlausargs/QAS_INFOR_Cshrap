//PROJECT NAME: Reporting
//CLASS NAME: FixMaskForCrystal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public class FixMaskForCrystal : IFixMaskForCrystal
    {
        IApplicationDB appDB;


        public FixMaskForCrystal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string FixMaskForCrystalFn(string QtyFormat,
        string Grouping)
        {
            InputMaskType _QtyFormat = QtyFormat;
            LongListType _Grouping = Grouping;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[FixMaskForCrystal](@QtyFormat, @Grouping)";

                appDB.AddCommandParameter(cmd, "QtyFormat", _QtyFormat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Grouping", _Grouping, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
