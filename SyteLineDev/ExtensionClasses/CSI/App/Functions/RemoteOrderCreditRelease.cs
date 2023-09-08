//PROJECT NAME: Data
//CLASS NAME: RemoteOrderCreditRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteOrderCreditRelease : IRemoteOrderCreditRelease
	{
		readonly IApplicationDB appDB;
		
		public RemoteOrderCreditRelease(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RemoteOrderCreditReleaseSp(
			string StartingCustomer,
			string EndingCustomer,
			string StartingOrder,
			string EndingOrder,
			string Infobar)
		{
			CustNumType _StartingCustomer = StartingCustomer;
			CustNumType _EndingCustomer = EndingCustomer;
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteOrderCreditReleaseSp";
				
				appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
