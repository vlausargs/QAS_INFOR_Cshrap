//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderProFormaInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderProFormaInvoice : IRpt_PrintDeliveryOrderProFormaInvoice
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintDeliveryOrderProFormaInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderProFormaInvoiceSp(string DOStarting = null,
		string DOEnding = null,
		int? PrintBlankPickupDate = null,
		int? PrintDOSeqText = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? PickupDateStartingOffset = null,
		int? PickupDateEndingOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null)
		{
			DoNumType _DOStarting = DOStarting;
			DoNumType _DOEnding = DOEnding;
			FlagNyType _PrintBlankPickupDate = PrintBlankPickupDate;
			FlagNyType _PrintDOSeqText = PrintDOSeqText;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CustSeqType _CustSeqStarting = CustSeqStarting;
			CustSeqType _CustSeqEnding = CustSeqEnding;
			DateType _PickupDateStarting = PickupDateStarting;
			DateType _PickupDateEnding = PickupDateEnding;
			DateOffsetType _PickupDateStartingOffset = PickupDateStartingOffset;
			DateOffsetType _PickupDateEndingOffset = PickupDateEndingOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _PrintItemOverview = PrintItemOverview;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintDeliveryOrderProFormaInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "DOStarting", _DOStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DOEnding", _DOEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBlankPickupDate", _PrintBlankPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDOSeqText", _PrintDOSeqText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqStarting", _CustSeqStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqEnding", _CustSeqEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStarting", _PickupDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEnding", _PickupDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStartingOffset", _PickupDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEndingOffset", _PickupDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
