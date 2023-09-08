//PROJECT NAME: CSIVendor
//CLASS NAME: POValidateNegativeQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOValidateNegativeQty
	{
		int POValidateNegativeQtySp(string PoitemItem,
		                            string TtRcvPoNum,
		                            string PoitemWhse,
		                            string TtRcvLoc,
		                            string TtRcvLot,
		                            decimal? TtRcvTcQtuToReceive,
		                            byte? TtRcvDrReturn,
		                            string TtRcvImportDocId,
		                            ref string PromptMsg,
		                            ref string PromptButtons,
		                            ref string Infobar);
	}
	
	public class POValidateNegativeQty : IPOValidateNegativeQty
	{
		readonly IApplicationDB appDB;
		
		public POValidateNegativeQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int POValidateNegativeQtySp(string PoitemItem,
		                                   string TtRcvPoNum,
		                                   string PoitemWhse,
		                                   string TtRcvLoc,
		                                   string TtRcvLot,
		                                   decimal? TtRcvTcQtuToReceive,
		                                   byte? TtRcvDrReturn,
		                                   string TtRcvImportDocId,
		                                   ref string PromptMsg,
		                                   ref string PromptButtons,
		                                   ref string Infobar)
		{
			ItemType _PoitemItem = PoitemItem;
			PoNumType _TtRcvPoNum = TtRcvPoNum;
			WhseType _PoitemWhse = PoitemWhse;
			LocType _TtRcvLoc = TtRcvLoc;
			LotType _TtRcvLot = TtRcvLot;
			QtyUnitType _TtRcvTcQtuToReceive = TtRcvTcQtuToReceive;
			ListYesNoType _TtRcvDrReturn = TtRcvDrReturn;
			ImportDocIdType _TtRcvImportDocId = TtRcvImportDocId;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POValidateNegativeQtySp";
				
				appDB.AddCommandParameter(cmd, "PoitemItem", _PoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvPoNum", _TtRcvPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoitemWhse", _PoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvLoc", _TtRcvLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvLot", _TtRcvLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvTcQtuToReceive", _TtRcvTcQtuToReceive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvDrReturn", _TtRcvDrReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvImportDocId", _TtRcvImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
