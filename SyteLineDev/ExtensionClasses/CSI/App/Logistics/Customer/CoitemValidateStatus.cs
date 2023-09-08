//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateStatus : ICoitemValidateStatus
	{
		readonly IApplicationDB appDB;
		
		
		public CoitemValidateStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CoitemValidateStatusSp(string PCoNum,
		int? PCoLine,
		decimal? POldQtyShipped,
		decimal? POldQtyRsvd,
		decimal? POldQtyInvoiced,
		string PCoStat,
		string POldStatus,
		string PNewStatus,
		string Infobar,
		int? PlacesQtyUnit = null)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			QtyUnitNoNegType _POldQtyShipped = POldQtyShipped;
			QtyUnitType _POldQtyRsvd = POldQtyRsvd;
			QtyUnitNoNegType _POldQtyInvoiced = POldQtyInvoiced;
			CoStatusType _PCoStat = PCoStat;
			CoitemStatusType _POldStatus = POldStatus;
			CoitemStatusType _PNewStatus = PNewStatus;
			InfobarType _Infobar = Infobar;
			DecimalPlacesType _PlacesQtyUnit = PlacesQtyUnit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemValidateStatusSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyShipped", _POldQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyRsvd", _POldQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyInvoiced", _POldQtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoStat", _PCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStatus", _POldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStatus", _PNewStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlacesQtyUnit", _PlacesQtyUnit, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
