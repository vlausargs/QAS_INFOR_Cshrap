//PROJECT NAME: Finance
//CLASS NAME: ARActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARActive : IARActive
	{
		readonly IApplicationDB appDB;
		
		public ARActive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ARActiveSp(
			string pInvNum,
			string CustNum,
			int? pActive,
			int? pMsg,
			string Site = null,
			int? BatchUpdate = 0,
			string Infobar = null,
			int? CallRaiseError = 1,
			string CustaddrCorpCust = null)
		{
			InvNumType _pInvNum = pInvNum;
			CustNumType _CustNum = CustNum;
			Flag _pActive = pActive;
			Flag _pMsg = pMsg;
			SiteType _Site = Site;
			ListYesNoType _BatchUpdate = BatchUpdate;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CallRaiseError = CallRaiseError;
			CustNumType _CustaddrCorpCust = CustaddrCorpCust;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARActiveSp";
				
				appDB.AddCommandParameter(cmd, "pInvNum", _pInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pActive", _pActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMsg", _pMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchUpdate", _BatchUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallRaiseError", _CallRaiseError, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustaddrCorpCust", _CustaddrCorpCust, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
