//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteTaxFreeImports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IDeleteTaxFreeImports
	{
		int DeleteTaxFreeImportsSp(string StartingImportDocId,
		                           string EndingImportDocId,
		                           DateTime? CutoffDate,
		                           short? CutoffDateOffset,
		                           ref string Infobar);
	}
	
	public class DeleteTaxFreeImports : IDeleteTaxFreeImports
	{
		readonly IApplicationDB appDB;
		
		public DeleteTaxFreeImports(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DeleteTaxFreeImportsSp(string StartingImportDocId,
		                                  string EndingImportDocId,
		                                  DateTime? CutoffDate,
		                                  short? CutoffDateOffset,
		                                  ref string Infobar)
		{
			ImportDocIdType _StartingImportDocId = StartingImportDocId;
			ImportDocIdType _EndingImportDocId = EndingImportDocId;
			DateType _CutoffDate = CutoffDate;
			DateOffsetType _CutoffDateOffset = CutoffDateOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTaxFreeImportsSp";
				
				appDB.AddCommandParameter(cmd, "StartingImportDocId", _StartingImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingImportDocId", _EndingImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
