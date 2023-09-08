//PROJECT NAME: Data
//CLASS NAME: TrnitemUpdQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrnitemUpdQty : ITrnitemUpdQty
	{
		readonly IApplicationDB appDB;
		
		public TrnitemUpdQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TrnitemUpdQtySp(
			string PTrnNum,
			int? PTrnLine,
			decimal? PQtyShipped,
			decimal? PQtyPacked,
			string PStat,
			DateTime? PShipDate,
			decimal? PQtyReceived,
			decimal? PQtyLoss,
			DateTime? PRcvdDate,
			string Infobar)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			QtyUnitType _PQtyShipped = PQtyShipped;
			QtyUnitType _PQtyPacked = PQtyPacked;
			TransferStatusType _PStat = PStat;
			DateType _PShipDate = PShipDate;
			QtyUnitType _PQtyReceived = PQtyReceived;
			QtyUnitType _PQtyLoss = PQtyLoss;
			DateType _PRcvdDate = PRcvdDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnitemUpdQtySp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyShipped", _PQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyPacked", _PQtyPacked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipDate", _PShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReceived", _PQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyLoss", _PQtyLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRcvdDate", _PRcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
