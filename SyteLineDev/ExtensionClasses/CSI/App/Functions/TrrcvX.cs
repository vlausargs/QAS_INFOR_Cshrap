//PROJECT NAME: Data
//CLASS NAME: TrrcvX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrrcvX : ITrrcvX
	{
		readonly IApplicationDB appDB;
		
		public TrrcvX(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TrrcvXSp(
			string PTrnNum,
			int? PTrnLine,
			decimal? PQty,
			string PToLoc,
			string PToLot,
			string Infobar,
			string PImportDocId)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			QtyUnitType _PQty = PQty;
			LocType _PToLoc = PToLoc;
			LotType _PToLot = PToLot;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrrcvXSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLoc", _PToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToLot", _PToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
