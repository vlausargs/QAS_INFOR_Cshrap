//PROJECT NAME: Material
//CLASS NAME: ExpandKyByType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ExpandKyByType : IExpandKyByType
	{
		readonly IApplicationDB appDB;


        public ExpandKyByType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            string Result) ExpandKyByTypeSp(
            string DataType,
            string Key,
            string Site = null,
            string Result = null)
        {
            StringType _DataType = DataType;
            AlphaKeyType _Key = Key;
            SiteType _Site = Site;
            AlphaKeyType _Result = Result;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ExpandKyByTypeSp";

                appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Result = _Result;

                return (Severity, Result);
            }
        }
        public string ExpandKyByTypeFn(string DataType,
		string Key)
		{
			StringType _DataType = DataType;
			AlphaKeyType _Key = Key;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ExpandKyByType](@DataType, @Key)";

				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
