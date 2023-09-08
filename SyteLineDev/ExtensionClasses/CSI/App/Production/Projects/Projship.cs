//PROJECT NAME: Production
//CLASS NAME: Projship.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class Projship : IProjship
	{
		readonly IApplicationDB appDB;
		
		
		public Projship(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjshipSp(string PProjNum,
		int? PTaskNum,
		int? PSeq,
		decimal? PQtyToShip,
		DateTime? PShipDate,
		string PEcCode,
		int? PConsNum,
		string Infobar,
		string PExportDocId)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			QtyPerType _PQtyToShip = PQtyToShip;
			CurrentDateType _PShipDate = PShipDate;
			EcCodeType _PEcCode = PEcCode;
			ConsignmentsType _PConsNum = PConsNum;
			InfobarType _Infobar = Infobar;
			ExportDocIdType _PExportDocId = PExportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjshipSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToShip", _PQtyToShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipDate", _PShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEcCode", _PEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConsNum", _PConsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExportDocId", _PExportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
