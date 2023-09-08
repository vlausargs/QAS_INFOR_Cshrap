//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROWorkOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROWorkOrder : ISSSFSRpt_SROWorkOrder
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROWorkOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROWorkOrderSp(string StartSRONum = null,
		string EndSRONum = null,
		int? StartSROLine = null,
		int? EndSROLine = null,
		int? StartSROOper = null,
		int? EndSROOper = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string StartSerNum = null,
		string EndSerNum = null,
		string Type = "P",
		int? PrintDetail = 1,
		int? PrintReasonCodes = 0,
		int? PrintShipTo = 0,
		int? PrintWarrantyInfo = 0,
		int? PrintSRONotes = 0,
		int? PrintLineNotes = 0,
		int? PrintOperNotes = 0,
		int? PrintCustomerNotes = 0,
		int? PrintReasonNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? DisplayHeader = null,
		int? PrintOpen = 1,
		int? PrintClosed = 0,
		int? PrintEstimate = 0,
		string pSite = null)
		{
			FSSRONumType _StartSRONum = StartSRONum;
			FSSRONumType _EndSRONum = EndSRONum;
			FSSROLineType _StartSROLine = StartSROLine;
			FSSROLineType _EndSROLine = EndSROLine;
			FSSROOperType _StartSROOper = StartSROOper;
			FSSROOperType _EndSROOper = EndSROOper;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			SerNumType _StartSerNum = StartSerNum;
			SerNumType _EndSerNum = EndSerNum;
			FSSROTransTypeType _Type = Type;
			ListYesNoType _PrintDetail = PrintDetail;
			ListYesNoType _PrintReasonCodes = PrintReasonCodes;
			ListYesNoType _PrintShipTo = PrintShipTo;
			ListYesNoType _PrintWarrantyInfo = PrintWarrantyInfo;
			ListYesNoType _PrintSRONotes = PrintSRONotes;
			ListYesNoType _PrintLineNotes = PrintLineNotes;
			ListYesNoType _PrintOperNotes = PrintOperNotes;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintReasonNotes = PrintReasonNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintOpen = PrintOpen;
			ListYesNoType _PrintClosed = PrintClosed;
			ListYesNoType _PrintEstimate = PrintEstimate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROWorkOrderSp";
				
				appDB.AddCommandParameter(cmd, "StartSRONum", _StartSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSRONum", _EndSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROLine", _StartSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROLine", _EndSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROOper", _StartSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROOper", _EndSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSerNum", _StartSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSerNum", _EndSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDetail", _PrintDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReasonCodes", _PrintReasonCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipTo", _PrintShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintWarrantyInfo", _PrintWarrantyInfo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSRONotes", _PrintSRONotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineNotes", _PrintLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOperNotes", _PrintOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReasonNotes", _PrintReasonNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOpen", _PrintOpen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintClosed", _PrintClosed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEstimate", _PrintEstimate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
