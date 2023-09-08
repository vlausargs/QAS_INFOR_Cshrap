//PROJECT NAME: Production
//CLASS NAME: UpdateOverrideForJobTranPieces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class UpdateOverrideForJobTranPieces : IUpdateOverrideForJobTranPieces
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOverrideForJobTranPieces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateOverrideForJobTranPiecesSp(Guid? JobTranPieceRowPointer,
		int? CompletedPieceCount,
		string Infobar)
		{
			RowPointerType _JobTranPieceRowPointer = JobTranPieceRowPointer;
			PieceCountType _CompletedPieceCount = CompletedPieceCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOverrideForJobTranPiecesSp";
				
				appDB.AddCommandParameter(cmd, "JobTranPieceRowPointer", _JobTranPieceRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompletedPieceCount", _CompletedPieceCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
