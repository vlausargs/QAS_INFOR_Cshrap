//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMACreditMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RMACreditMemo : IRpt_RMACreditMemo
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RMACreditMemo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMACreditMemoSp(Guid? pSessionID = null,
		string ProcessReprint = "R",
		string PrintItemCustItem = "CI",
		int? TPrSerialNum = 0,
		int? TTransDomCurr = 0,
		string BCrmNum = null,
		string ECrmNum = null,
		DateTime? BCrmDate = null,
		DateTime? ECrmDate = null,
		int? PrintOrderNotes = 0,
		int? PrintRMANotes = 0,
		int? PrintShipToNotes = 0,
		int? PrintBillToNotes = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? PrintItemOverview = null,
		int? PrintRMALineNotes = 0,
		int? PrintLotNumbers = 1,
		string BGSessionId = null,
		string pSite = null)
		{
			RowPointerType _pSessionID = pSessionID;
			StringType _ProcessReprint = ProcessReprint;
			StringType _PrintItemCustItem = PrintItemCustItem;
			ListYesNoType _TPrSerialNum = TPrSerialNum;
			ListYesNoType _TTransDomCurr = TTransDomCurr;
			InvNumType _BCrmNum = BCrmNum;
			InvNumType _ECrmNum = ECrmNum;
			DateType _BCrmDate = BCrmDate;
			DateType _ECrmDate = ECrmDate;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintRMANotes = PrintRMANotes;
			ListYesNoType _PrintShipToNotes = PrintShipToNotes;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			FlagNyType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintRMALineNotes = PrintRMALineNotes;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RMACreditMemoSp";
				
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessReprint", _ProcessReprint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustItem", _PrintItemCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPrSerialNum", _TPrSerialNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDomCurr", _TTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCrmNum", _BCrmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECrmNum", _ECrmNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCrmDate", _BCrmDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECrmDate", _ECrmDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMANotes", _PrintRMANotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipToNotes", _PrintShipToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMALineNotes", _PrintRMALineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
