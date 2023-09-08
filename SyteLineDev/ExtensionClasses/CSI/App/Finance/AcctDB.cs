//PROJECT NAME: Finance
//CLASS NAME: AcctDB.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IAcctDB
	{
		(int? ReturnCode, string rDescription) AcctDBSp(string pAccount,
		string rDescription,
		string pSiteRef);
	}

	public class AcctDB : IAcctDB
	{
		readonly IApplicationDB appDB;


		public AcctDB(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode, string rDescription) AcctDBSp(string pAccount,
		string rDescription,
		string pSiteRef)
		{
			AcctType _pAccount = pAccount;
			DescriptionType _rDescription = rDescription;
			SiteType _pSiteRef = pSiteRef;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AcctDBSp";

				appDB.AddCommandParameter(cmd, "pAccount", _pAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rDescription", _rDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSiteRef", _pSiteRef, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				rDescription = _rDescription;

				return (Severity, rDescription);
			}
		}
	}
}
