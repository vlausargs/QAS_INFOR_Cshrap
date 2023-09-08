//PROJECT NAME: Material
//CLASS NAME: TransferItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TransferItemValid : ITransferItemValid
	{
		readonly IApplicationDB appDB;
		
		
		public TransferItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemDesc,
		int? Kit,
		string Infobar,
		string PromptMsgOS,
		string PromptBtnsOS) TransferItemValidSp(string Item,
		decimal? Qty,
		string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string ItemDesc,
		int? Kit,
		string Infobar,
		string PromptMsgOS = null,
		string PromptBtnsOS = null)
		{
			ItemType _Item = Item;
			QtyUnitType _Qty = Qty;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			DescriptionType _ItemDesc = ItemDesc;
			ListYesNoType _Kit = Kit;
			InfobarType _Infobar = Infobar;
			Infobar _PromptMsgOS = PromptMsgOS;
			Infobar _PromptBtnsOS = PromptBtnsOS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferItemValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgOS", _PromptMsgOS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptBtnsOS", _PromptBtnsOS, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemDesc = _ItemDesc;
				Kit = _Kit;
				Infobar = _Infobar;
				PromptMsgOS = _PromptMsgOS;
				PromptBtnsOS = _PromptBtnsOS;
				
				return (Severity, ItemDesc, Kit, Infobar, PromptMsgOS, PromptBtnsOS);
			}
		}
	}
}
