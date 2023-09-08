//PROJECT NAME: DataCollection
//CLASS NAME: GetInvparmAutoGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class GetInvparmAutoGen : IGetInvparmAutoGen
	{
		readonly IApplicationDB appDB;
		
		
		public GetInvparmAutoGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AutoGenFlag,
		string Infobar) GetInvparmAutoGenSp(string AutoGenFieldName,
		int? AutoGenFlag,
		string Infobar)
		{
			StringType _AutoGenFieldName = AutoGenFieldName;
			ListYesNoType _AutoGenFlag = AutoGenFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInvparmAutoGenSp";
				
				appDB.AddCommandParameter(cmd, "AutoGenFieldName", _AutoGenFieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoGenFlag", _AutoGenFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AutoGenFlag = _AutoGenFlag;
				Infobar = _Infobar;
				
				return (Severity, AutoGenFlag, Infobar);
			}
		}
	}
}
