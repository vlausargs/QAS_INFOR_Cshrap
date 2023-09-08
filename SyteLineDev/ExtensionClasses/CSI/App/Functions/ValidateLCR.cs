//PROJECT NAME: Data
//CLASS NAME: ValidateLCR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateLCR : IValidateLCR
	{
		readonly IApplicationDB appDB;
		
		public ValidateLCR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) ValidateLCRSp(
			string pText,
			string pCoNum,
			DateTime? pDate = null,
			string pParmsSite = null,
			DateTime? pBegDueDate = null,
			DateTime? pEndDueDate = null,
			string pWarehouse = null,
			int? pSuppressErrorWhenCustomerLcrNotReqd = null,
			string rInfobar = null)
		{
			LongListType _pText = pText;
			CoNumType _pCoNum = pCoNum;
			DateType _pDate = pDate;
			SiteType _pParmsSite = pParmsSite;
			DateType _pBegDueDate = pBegDueDate;
			DateType _pEndDueDate = pEndDueDate;
			WhseType _pWarehouse = pWarehouse;
			ListYesNoType _pSuppressErrorWhenCustomerLcrNotReqd = pSuppressErrorWhenCustomerLcrNotReqd;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateLCRSp";
				
				appDB.AddCommandParameter(cmd, "pText", _pText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDate", _pDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pParmsSite", _pParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegDueDate", _pBegDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWarehouse", _pWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuppressErrorWhenCustomerLcrNotReqd", _pSuppressErrorWhenCustomerLcrNotReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
