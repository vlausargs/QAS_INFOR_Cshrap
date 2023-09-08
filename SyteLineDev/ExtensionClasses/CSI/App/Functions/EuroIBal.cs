//PROJECT NAME: Data
//CLASS NAME: EuroIBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroIBal : IEuroIBal
	{
		readonly IApplicationDB appDB;
		
		public EuroIBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? rNetDue) EuroIBalSp(
			string pCustNum,
			string pInvNum,
			decimal? rNetDue)
		{
			CustNumType _pCustNum = pCustNum;
			InvNumType _pInvNum = pInvNum;
			GenericDecimalType _rNetDue = rNetDue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroIBalSp";
				
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvNum", _pInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rNetDue", _rNetDue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rNetDue = _rNetDue;
				
				return (Severity, rNetDue);
			}
		}
	}
}
