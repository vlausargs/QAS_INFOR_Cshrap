//PROJECT NAME: Logistics
//CLASS NAME: GetDIFOTPolicy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetDIFOTPolicy : IGetDIFOTPolicy
	{
		readonly IApplicationDB appDB;
		
		
		public GetDIFOTPolicy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? shipped_over_ordered_qty_tolerance,
		decimal? shipped_under_ordered_qty_tolerance,
		int? days_shipped_after_due_date_tolerance,
		int? days_shipped_before_due_date_tolerance) GetDIFOTPolicySp(string Site = null,
		string PCoNum = null,
		int? PCoLine = null,
		int? PCoRelease = null,
		string PCustNum = null,
		int? PCustSeq = null,
		int? PHierarchy = null,
		decimal? shipped_over_ordered_qty_tolerance = null,
		decimal? shipped_under_ordered_qty_tolerance = null,
		int? days_shipped_after_due_date_tolerance = null,
		int? days_shipped_before_due_date_tolerance = null)
		{
			SiteType _Site = Site;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			IntType _PHierarchy = PHierarchy;
			TolerancePercentType _shipped_over_ordered_qty_tolerance = shipped_over_ordered_qty_tolerance;
			TolerancePercentType _shipped_under_ordered_qty_tolerance = shipped_under_ordered_qty_tolerance;
			ToleranceDaysType _days_shipped_after_due_date_tolerance = days_shipped_after_due_date_tolerance;
			ToleranceDaysType _days_shipped_before_due_date_tolerance = days_shipped_before_due_date_tolerance;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDIFOTPolicySp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "shipped_over_ordered_qty_tolerance", _shipped_over_ordered_qty_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "shipped_under_ordered_qty_tolerance", _shipped_under_ordered_qty_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "days_shipped_after_due_date_tolerance", _days_shipped_after_due_date_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "days_shipped_before_due_date_tolerance", _days_shipped_before_due_date_tolerance, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				shipped_over_ordered_qty_tolerance = _shipped_over_ordered_qty_tolerance;
				shipped_under_ordered_qty_tolerance = _shipped_under_ordered_qty_tolerance;
				days_shipped_after_due_date_tolerance = _days_shipped_after_due_date_tolerance;
				days_shipped_before_due_date_tolerance = _days_shipped_before_due_date_tolerance;
				
				return (Severity, shipped_over_ordered_qty_tolerance, shipped_under_ordered_qty_tolerance, days_shipped_after_due_date_tolerance, days_shipped_before_due_date_tolerance);
			}
		}
	}
}
