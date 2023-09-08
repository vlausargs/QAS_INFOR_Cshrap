//PROJECT NAME: Finance
//CLASS NAME: SSSCCIPayOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIPayOne : ISSSCCIPayOne
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIPayOne(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? oSuccess,
			string Infobar) SSSCCIPayOneSp(
			string iInvNum,
			string iCustNum,
			int? oSuccess,
			string Infobar,
			int? TaskID = null)
		{
			InvNumType _iInvNum = iInvNum;
			CustNumType _iCustNum = iCustNum;
			ListYesNoType _oSuccess = oSuccess;
			Infobar _Infobar = Infobar;
			GenericNoType _TaskID = TaskID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIPayOneSp";
				
				appDB.AddCommandParameter(cmd, "iInvNum", _iInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oSuccess", _oSuccess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oSuccess = _oSuccess;
				Infobar = _Infobar;
				
				return (Severity, oSuccess, Infobar);
			}
		}
	}
}
