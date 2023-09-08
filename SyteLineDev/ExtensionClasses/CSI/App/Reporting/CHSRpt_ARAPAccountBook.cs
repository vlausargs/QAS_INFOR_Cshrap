//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ARAPAccountBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_ARAPAccountBook
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ARAPAccountBookSp(string AccountUnit = null,
		string CustVend = null,
		string Account = null,
		string Unit1 = null,
		string Unit2 = null,
		string Unit3 = null,
		string Unit4 = null,
		string BegCust = null,
		string EndCust = null,
		string BegVend = null,
		string EndVend = null,
		DateTime? BegDate = null,
		DateTime? EndDate = null,
		byte? DetailShow = (byte)1,
		byte? Currency = (byte)1,
		string pSite = null);
	}
	
	public class CHSRpt_ARAPAccountBook : ICHSRpt_ARAPAccountBook
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_ARAPAccountBook(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_ARAPAccountBookSp(string AccountUnit = null,
		string CustVend = null,
		string Account = null,
		string Unit1 = null,
		string Unit2 = null,
		string Unit3 = null,
		string Unit4 = null,
		string BegCust = null,
		string EndCust = null,
		string BegVend = null,
		string EndVend = null,
		DateTime? BegDate = null,
		DateTime? EndDate = null,
		byte? DetailShow = (byte)1,
		byte? Currency = (byte)1,
		string pSite = null)
		{
			InitialType _AccountUnit = AccountUnit;
			InitialType _CustVend = CustVend;
			AcctType _Account = Account;
			UnitCode1Type _Unit1 = Unit1;
			UnitCode2Type _Unit2 = Unit2;
			UnitCode3Type _Unit3 = Unit3;
			UnitCode4Type _Unit4 = Unit4;
			CustNumType _BegCust = BegCust;
			CustNumType _EndCust = EndCust;
			VendNumType _BegVend = BegVend;
			VendNumType _EndVend = EndVend;
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			ListYesNoType _DetailShow = DetailShow;
			ListYesNoType _Currency = Currency;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_ARAPAccountBookSp";
				
				appDB.AddCommandParameter(cmd, "AccountUnit", _AccountUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVend", _CustVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Account", _Account, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit1", _Unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit2", _Unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit3", _Unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit4", _Unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCust", _BegCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVend", _BegVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVend", _EndVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailShow", _DetailShow, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Currency", _Currency, ParameterDirection.Input);
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
