//PROJECT NAME: DataCollection
//CLASS NAME: GetDcparmAutopostEscFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class GetDcparmAutopostEscFlag : IGetDcparmAutopostEscFlag
	{
		readonly IApplicationDB appDB;
		
		
		public GetDcparmAutopostEscFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AutoPostFlag,
		string EscFlag,
		string Infobar) GetDcparmAutopostEscFlagSp(string AutoPostFieldName,
		int? AutoPostFlag,
		string EscFlag,
		string Infobar)
		{
			StringType _AutoPostFieldName = AutoPostFieldName;
			ListYesNoType _AutoPostFlag = AutoPostFlag;
			DcEscFlagType _EscFlag = EscFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDcparmAutopostEscFlagSp";
				
				appDB.AddCommandParameter(cmd, "AutoPostFieldName", _AutoPostFieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoPostFlag", _AutoPostFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EscFlag", _EscFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AutoPostFlag = _AutoPostFlag;
				EscFlag = _EscFlag;
				Infobar = _Infobar;
				
				return (Severity, AutoPostFlag, EscFlag, Infobar);
			}
		}
	}
}
