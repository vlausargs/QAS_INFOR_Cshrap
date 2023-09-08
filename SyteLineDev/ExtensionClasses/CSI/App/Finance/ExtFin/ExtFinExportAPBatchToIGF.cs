//PROJECT NAME: Finance
//CLASS NAME: ExtFinExportAPBatchToIGF.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinExportAPBatchToIGF : IExtFinExportAPBatchToIGF
	{
		readonly IApplicationDB appDB;
		
		public ExtFinExportAPBatchToIGF(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinExportAPBatchToIGFSp(
			decimal? BatchNum,
			string Infobar)
		{
			BatchNumType _BatchNum = BatchNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinExportAPBatchToIGFSp";
				
				appDB.AddCommandParameter(cmd, "BatchNum", _BatchNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
