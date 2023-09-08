//PROJECT NAME: DataCollection
//CLASS NAME: DcjmTmpSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjmTmpSer : IDcjmTmpSer
	{
		readonly IApplicationDB appDB;
		
		public DcjmTmpSer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DcjmTmpSerSp(
			int? PTransNum,
			string Infobar)
		{
			DcTransNumType _PTransNum = PTransNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjmTmpSerSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
