//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSIncPriorityDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSIncPriorityDates
	{
		int SSSFSIncPriorityDatesSp(string PriorCode,
		                            DateTime? IncDateTime,
		                            string CustNum,
		                            string SerNum,
		                            string Item,
		                            ref DateTime? FollowupDateTime,
		                            ref DateTime? WarningDateTime,
		                            ref DateTime? LateDateTime,
		                            ref string InfoBar);
	}
	
	public class SSSFSIncPriorityDates : ISSSFSIncPriorityDates
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncPriorityDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSIncPriorityDatesSp(string PriorCode,
		                                   DateTime? IncDateTime,
		                                   string CustNum,
		                                   string SerNum,
		                                   string Item,
		                                   ref DateTime? FollowupDateTime,
		                                   ref DateTime? WarningDateTime,
		                                   ref DateTime? LateDateTime,
		                                   ref string InfoBar)
		{
			FSIncPriorCodeType _PriorCode = PriorCode;
			DateTimeType _IncDateTime = IncDateTime;
			CustNumType _CustNum = CustNum;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			DateTimeType _FollowupDateTime = FollowupDateTime;
			DateTimeType _WarningDateTime = WarningDateTime;
			DateTimeType _LateDateTime = LateDateTime;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncPriorityDatesSp";
				
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDateTime", _IncDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FollowupDateTime", _FollowupDateTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WarningDateTime", _WarningDateTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LateDateTime", _LateDateTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FollowupDateTime = _FollowupDateTime;
				WarningDateTime = _WarningDateTime;
				LateDateTime = _LateDateTime;
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
