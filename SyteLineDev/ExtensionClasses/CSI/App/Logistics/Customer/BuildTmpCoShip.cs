//PROJECT NAME: Logistics
//CLASS NAME: BuildTmpCoShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class BuildTmpCoShip : IBuildTmpCoShip
	{
		readonly IApplicationDB appDB;
		
		
		public BuildTmpCoShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BuildTmpCoShipSp(Guid? ProcessId,
		int? COTypeA,
		int? COTypeB,
		string Status,
		string StartingOrder,
		string EndingOrder,
		string StartingCustomer,
		string EndingCustomer,
		DateTime? StartingOrderDate,
		DateTime? EndingOrderDate,
		DateTime? StartingDueDate,
		DateTime? EndingDueDate,
		string CoitemStatus,
		int? StartingLine,
		int? EndingLine,
		int? StartingRelease,
		int? EndingRelease,
		int? SelectShipments,
		string Whse)
		{
			RowPointerType _ProcessId = ProcessId;
			IntType _COTypeA = COTypeA;
			IntType _COTypeB = COTypeB;
			StringType _Status = Status;
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			CustNumType _StartingCustomer = StartingCustomer;
			CustNumType _EndingCustomer = EndingCustomer;
			DateType _StartingOrderDate = StartingOrderDate;
			DateType _EndingOrderDate = EndingOrderDate;
			DateType _StartingDueDate = StartingDueDate;
			DateType _EndingDueDate = EndingDueDate;
			StringType _CoitemStatus = CoitemStatus;
			CoLineType _StartingLine = StartingLine;
			CoLineType _EndingLine = EndingLine;
			CoReleaseType _StartingRelease = StartingRelease;
			CoReleaseType _EndingRelease = EndingRelease;
			IntType _SelectShipments = SelectShipments;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildTmpCoShipSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COTypeA", _COTypeA, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COTypeB", _COTypeB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrderDate", _StartingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrderDate", _EndingOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDueDate", _StartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDueDate", _EndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemStatus", _CoitemStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLine", _StartingLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLine", _EndingLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRelease", _StartingRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRelease", _EndingRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectShipments", _SelectShipments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
