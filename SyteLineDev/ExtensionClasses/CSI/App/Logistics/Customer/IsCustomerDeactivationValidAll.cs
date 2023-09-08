//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerDeactivationValidAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCustomerDeactivationValidAll : IIsCustomerDeactivationValidAll
	{
		readonly IApplicationDB appDB;
		
		
		public IsCustomerDeactivationValidAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsCustomerDeactivationValidAllSp(string CustNum,
		int? Active = 1,
		string SiteRef = null,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _Active = Active;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCustomerDeactivationValidAllSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
