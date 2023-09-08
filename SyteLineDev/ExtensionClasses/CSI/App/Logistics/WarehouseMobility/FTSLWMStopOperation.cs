//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMStopOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMStopOperation
	{
		int FTSLWMStopOperationSp(DateTime? PunchDateTime,
		                          ref string EmployeeNumber,
		                          string OrderType,
		                          string OrderNumber,
		                          short? Suffix,
		                          string Operation,
		                          int? Line,
		                          string InputTaskcode,
		                          string InputWC,
		                          string PartnerId,
		                          string LocalItem,
		                          decimal? QuantityRejected,
		                          string ReasonCode,
		                          ref string InfoBar,
		                          ref string ReturnSLEmployee,
		                          ref string ReturnSLEmpShift);
	}
	
	public class FTSLWMStopOperation : IFTSLWMStopOperation
	{
		readonly IApplicationDB appDB;
		
		public FTSLWMStopOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLWMStopOperationSp(DateTime? PunchDateTime,
		                                 ref string EmployeeNumber,
		                                 string OrderType,
		                                 string OrderNumber,
		                                 short? Suffix,
		                                 string Operation,
		                                 int? Line,
		                                 string InputTaskcode,
		                                 string InputWC,
		                                 string PartnerId,
		                                 string LocalItem,
		                                 decimal? QuantityRejected,
		                                 string ReasonCode,
		                                 ref string InfoBar,
		                                 ref string ReturnSLEmployee,
		                                 ref string ReturnSLEmpShift)
		{
			DateTimeType _PunchDateTime = PunchDateTime;
			EmpNumType _EmployeeNumber = EmployeeNumber;
			EcCodeType _OrderType = OrderType;
			ReqNumType _OrderNumber = OrderNumber;
			SuffixType _Suffix = Suffix;
			ReqNumType _Operation = Operation;
			GenericIntType _Line = Line;
			ReqNumType _InputTaskcode = InputTaskcode;
			ReqNumType _InputWC = InputWC;
			ReqNumType _PartnerId = PartnerId;
			ItemType _LocalItem = LocalItem;
			QtyTotlType _QuantityRejected = QuantityRejected;
			ReasonCodeType _ReasonCode = ReasonCode;
			InfobarType _InfoBar = InfoBar;
			EmpNumType _ReturnSLEmployee = ReturnSLEmployee;
			ShiftType _ReturnSLEmpShift = ReturnSLEmpShift;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLWMStopOperationSp";
				
				appDB.AddCommandParameter(cmd, "PunchDateTime", _PunchDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNumber", _EmployeeNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputTaskcode", _InputTaskcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputWC", _InputWC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocalItem", _LocalItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuantityRejected", _QuantityRejected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnSLEmployee", _ReturnSLEmployee, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnSLEmpShift", _ReturnSLEmpShift, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmployeeNumber = _EmployeeNumber;
				InfoBar = _InfoBar;
				ReturnSLEmployee = _ReturnSLEmployee;
				ReturnSLEmpShift = _ReturnSLEmpShift;
				
				return Severity;
			}
		}
	}
}
