//PROJECT NAME: Logistics
//CLASS NAME: UpdateExchRateInfoByCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateExchRateInfoByCust : IUpdateExchRateInfoByCust
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateExchRateInfoByCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CurAllowOver,
		int? CurpAllowOver) UpdateExchRateInfoByCustSp(string CustNum,
		int? CurAllowOver,
		int? CurpAllowOver)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _CurAllowOver = CurAllowOver;
			ListYesNoType _CurpAllowOver = CurpAllowOver;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateExchRateInfoByCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurAllowOver", _CurAllowOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurpAllowOver", _CurpAllowOver, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurAllowOver = _CurAllowOver;
				CurpAllowOver = _CurpAllowOver;
				
				return (Severity, CurAllowOver, CurpAllowOver);
			}
		}
	}
}
