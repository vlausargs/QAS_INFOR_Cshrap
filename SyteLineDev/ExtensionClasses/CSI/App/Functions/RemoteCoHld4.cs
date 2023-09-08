//PROJECT NAME: Data
//CLASS NAME: RemoteCoHld4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteCoHld4 : IRemoteCoHld4
	{
		readonly IApplicationDB appDB;
		
		public RemoteCoHld4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? Counter) RemoteCoHld4Sp(
			string StartingCustNum,
			string EndingCustNum,
			string StartingOrder,
			string EndingOrder,
			int? SubCustomer,
			string Infobar = null,
			int? Counter = 0)
		{
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			ListYesNoType _SubCustomer = SubCustomer;
			InfobarType _Infobar = Infobar;
			IntType _Counter = Counter;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteCoHld4Sp";
				
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubCustomer", _SubCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Counter = _Counter;
				
				return (Severity, Infobar, Counter);
			}
		}
	}
}
