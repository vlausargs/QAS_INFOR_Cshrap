//PROJECT NAME: Logistics
//CLASS NAME: CoShipInProcessAdjEntry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoShipInProcessAdjEntry : ICoShipInProcessAdjEntry
	{
		readonly IApplicationDB appDB;
		
		
		public CoShipInProcessAdjEntry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoShipInProcessAdjEntrySp(Guid? CurCoShipRowPointer,
		decimal? QtyApprove,
		DateTime? ApproveDate,
		string Infobar)
		{
			RowPointerType _CurCoShipRowPointer = CurCoShipRowPointer;
			QtyUnitType _QtyApprove = QtyApprove;
			DateType _ApproveDate = ApproveDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoShipInProcessAdjEntrySp";
				
				appDB.AddCommandParameter(cmd, "CurCoShipRowPointer", _CurCoShipRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyApprove", _QtyApprove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApproveDate", _ApproveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
