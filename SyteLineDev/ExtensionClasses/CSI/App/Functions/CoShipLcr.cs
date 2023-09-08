//PROJECT NAME: Data
//CLASS NAME: CoShipLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoShipLcr : ICoShipLcr
	{
		readonly IApplicationDB appDB;
		
		public CoShipLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) CoShipLcrSp(
			string pCoNum,
			DateTime? pTransDate,
			string pMText,
			int? pSuppressErrorWhenCustomerLcrNotReqd,
			string rInfobar)
		{
			CoNumType _pCoNum = pCoNum;
			DateType _pTransDate = pTransDate;
			LongListType _pMText = pMText;
			ListYesNoType _pSuppressErrorWhenCustomerLcrNotReqd = pSuppressErrorWhenCustomerLcrNotReqd;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoShipLcrSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMText", _pMText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuppressErrorWhenCustomerLcrNotReqd", _pSuppressErrorWhenCustomerLcrNotReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
