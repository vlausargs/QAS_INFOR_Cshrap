//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionCostbyWorkCenterSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionCostbyWorkCenterSub : IRpt_ProductionCostbyWorkCenterSub
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ProductionCostbyWorkCenterSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ProductionCostbyWorkCenterSubSp(
			string StartingWorkCenter = null,
			string EndingWorkCenter = null,
			DateTime? StartingTransDate = null,
			DateTime? EndingTransDate = null,
			int? StartingTransDateOffset = null,
			int? EndingTransDateOffset = null,
			int? DisplayHeader = null)
		{
			WcType _StartingWorkCenter = StartingWorkCenter;
			WcType _EndingWorkCenter = EndingWorkCenter;
			DateType _StartingTransDate = StartingTransDate;
			DateType _EndingTransDate = EndingTransDate;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionCostbyWorkCenterSubSp";
				
				appDB.AddCommandParameter(cmd, "StartingWorkCenter", _StartingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWorkCenter", _EndingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
