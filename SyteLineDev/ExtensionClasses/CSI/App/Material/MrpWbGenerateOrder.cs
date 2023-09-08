//PROJECT NAME: Material
//CLASS NAME: MrpWbGenerateOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGenerateOrder : IMrpWbGenerateOrder
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGenerateOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MrpWbGenerateOrderSp(decimal? UserID,
		string RefTab,
		string PoparmsPoPrefix = null,
		string PoChange = null,
		int? BlanketQtyOver = null,
		int? PurchReqNotes = null,
		string PoparmsPrqPrefix = null,
		string SfcparmsWoPrefix = null,
		int? CopyCurrentBOM = null,
		int? CopyIndentedBOM = null,
		string SfcparmsPsPrefix = null,
		int? SingleOrder = null,
		string InvparmsTrnPrefix = null,
		Guid? SessionID = null,
		int? CopyToPSItemBOM = null,
		string Infobar = null,
		int? CreateTransitLoc = 0)
		{
			TokenType _UserID = UserID;
			MrpWbTabType _RefTab = RefTab;
			PoNumType _PoparmsPoPrefix = PoparmsPoPrefix;
			ListAlwaysSometimesNeverType _PoChange = PoChange;
			ListYesNoType _BlanketQtyOver = BlanketQtyOver;
			ListYesNoType _PurchReqNotes = PurchReqNotes;
			ReqNumType _PoparmsPrqPrefix = PoparmsPrqPrefix;
			JobType _SfcparmsWoPrefix = SfcparmsWoPrefix;
			ListYesNoType _CopyCurrentBOM = CopyCurrentBOM;
			ListYesNoType _CopyIndentedBOM = CopyIndentedBOM;
			PsNumType _SfcparmsPsPrefix = SfcparmsPsPrefix;
			ListYesNoType _SingleOrder = SingleOrder;
			TrnNumType _InvparmsTrnPrefix = InvparmsTrnPrefix;
			RowPointerType _SessionID = SessionID;
			ListYesNoType _CopyToPSItemBOM = CopyToPSItemBOM;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CreateTransitLoc = CreateTransitLoc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGenerateOrderSp";
				
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefTab", _RefTab, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoparmsPoPrefix", _PoparmsPoPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoChange", _PoChange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BlanketQtyOver", _BlanketQtyOver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchReqNotes", _PurchReqNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoparmsPrqPrefix", _PoparmsPrqPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SfcparmsWoPrefix", _SfcparmsWoPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyCurrentBOM", _CopyCurrentBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyIndentedBOM", _CopyIndentedBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SfcparmsPsPrefix", _SfcparmsPsPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SingleOrder", _SingleOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvparmsTrnPrefix", _InvparmsTrnPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyToPSItemBOM", _CopyToPSItemBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateTransitLoc", _CreateTransitLoc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
