//PROJECT NAME: Production
//CLASS NAME: UpdateSeqNo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class UpdateSeqNo : IUpdateSeqNo
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateSeqNo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateSeqNoSp(string TableName,
		int? AltNum = null,
		string Infobar = null)
		{
			TableNameType _TableName = TableName;
			ApsAltNoType _AltNum = AltNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateSeqNoSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
