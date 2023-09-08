//PROJECT NAME: CSICustomer
//CLASS NAME: IsCustomerActiveAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IIsCustomerActiveAll
	{
		int IsCustomerActiveAllSp(string CustNum,
		                          string SiteRef,
		                          ref string Infobar);
	}
	
	public class IsCustomerActiveAll : IIsCustomerActiveAll
	{
		readonly IApplicationDB appDB;
		
		public IsCustomerActiveAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int IsCustomerActiveAllSp(string CustNum,
		                                 string SiteRef,
		                                 ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsCustomerActiveAllSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
