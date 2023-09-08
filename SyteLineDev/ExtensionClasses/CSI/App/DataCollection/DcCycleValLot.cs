//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcCycleValLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcCycleValLot
	{
		(int? ReturnCode, byte? AddLot, string PromptAddMsg, string PromptAddButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar) DcCycleValLotSP(string DCItemItem,
		string DCItemWhse,
		string DCItemLoc,
		string DCItemLot,
		string Title = null,
		byte? AddLot = null,
		string PromptAddMsg = null,
		string PromptAddButtons = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null);
	}
	
	public class DcCycleValLot : IDcCycleValLot
	{
		readonly IApplicationDB appDB;
		
		public DcCycleValLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? AddLot, string PromptAddMsg, string PromptAddButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar) DcCycleValLotSP(string DCItemItem,
		string DCItemWhse,
		string DCItemLoc,
		string DCItemLot,
		string Title = null,
		byte? AddLot = null,
		string PromptAddMsg = null,
		string PromptAddButtons = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null)
		{
			ItemType _DCItemItem = DCItemItem;
			WhseType _DCItemWhse = DCItemWhse;
			LocType _DCItemLoc = DCItemLoc;
			LotType _DCItemLot = DCItemLot;
			LongListType _Title = Title;
			ByteType _AddLot = AddLot;
			InfobarType _PromptAddMsg = PromptAddMsg;
			InfobarType _PromptAddButtons = PromptAddButtons;
			InfobarType _PromptExpLotMsg = PromptExpLotMsg;
			InfobarType _PromptExpLotButtons = PromptExpLotButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcCycleValLotSP";
				
				appDB.AddCommandParameter(cmd, "DCItemItem", _DCItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemWhse", _DCItemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemLoc", _DCItemLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DCItemLot", _DCItemLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddLot", _AddLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddMsg", _PromptAddMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddButtons", _PromptAddButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotMsg", _PromptExpLotMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotButtons", _PromptExpLotButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AddLot = _AddLot;
				PromptAddMsg = _PromptAddMsg;
				PromptAddButtons = _PromptAddButtons;
				PromptExpLotMsg = _PromptExpLotMsg;
				PromptExpLotButtons = _PromptExpLotButtons;
				Infobar = _Infobar;
				
				return (Severity, AddLot, PromptAddMsg, PromptAddButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar);
			}
		}
	}
}
