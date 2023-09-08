//PROJECT NAME: Logistics
//CLASS NAME: RebalCu.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RebalCu : IRebalCu
	{
		readonly IApplicationDB appDB;
		
		
		public RebalCu(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustomersDone,
		string Infobar) RebalCuSp(string StartCustNum,
		string EndCustNum,
		string SiteGroup,
		int? CustomersDone,
		string Infobar,
		int? SetPostedBalancetoZero)
		{
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			SiteGroupType _SiteGroup = SiteGroup;
			IntType _CustomersDone = CustomersDone;
			InfobarType _Infobar = Infobar;
			ListYesNoType _SetPostedBalancetoZero = SetPostedBalancetoZero;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RebalCuSp";
				
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomersDone", _CustomersDone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SetPostedBalancetoZero", _SetPostedBalancetoZero, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustomersDone = _CustomersDone;
				Infobar = _Infobar;
				
				return (Severity, CustomersDone, Infobar);
			}
		}
	}
}
