//PROJECT NAME: Logistics
//CLASS NAME: FTSLWMStartOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMStartOperation
	{
		(int? ReturnCode, string Whse,
		string Item,
		string InfoBar) FTSLWMStartOperationSp(DateTime? PunchDateTime,
		string EmployeeNumber,
		string OrderType,
		string OrderNumber,
		short? Suffix,
		string Operation,
		string InputTaskCode,
		string WorkCenter,
		string Whse,
		string Item,
		string InfoBar,
		int? Line = null,
		string PartnerId = null);
	}
	
	public class FTSLWMStartOperation : IFTSLWMStartOperation
	{
		readonly IApplicationDB appDB;
		
		public FTSLWMStartOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Whse,
		string Item,
		string InfoBar) FTSLWMStartOperationSp(DateTime? PunchDateTime,
		string EmployeeNumber,
		string OrderType,
		string OrderNumber,
		short? Suffix,
		string Operation,
		string InputTaskCode,
		string WorkCenter,
		string Whse,
		string Item,
		string InfoBar,
		int? Line = null,
		string PartnerId = null)
		{
			DateTimeType _PunchDateTime = PunchDateTime;
			EmpNumType _EmployeeNumber = EmployeeNumber;
			EcCodeType _OrderType = OrderType;
			ReqNumType _OrderNumber = OrderNumber;
			SuffixType _Suffix = Suffix;
			ReqNumType _Operation = Operation;
			ReqNumType _InputTaskCode = InputTaskCode;
			ReqNumType _WorkCenter = WorkCenter;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			InfobarType _InfoBar = InfoBar;
			GenericIntType _Line = Line;
			ReqNumType _PartnerId = PartnerId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLWMStartOperationSp";
				
				appDB.AddCommandParameter(cmd, "PunchDateTime", _PunchDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNumber", _EmployeeNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputTaskCode", _InputTaskCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCenter", _WorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Whse = _Whse;
				Item = _Item;
				InfoBar = _InfoBar;
				
				return (Severity, Whse, Item, InfoBar);
			}
		}
	}
}
