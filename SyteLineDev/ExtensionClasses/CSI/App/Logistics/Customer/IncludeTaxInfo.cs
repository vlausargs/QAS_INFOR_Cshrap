//PROJECT NAME: CSICustomer
//CLASS NAME: IncludeTaxInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IIncludeTaxInfo
	{
		(int? ReturnCode, string Infobar) IncludeTaxInfoSP(string RmaNum,
		int? LineNum,
		string CoNum = null,
		string CustNum = null,
		string Infobar = null);
	}
	
	public class IncludeTaxInfo : IIncludeTaxInfo
	{
		readonly IApplicationDB appDB;
		
		public IncludeTaxInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) IncludeTaxInfoSP(string RmaNum,
		int? LineNum,
		string CoNum = null,
		string CustNum = null,
		string Infobar = null)
		{
			RmaNumType _RmaNum = RmaNum;
			IntType _LineNum = LineNum;
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IncludeTaxInfoSP";
				
				appDB.AddCommandParameter(cmd, "RmaNum", _RmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNum", _LineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
