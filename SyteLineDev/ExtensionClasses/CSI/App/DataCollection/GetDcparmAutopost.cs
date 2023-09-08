//PROJECT NAME: DataCollection
//CLASS NAME: GetDcparmAutopost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class GetDcparmAutopost : IGetDcparmAutopost
	{
		readonly IApplicationDB appDB;
		
		
		public GetDcparmAutopost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? AutoPostFlag,
		string Infobar) GetDcparmAutopostSp(string AutoPostFieldName,
		int? AutoPostFlag,
		string Infobar)
		{
			StringType _AutoPostFieldName = AutoPostFieldName;
			ListYesNoType _AutoPostFlag = AutoPostFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDcparmAutopostSp";
				
				appDB.AddCommandParameter(cmd, "AutoPostFieldName", _AutoPostFieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoPostFlag", _AutoPostFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AutoPostFlag = _AutoPostFlag;
				Infobar = _Infobar;
				
				return (Severity, AutoPostFlag, Infobar);
			}
		}
	}
}
