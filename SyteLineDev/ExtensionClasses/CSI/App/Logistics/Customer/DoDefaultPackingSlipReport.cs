//PROJECT NAME: Logistics
//CLASS NAME: DoDefaultPackingSlipReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DoDefaultPackingSlipReport : IDoDefaultPackingSlipReport
	{
		readonly IApplicationDB appDB;
		
		
		public DoDefaultPackingSlipReport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PackNum,
		string Infobar) DoDefaultPackingSlipReportSp(string TPckCall,
		string Whse,
		DateTime? PackDate,
		string CoNum,
		int? PackNum,
		string Infobar,
		int? BatchId)
		{
			StringType _TPckCall = TPckCall;
			WhseType _Whse = Whse;
			DateType _PackDate = PackDate;
			CoNumType _CoNum = CoNum;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			BatchIdType _BatchId = BatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DoDefaultPackingSlipReportSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PackNum = _PackNum;
				Infobar = _Infobar;
				
				return (Severity, PackNum, Infobar);
			}
		}
	}
}
