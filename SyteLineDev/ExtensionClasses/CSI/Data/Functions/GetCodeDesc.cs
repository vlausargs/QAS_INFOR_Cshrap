//PROJECT NAME: Data
//CLASS NAME: GetCodeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class GetCodeDesc : IGetCodeDesc
	{
		readonly IApplicationDB appDB;


		public GetCodeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string GetCodeDescFn(string PClass,
		string PCharCode = null,
		int? PIntCode = null)
		{
			ComboClassType _PClass = PClass;
			Infobar _PCharCode = PCharCode;
			IntType _PIntCode = PIntCode;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCodeDesc](@PClass, @PCharCode, @PIntCode)";

				appDB.AddCommandParameter(cmd, "PClass", _PClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCharCode", _PCharCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIntCode", _PIntCode, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
