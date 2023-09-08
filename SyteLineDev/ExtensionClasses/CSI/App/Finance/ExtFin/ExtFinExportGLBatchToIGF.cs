//PROJECT NAME: Finance
//CLASS NAME: ExtFinExportGLBatchToIGF.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinExportGLBatchToIGF : IExtFinExportGLBatchToIGF
	{
		readonly IApplicationDB appDB;
		
		public ExtFinExportGLBatchToIGF(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ExtFinExportGLBatchToIGFSp(
			decimal? BatchNum,
			string Infobar)
		{
			BatchNumType _BatchNum = BatchNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinExportGLBatchToIGFSp";
				
				appDB.AddCommandParameter(cmd, "BatchNum", _BatchNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
