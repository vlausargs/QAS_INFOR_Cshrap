//PROJECT NAME: Logistics
//CLASS NAME: IsCustomerDeactivationValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IsCustomerDeactivationValid : IIsCustomerDeactivationValid
	{
		readonly IApplicationDB appDB;
		
		
		public IsCustomerDeactivationValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IsCustomerDeactivationValidSp(string CustNum,
		int? Active = 1,
		int? FromMethod = 1,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _Active = Active;
			ListYesNoType _FromMethod = FromMethod;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCustomerDeactivationValidSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMethod", _FromMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
