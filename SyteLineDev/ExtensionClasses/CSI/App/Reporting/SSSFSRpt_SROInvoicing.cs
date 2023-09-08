//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROInvoicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROInvoicing : ISSSFSRpt_SROInvoicing
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROInvoicing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSRpt_SROInvoicingSp(string Mode = "ToBeInvoiced",
		string PBegSroNum = null,
		string PEndSroNum = null,
		int? PBegSroLine = null,
		int? PEndSroLine = null,
		int? PBegSroOper = null,
		int? PEndSroOper = null,
		string PBegBillMgr = null,
		string PEndBillMgr = null,
		string PBegCustNum = null,
		string PEndCustNum = null,
		string PBegRegion = null,
		string PEndRegion = null,
		DateTime? PBegTransDate = null,
		DateTime? PEndTransDate = null,
		DateTime? PBegCloseDate = null,
		DateTime? PEndCloseDate = null,
		int? PInclCalculated = 1,
		int? PInclProject = 1,
		string PInvCred = "I",
		DateTime? PInvDate = null,
		int? PTransDom = 0,
		string SortBy = "S",
		string StartInvNum = null,
		string EndInvNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string MooreForm = "N",
		int? PrintCustomerNotes = 0,
		int? PrintSRONotes = 0,
		int? PrintSROLineNotes = 0,
		int? PrintSROOperNotes = 0,
		int? PrintTransNotes = 0,
		int? PrintInternalNotes = 0,
		int? PrintExternalNotes = 0,
		int? PrintSerials = 0,
		int? PrintMatl = 0,
		int? PrintLabor = 0,
		int? PrintMisc = 0,
		int? SummarizeTrans = 0,
		string BillCustCons = "U",
		int? PrintEuroTotal = 0,
		int? InclBillHold = 1,
		string OperationStatus = "I",
		int? DisplayHeader = null,
		string OrderBy = "N",
		string Infobar = null,
		string pSite = null)
		{
			StringType _Mode = Mode;
			FSSRONumType _PBegSroNum = PBegSroNum;
			FSSRONumType _PEndSroNum = PEndSroNum;
			FSSROLineType _PBegSroLine = PBegSroLine;
			FSSROLineType _PEndSroLine = PEndSroLine;
			FSSROOperType _PBegSroOper = PBegSroOper;
			FSSROOperType _PEndSroOper = PEndSroOper;
			FSPartnerType _PBegBillMgr = PBegBillMgr;
			FSPartnerType _PEndBillMgr = PEndBillMgr;
			CustNumType _PBegCustNum = PBegCustNum;
			CustNumType _PEndCustNum = PEndCustNum;
			FSRegionType _PBegRegion = PBegRegion;
			FSRegionType _PEndRegion = PEndRegion;
			DateType _PBegTransDate = PBegTransDate;
			DateType _PEndTransDate = PEndTransDate;
			CurrentDateType _PBegCloseDate = PBegCloseDate;
			CurrentDateType _PEndCloseDate = PEndCloseDate;
			ListYesNoType _PInclCalculated = PInclCalculated;
			ListYesNoType _PInclProject = PInclProject;
			LongListType _PInvCred = PInvCred;
			DateType _PInvDate = PInvDate;
			ListYesNoType _PTransDom = PTransDom;
			StringType _SortBy = SortBy;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			StringType _MooreForm = MooreForm;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintSRONotes = PrintSRONotes;
			ListYesNoType _PrintSROLineNotes = PrintSROLineNotes;
			ListYesNoType _PrintSROOperNotes = PrintSROOperNotes;
			ListYesNoType _PrintTransNotes = PrintTransNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintSerials = PrintSerials;
			ListYesNoType _PrintMatl = PrintMatl;
			ListYesNoType _PrintLabor = PrintLabor;
			ListYesNoType _PrintMisc = PrintMisc;
			ListYesNoType _SummarizeTrans = SummarizeTrans;
			StringType _BillCustCons = BillCustCons;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			ListYesNoType _InclBillHold = InclBillHold;
			StringType _OperationStatus = OperationStatus;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _OrderBy = OrderBy;
			Infobar _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROInvoicingSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroNum", _PBegSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroNum", _PEndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroLine", _PBegSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroLine", _PEndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroOper", _PBegSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroOper", _PEndSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegBillMgr", _PBegBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndBillMgr", _PEndBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegCustNum", _PBegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegRegion", _PBegRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndRegion", _PEndRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTransDate", _PBegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTransDate", _PEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegCloseDate", _PBegCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCloseDate", _PEndCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclCalculated", _PInclCalculated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclProject", _PInclProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvCred", _PInvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDom", _PTransDom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MooreForm", _MooreForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSRONotes", _PrintSRONotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROLineNotes", _PrintSROLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROOperNotes", _PrintSROOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTransNotes", _PrintTransNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerials", _PrintSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMatl", _PrintMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLabor", _PrintLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintMisc", _PrintMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummarizeTrans", _SummarizeTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCustCons", _BillCustCons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationStatus", _OperationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
