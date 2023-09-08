//PROJECT NAME: Data
//CLASS NAME: SSSFSApsSROOrderID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class SSSFSApsSROOrderID : ISSSFSApsSROOrderID
    {
        readonly IApplicationDB appDB;

        public SSSFSApsSROOrderID(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string SSSFSApsSROOrderIDFn(
            string PSroNum,
            int? PSroLine,
            int? PSroOper,
            int? PTransNum)
        {
            FSSRONumType _PSroNum = PSroNum;
            FSSROLineType _PSroLine = PSroLine;
            FSSROOperType _PSroOper = PSroOper;
            FSSROTransNumType _PTransNum = PTransNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[SSSFSApsSROOrderID](@PSroNum, @PSroLine, @PSroOper, @PTransNum)";

                appDB.AddCommandParameter(cmd, "PSroNum", _PSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSroLine", _PSroLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSroOper", _PSroOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
