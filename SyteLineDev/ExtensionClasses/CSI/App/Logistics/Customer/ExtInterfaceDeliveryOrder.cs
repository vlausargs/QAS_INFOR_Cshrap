//PROJECT NAME: CSICustomer
//CLASS NAME: ExtInterfaceDeliveryOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IExtInterfaceDeliveryOrder
	{
		int ExtInterfaceDeliveryOrderSp(string StartingDo,
		                                string EndingDo,
		                                byte? PrPickupDate,
		                                byte? PrDoSeqText,
		                                byte? PrDoLineText,
		                                byte? PrDoText,
		                                byte? PageByDoLine,
		                                byte? PrSerialNumbers,
		                                string StatingCust,
		                                string EndingCust,
		                                int? StatingShipTo,
		                                int? EndingShipTo,
		                                DateTime? StatingPickupDate,
		                                DateTime? EndingPickupDate,
		                                short? StatingPickupDateOffset,
		                                short? EndingPickupDateOffset,
		                                byte? ShowInternal,
		                                byte? ShowExternal,
		                                byte? DisplayHeader,
		                                int? TaskId,
		                                ref string DoHdrList);
	}
	
	public class ExtInterfaceDeliveryOrder : IExtInterfaceDeliveryOrder
	{
		readonly IApplicationDB appDB;
		
		public ExtInterfaceDeliveryOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ExtInterfaceDeliveryOrderSp(string StartingDo,
		                                       string EndingDo,
		                                       byte? PrPickupDate,
		                                       byte? PrDoSeqText,
		                                       byte? PrDoLineText,
		                                       byte? PrDoText,
		                                       byte? PageByDoLine,
		                                       byte? PrSerialNumbers,
		                                       string StatingCust,
		                                       string EndingCust,
		                                       int? StatingShipTo,
		                                       int? EndingShipTo,
		                                       DateTime? StatingPickupDate,
		                                       DateTime? EndingPickupDate,
		                                       short? StatingPickupDateOffset,
		                                       short? EndingPickupDateOffset,
		                                       byte? ShowInternal,
		                                       byte? ShowExternal,
		                                       byte? DisplayHeader,
		                                       int? TaskId,
		                                       ref string DoHdrList)
		{
			DoNumType _StartingDo = StartingDo;
			DoNumType _EndingDo = EndingDo;
			FlagNyType _PrPickupDate = PrPickupDate;
			FlagNyType _PrDoSeqText = PrDoSeqText;
			FlagNyType _PrDoLineText = PrDoLineText;
			FlagNyType _PrDoText = PrDoText;
			FlagNyType _PageByDoLine = PageByDoLine;
			FlagNyType _PrSerialNumbers = PrSerialNumbers;
			CustNumType _StatingCust = StatingCust;
			CustNumType _EndingCust = EndingCust;
			CustSeqType _StatingShipTo = StatingShipTo;
			CustSeqType _EndingShipTo = EndingShipTo;
			DateType _StatingPickupDate = StatingPickupDate;
			DateType _EndingPickupDate = EndingPickupDate;
			DateOffsetType _StatingPickupDateOffset = StatingPickupDateOffset;
			DateOffsetType _EndingPickupDateOffset = EndingPickupDateOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			LongListType _DoHdrList = DoHdrList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtInterfaceDeliveryOrderSp";
				
				appDB.AddCommandParameter(cmd, "StartingDo", _StartingDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDo", _EndingDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrPickupDate", _PrPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoSeqText", _PrDoSeqText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoLineText", _PrDoLineText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrDoText", _PrDoText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageByDoLine", _PageByDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrSerialNumbers", _PrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingCust", _StatingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCust", _EndingCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingShipTo", _StatingShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingShipTo", _EndingShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingPickupDate", _StatingPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickupDate", _EndingPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatingPickupDateOffset", _StatingPickupDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPickupDateOffset", _EndingPickupDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoHdrList", _DoHdrList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DoHdrList = _DoHdrList;
				
				return Severity;
			}
		}
	}
}
