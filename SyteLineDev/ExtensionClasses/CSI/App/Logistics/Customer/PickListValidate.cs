//PROJECT NAME: CSICustomer
//CLASS NAME: PickListValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPickListValidate
	{
		(int? ReturnCode, string CustNum, int? CustSeq, string Whse, string ShipLoc, string Infobar, string Prompt, string PromptButtons, decimal? ShipmentId) PickListValidateSp(decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		string ShipLoc,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		decimal? ShipmentId = null);
	}
	
	public class PickListValidate : IPickListValidate
	{
		readonly IApplicationDB appDB;
		
		public PickListValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustNum, int? CustSeq, string Whse, string ShipLoc, string Infobar, string Prompt, string PromptButtons, decimal? ShipmentId) PickListValidateSp(decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		string ShipLoc,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null,
		decimal? ShipmentId = null)
		{
			PickListIDType _PickListId = PickListId;
			CustNumType _CustNum = CustNum;
			IntType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			LocType _ShipLoc = ShipLoc;
			InfobarType _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			ShipmentIDType _ShipmentId = ShipmentId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PickListValidateSp";
				
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipLoc", _ShipLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				Whse = _Whse;
				ShipLoc = _ShipLoc;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				ShipmentId = _ShipmentId;
				
				return (Severity, CustNum, CustSeq, Whse, ShipLoc, Infobar, Prompt, PromptButtons, ShipmentId);
			}
		}
	}
}
