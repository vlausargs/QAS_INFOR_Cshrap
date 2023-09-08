//PROJECT NAME: Data
//CLASS NAME: RepCoCreditHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCoCreditHold : IRepCoCreditHold
	{
		readonly IApplicationDB appDB;
		
		public RepCoCreditHold(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepCoCreditHoldSp(
			string pDestSite,
			string pCoNum,
			int? pCreditHold = null,
			string pCreditHoldReason = null,
			string pCreditHoldUser = null,
			DateTime? pCreditHoldDate = null,
			string Infobar = null)
		{
			SiteType _pDestSite = pDestSite;
			CoNumType _pCoNum = pCoNum;
			ListYesNoType _pCreditHold = pCreditHold;
			ReasonCodeType _pCreditHoldReason = pCreditHoldReason;
			UserCodeType _pCreditHoldUser = pCreditHoldUser;
			DateType _pCreditHoldDate = pCreditHoldDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCoCreditHoldSp";
				
				appDB.AddCommandParameter(cmd, "pDestSite", _pDestSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHold", _pCreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldReason", _pCreditHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldUser", _pCreditHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditHoldDate", _pCreditHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
