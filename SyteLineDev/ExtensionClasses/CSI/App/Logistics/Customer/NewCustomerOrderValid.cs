//PROJECT NAME: Logistics
//CLASS NAME: NewCustomerOrderValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class NewCustomerOrderValid : INewCustomerOrderValid
	{
		readonly IApplicationDB appDB;
		
		
		public NewCustomerOrderValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) NewCustomerOrderValidSp(int? CoTableFlag,
		string CoNum,
		string Infobar)
		{
			IntType _CoTableFlag = CoTableFlag;
			CoNumType _CoNum = CoNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NewCustomerOrderValidSp";
				
				appDB.AddCommandParameter(cmd, "CoTableFlag", _CoTableFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
