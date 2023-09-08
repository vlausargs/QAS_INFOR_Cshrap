using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MG.MGCore
{
	public class DataTypeString : IDataTypeString
	{
		IApplicationDB appDB;


		public DataTypeString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DataTypeStringFn(string Domain,
		string Type,
		int? Length,
		int? Precision,
		int? Scale)
		{
			StringType _Domain = Domain;
			StringType _Type = Type;
			IntType _Length = Length;
			IntType _Precision = Precision;
			IntType _Scale = Scale;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DataTypeString](@Domain, @Type, @Length, @Precision, @Scale)";

				appDB.AddCommandParameter(cmd, "Domain", _Domain, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Length", _Length, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Precision", _Precision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Scale", _Scale, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
