//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CashRequirements.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CashRequirements
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CashRequirementsSp(string ExOptszSiteGroup = null,
		DateTime? ExHbegDueDate = null,
		DateTime? ExEndDueDate = null,
		string ExHbegVendNum = null,
		string ExEndVendNum = null,
		string ExHbegName = null,
		string ExEndName = null,
		DateTime? ExOptprPaymentDate = null,
		byte? ExOptszSupZeroNetDue = null,
		byte? ExOptprPrOpenPay = null,
		byte? ExOptszSubByMonth = null,
		byte? ETransDomCurr = null,
		string PExOptprPayHold = null,
		short? CashDateStartingOffset = null,
		short? CashDateEndingOffset = null,
		short? DateOffset = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_CashRequirements : IRpt_CashRequirements
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CashRequirements(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CashRequirementsSp(string ExOptszSiteGroup = null,
		DateTime? ExHbegDueDate = null,
		DateTime? ExEndDueDate = null,
		string ExHbegVendNum = null,
		string ExEndVendNum = null,
		string ExHbegName = null,
		string ExEndName = null,
		DateTime? ExOptprPaymentDate = null,
		byte? ExOptszSupZeroNetDue = null,
		byte? ExOptprPrOpenPay = null,
		byte? ExOptszSubByMonth = null,
		byte? ETransDomCurr = null,
		string PExOptprPayHold = null,
		short? CashDateStartingOffset = null,
		short? CashDateEndingOffset = null,
		short? DateOffset = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			SiteGroupType _ExOptszSiteGroup = ExOptszSiteGroup;
			DateType _ExHbegDueDate = ExHbegDueDate;
			DateType _ExEndDueDate = ExEndDueDate;
			VendNumType _ExHbegVendNum = ExHbegVendNum;
			VendNumType _ExEndVendNum = ExEndVendNum;
			NameType _ExHbegName = ExHbegName;
			NameType _ExEndName = ExEndName;
			DateType _ExOptprPaymentDate = ExOptprPaymentDate;
			ListYesNoType _ExOptszSupZeroNetDue = ExOptszSupZeroNetDue;
			ListYesNoType _ExOptprPrOpenPay = ExOptprPrOpenPay;
			ListYesNoType _ExOptszSubByMonth = ExOptszSubByMonth;
			FlagNyType _ETransDomCurr = ETransDomCurr;
			InfobarType _PExOptprPayHold = PExOptprPayHold;
			DateOffsetType _CashDateStartingOffset = CashDateStartingOffset;
			DateOffsetType _CashDateEndingOffset = CashDateEndingOffset;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CashRequirementsSp";
				
				appDB.AddCommandParameter(cmd, "ExOptszSiteGroup", _ExOptszSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExHbegDueDate", _ExHbegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndDueDate", _ExEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExHbegVendNum", _ExHbegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndVendNum", _ExEndVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExHbegName", _ExHbegName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndName", _ExEndName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPaymentDate", _ExOptprPaymentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSupZeroNetDue", _ExOptszSupZeroNetDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPrOpenPay", _ExOptprPrOpenPay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSubByMonth", _ExOptszSubByMonth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETransDomCurr", _ETransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExOptprPayHold", _PExOptprPayHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CashDateStartingOffset", _CashDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CashDateEndingOffset", _CashDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
