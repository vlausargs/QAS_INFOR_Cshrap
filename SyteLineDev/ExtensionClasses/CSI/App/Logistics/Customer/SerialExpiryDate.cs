//PROJECT NAME: Logistics
//CLASS NAME: SerialExpiryDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ISerialExpiryDate
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons, string InfoBar) SerialExpiryDateSp(string SerialNum,
		string SerialItem,
		byte? SelectFlag = (byte)1,
		string PromptMsg = null,
		string PromptButtons = null,
		string InfoBar = null);
	}
	
	public class SerialExpiryDate : ISerialExpiryDate
	{
		readonly IApplicationDB appDB;
		
		public SerialExpiryDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons, string InfoBar) SerialExpiryDateSp(string SerialNum,
		string SerialItem,
		byte? SelectFlag = (byte)1,
		string PromptMsg = null,
		string PromptButtons = null,
		string InfoBar = null)
		{
			SerNumType _SerialNum = SerialNum;
			ItemType _SerialItem = SerialItem;
			ListYesNoType _SelectFlag = SelectFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SerialExpiryDateSp";
				
				appDB.AddCommandParameter(cmd, "SerialNum", _SerialNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialItem", _SerialItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectFlag", _SelectFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				InfoBar = _InfoBar;
				
				return (Severity, PromptMsg, PromptButtons, InfoBar);
			}
		}
	}
}
