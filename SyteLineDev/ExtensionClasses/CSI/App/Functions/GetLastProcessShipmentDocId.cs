//PROJECT NAME: Data
//CLASS NAME: GetLastProcessShipmentDocId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetLastProcessShipmentDocId : IGetLastProcessShipmentDocId
	{
		readonly IApplicationDB appDB;
		
		public GetLastProcessShipmentDocId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string LastProcessShipmentDocId,
			string Infobar) GetLastProcessShipmentDocIdSp(
			string CoNum,
			string TrnNum,
			string Whse,
			string ShipSite,
			DateTime? DueDate,
			Guid? Rowpointer,
			string LastProcessShipmentDocId,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			TrnNumType _TrnNum = TrnNum;
			WhseType _Whse = Whse;
			SiteType _ShipSite = ShipSite;
			DateType _DueDate = DueDate;
			RowPointerType _Rowpointer = Rowpointer;
			ShipmentDocIdType _LastProcessShipmentDocId = LastProcessShipmentDocId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLastProcessShipmentDocIdSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rowpointer", _Rowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastProcessShipmentDocId", _LastProcessShipmentDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LastProcessShipmentDocId = _LastProcessShipmentDocId;
				Infobar = _Infobar;
				
				return (Severity, LastProcessShipmentDocId, Infobar);
			}
		}
	}
}
