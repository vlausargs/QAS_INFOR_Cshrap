//PROJECT NAME: Material
//CLASS NAME: DeleteTaxFreeExports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class DeleteTaxFreeExports : IDeleteTaxFreeExports
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteTaxFreeExports(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DeleteTaxFreeExportsSp(string StartingExportDocId,
		string EndingExportDocId,
		DateTime? CutoffDate,
		int? CutoffDateOffset,
		string Infobar)
		{
			ExportDocIdType _StartingExportDocId = StartingExportDocId;
			ExportDocIdType _EndingExportDocId = EndingExportDocId;
			DateType _CutoffDate = CutoffDate;
			DateOffsetType _CutoffDateOffset = CutoffDateOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTaxFreeExportsSp";
				
				appDB.AddCommandParameter(cmd, "StartingExportDocId", _StartingExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingExportDocId", _EndingExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
