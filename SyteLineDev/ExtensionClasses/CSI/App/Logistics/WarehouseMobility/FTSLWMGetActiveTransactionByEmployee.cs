//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMGetActiveTransactionByEmployee.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMGetActiveTransactionByEmployee
	{
		int FTSLWMGetActiveTransactionByEmployeeSp(string EmployeeNumber,
		                                           ref string EmployeeShift,
		                                           ref int? IsEmployeeActive,
		                                           ref DateTime? StartTime,
		                                           ref string OrderType,
		                                           ref string OrderNumber,
		                                           ref short? Suffix,
		                                           ref int? Line,
		                                           ref int? Operation,
		                                           ref string Task,
		                                           ref string Whse,
		                                           ref string Item,
		                                           ref string ItemDesc,
		                                           ref string WC,
		                                           ref string PartnerId,
		                                           ref string PartnerDesc,
		                                           ref string OrderCusName,
		                                           ref string OrderDesc,
		                                           ref string LineDesc,
		                                           ref string InfoBar);
	}
	
	public class FTSLWMGetActiveTransactionByEmployee : IFTSLWMGetActiveTransactionByEmployee
	{
		readonly IApplicationDB appDB;
		
		public FTSLWMGetActiveTransactionByEmployee(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLWMGetActiveTransactionByEmployeeSp(string EmployeeNumber,
		                                                  ref string EmployeeShift,
		                                                  ref int? IsEmployeeActive,
		                                                  ref DateTime? StartTime,
		                                                  ref string OrderType,
		                                                  ref string OrderNumber,
		                                                  ref short? Suffix,
		                                                  ref int? Line,
		                                                  ref int? Operation,
		                                                  ref string Task,
		                                                  ref string Whse,
		                                                  ref string Item,
		                                                  ref string ItemDesc,
		                                                  ref string WC,
		                                                  ref string PartnerId,
		                                                  ref string PartnerDesc,
		                                                  ref string OrderCusName,
		                                                  ref string OrderDesc,
		                                                  ref string LineDesc,
		                                                  ref string InfoBar)
		{
			EmpNumType _EmployeeNumber = EmployeeNumber;
			ShiftType _EmployeeShift = EmployeeShift;
			SmallYesNoType _IsEmployeeActive = IsEmployeeActive;
			DateTimeType _StartTime = StartTime;
			JobTypeType _OrderType = OrderType;
			JobType _OrderNumber = OrderNumber;
			SuffixType _Suffix = Suffix;
			CustSeqType _Line = Line;
			OperNumType _Operation = Operation;
			ItemType _Task = Task;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			WcType _WC = WC;
			PartNoType _PartnerId = PartnerId;
			DescriptionType _PartnerDesc = PartnerDesc;
			DescriptionType _OrderCusName = OrderCusName;
			DescriptionType _OrderDesc = OrderDesc;
			DescriptionType _LineDesc = LineDesc;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLWMGetActiveTransactionByEmployeeSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeNumber", _EmployeeNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeShift", _EmployeeShift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsEmployeeActive", _IsEmployeeActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartTime", _StartTime, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Task", _Task, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerDesc", _PartnerDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderCusName", _OrderCusName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderDesc", _OrderDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineDesc", _LineDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmployeeShift = _EmployeeShift;
				IsEmployeeActive = _IsEmployeeActive;
				StartTime = _StartTime;
				OrderType = _OrderType;
				OrderNumber = _OrderNumber;
				Suffix = _Suffix;
				Line = _Line;
				Operation = _Operation;
				Task = _Task;
				Whse = _Whse;
				Item = _Item;
				ItemDesc = _ItemDesc;
				WC = _WC;
				PartnerId = _PartnerId;
				PartnerDesc = _PartnerDesc;
				OrderCusName = _OrderCusName;
				OrderDesc = _OrderDesc;
				LineDesc = _LineDesc;
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
