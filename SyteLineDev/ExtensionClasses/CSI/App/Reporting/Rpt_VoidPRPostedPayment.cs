//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoidPRPostedPayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoidPRPostedPayment : IRpt_VoidPRPostedPayment
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoidPRPostedPayment(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_VoidPRPostedPaymentSp(string SessionIDChar,
		string BankCode,
		int? BegCheckNum,
		int? EndCheckNum,
		string EmplType,
		int? DisplayHeader = 0,
		string Infobar = null,
		string BGSessionId = null,
		string pSite = null)
		{
			StringType _SessionIDChar = SessionIDChar;
			BankCodeType _BankCode = BankCode;
			GlCheckNumType _BegCheckNum = BegCheckNum;
			GlCheckNumType _EndCheckNum = EndCheckNum;
			EmpNumType _EmplType = EmplType;
			ListYesNoType _DisplayHeader = DisplayHeader;
			InfobarType _Infobar = Infobar;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoidPRPostedPaymentSp";
				
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCheckNum", _BegCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCheckNum", _EndCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmplType", _EmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
