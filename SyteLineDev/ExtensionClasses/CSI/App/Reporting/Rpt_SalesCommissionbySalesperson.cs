//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesCommissionbySalesperson.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SalesCommissionbySalesperson : IRpt_SalesCommissionbySalesperson
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SalesCommissionbySalesperson(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesCommissionbySalespersonSp(string StartSalesman = null,
		string EndSalesman = null,
		string StartClass = null,
		string EndClass = null,
		DateTime? StartDueDate = null,
		DateTime? EndDueDate = null,
		string CommStatus = null,
		int? PrintPaidRec = null,
		int? PageForSalesman = null,
		int? PrintPaymentDetail = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? PDisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			SlsmanType _StartSalesman = StartSalesman;
			SlsmanType _EndSalesman = EndSalesman;
			SlsclassType _StartClass = StartClass;
			SlsclassType _EndClass = EndClass;
			GenericDateType _StartDueDate = StartDueDate;
			GenericDateType _EndDueDate = EndDueDate;
			InfobarType _CommStatus = CommStatus;
			FlagNyType _PrintPaidRec = PrintPaidRec;
			FlagNyType _PageForSalesman = PageForSalesman;
			FlagNyType _PrintPaymentDetail = PrintPaymentDetail;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SalesCommissionbySalespersonSp";
				
				appDB.AddCommandParameter(cmd, "StartSalesman", _StartSalesman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSalesman", _EndSalesman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartClass", _StartClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndClass", _EndClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommStatus", _CommStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPaidRec", _PrintPaidRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageForSalesman", _PageForSalesman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPaymentDetail", _PrintPaymentDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
