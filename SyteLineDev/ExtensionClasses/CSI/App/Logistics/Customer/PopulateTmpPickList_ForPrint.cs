//PROJECT NAME: Logistics
//CLASS NAME: PopulateTmpPickList_ForPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PopulateTmpPickList_ForPrint : IPopulateTmpPickList_ForPrint
	{
		readonly IApplicationDB appDB;
		
		
		public PopulateTmpPickList_ForPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PopulateTmpPickList_ForPrintSp(string Status,
		int? Selected,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Picker,
		int? Printed,
		DateTime? PickDate,
		string Whse,
		string PackLoc,
		Guid? ProcessId1,
		Guid? ProcessId2,
		int? GenerateBulkPickList)
		{
			PickListStatusType _Status = Status;
			ListYesNoType _Selected = Selected;
			PickListIDType _PickListId = PickListId;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			UsernameType _Picker = Picker;
			ListYesNoType _Printed = Printed;
			DateType _PickDate = PickDate;
			WhseType _Whse = Whse;
			LocType _PackLoc = PackLoc;
			RowPointerType _ProcessId1 = ProcessId1;
			RowPointerType _ProcessId2 = ProcessId2;
			ListYesNoType _GenerateBulkPickList = GenerateBulkPickList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PopulateTmpPickList_ForPrintSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Picker", _Picker, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Printed", _Printed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickDate", _PickDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackLoc", _PackLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId1", _ProcessId1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId2", _ProcessId2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateBulkPickList", _GenerateBulkPickList, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
