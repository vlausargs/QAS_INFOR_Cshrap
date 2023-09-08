//PROJECT NAME: Data
//CLASS NAME: ConInvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConInvPost : IConInvPost
	{
		readonly IApplicationDB appDB;
		
		public ConInvPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			string DoHdrList,
			int? PrintConInvReport) ConInvPostSp(
			Guid? SessionId,
			string PInvNum,
			DateTime? PInvDate,
			string PStartCustNum,
			string PEndCustNum,
			string PStartDoNum,
			string PEndDoNum,
			string PStartCustPoNum,
			string PEndCustPoNum,
			string PMooreForm,
			int? PInclNonDraft,
			int? PLCR,
			int? POrderNums,
			int? PEuroTotal,
			int? PTransToDom,
			int? PSerialNums,
			int? PPlanItemMats,
			string PConfigDetails,
			int? PItemTypeItem,
			int? PItemTypeCust,
			int? PBillToText,
			int? PStdOrderText,
			string PLineRelText,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			string DoHdrList,
			int? PrintConInvReport,
			decimal? PStartingShipment,
			decimal? PEndingShipment)
		{
			RowPointerType _SessionId = SessionId;
			InvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			CustNumType _PStartCustNum = PStartCustNum;
			CustNumType _PEndCustNum = PEndCustNum;
			DoNumType _PStartDoNum = PStartDoNum;
			DoNumType _PEndDoNum = PEndDoNum;
			CustPoType _PStartCustPoNum = PStartCustPoNum;
			CustPoType _PEndCustPoNum = PEndCustPoNum;
			StringType _PMooreForm = PMooreForm;
			ListYesNoType _PInclNonDraft = PInclNonDraft;
			ListYesNoType _PLCR = PLCR;
			ListYesNoType _POrderNums = POrderNums;
			ListYesNoType _PEuroTotal = PEuroTotal;
			ListYesNoType _PTransToDom = PTransToDom;
			ListYesNoType _PSerialNums = PSerialNums;
			ListYesNoType _PPlanItemMats = PPlanItemMats;
			StringType _PConfigDetails = PConfigDetails;
			ListYesNoType _PItemTypeItem = PItemTypeItem;
			ListYesNoType _PItemTypeCust = PItemTypeCust;
			ListYesNoType _PBillToText = PBillToText;
			ListYesNoType _PStdOrderText = PStdOrderText;
			StringType _PLineRelText = PLineRelText;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			Infobar _Infobar = Infobar;
			LongListType _DoHdrList = DoHdrList;
			Flag _PrintConInvReport = PrintConInvReport;
			ShipmentIDType _PStartingShipment = PStartingShipment;
			ShipmentIDType _PEndingShipment = PEndingShipment;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConInvPostSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCustNum", _PStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDoNum", _PStartDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDoNum", _PEndDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCustPoNum", _PStartCustPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustPoNum", _PEndCustPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMooreForm", _PMooreForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclNonDraft", _PInclNonDraft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLCR", _PLCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderNums", _POrderNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroTotal", _PEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransToDom", _PTransToDom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerialNums", _PSerialNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanItemMats", _PPlanItemMats, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConfigDetails", _PConfigDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTypeItem", _PItemTypeItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTypeCust", _PItemTypeCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBillToText", _PBillToText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStdOrderText", _PStdOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLineRelText", _PLineRelText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DoHdrList", _DoHdrList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintConInvReport", _PrintConInvReport, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartingShipment", _PStartingShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingShipment", _PEndingShipment, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartInvNum = _StartInvNum;
				EndInvNum = _EndInvNum;
				Infobar = _Infobar;
				DoHdrList = _DoHdrList;
				PrintConInvReport = _PrintConInvReport;
				
				return (Severity, StartInvNum, EndInvNum, Infobar, DoHdrList, PrintConInvReport);
			}
		}
	}
}
