//PROJECT NAME: Logistics
//CLASS NAME: FTSLQCSGetTestEachStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLQCSGetTestEachStatus : IFTSLQCSGetTestEachStatus
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLQCSGetTestEachStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PassStatus) FTSLQCSGetTestEachStatusSp(string RcvrNum,
		string Item,
		int? Sequence,
		decimal? ActualValue,
		int? PassStatus)
		{
			StringType _RcvrNum = RcvrNum;
			ItemType _Item = Item;
			IntType _Sequence = Sequence;
			QtyUnitType _ActualValue = ActualValue;
			ListYesNoType _PassStatus = PassStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLQCSGetTestEachStatusSp";
				
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActualValue", _ActualValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PassStatus", _PassStatus, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PassStatus = _PassStatus;
				
				return (Severity, PassStatus);
			}
		}
	}
}
