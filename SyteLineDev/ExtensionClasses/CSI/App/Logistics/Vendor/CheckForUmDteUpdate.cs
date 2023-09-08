//PROJECT NAME: Logistics
//CLASS NAME: CheckForUmDteUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckForUmDteUpdate : ICheckForUmDteUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public CheckForUmDteUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons) CheckForUmDteUpdateSp(string PReqNum,
		string PVendNum,
		string POldVendNum,
		string PItem,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons)
		{
			ReqNumType _PReqNum = PReqNum;
			VendNumType _PVendNum = PVendNum;
			VendNumType _POldVendNum = POldVendNum;
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			DateType _PDueDate = PDueDate;
			RefTypeIJKOTType _PRefType = PRefType;
			UMType _PNewUM = PNewUM;
			DateType _PNewDte = PNewDte;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckForUmDteUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldVendNum", _POldVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNewDte", _PNewDte, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNewUM = _PNewUM;
				PNewDte = _PNewDte;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PNewUM, PNewDte, PromptMsg, PromptButtons);
			}
		}
	}
}
