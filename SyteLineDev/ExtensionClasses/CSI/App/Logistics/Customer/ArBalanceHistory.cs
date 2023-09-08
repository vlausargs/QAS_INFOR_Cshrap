//PROJECT NAME: CSICustomer
//CLASS NAME: ARBalanceHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IARBalanceHistory
	{
		(int? ReturnCode, string Infobar, int? ParamRecCount) ARBalanceHistorySp(string ParamBegCustNum,
		string ParamEndCustNum,
		DateTime? ParamThruDate,
		byte? ParamResetPeriod,
		string Infobar,
		int? ParamRecCount,
		short? ThruDateOffset = null);
	}
	
	public class ARBalanceHistory : IARBalanceHistory
	{
		readonly IApplicationDB appDB;
		
		public ARBalanceHistory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? ParamRecCount) ARBalanceHistorySp(string ParamBegCustNum,
		string ParamEndCustNum,
		DateTime? ParamThruDate,
		byte? ParamResetPeriod,
		string Infobar,
		int? ParamRecCount,
		short? ThruDateOffset = null)
		{
			CustNumType _ParamBegCustNum = ParamBegCustNum;
			CustNumType _ParamEndCustNum = ParamEndCustNum;
			DateType _ParamThruDate = ParamThruDate;
			FlagNyType _ParamResetPeriod = ParamResetPeriod;
			InfobarType _Infobar = Infobar;
			IntType _ParamRecCount = ParamRecCount;
			DateOffsetType _ThruDateOffset = ThruDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARBalanceHistorySp";
				
				appDB.AddCommandParameter(cmd, "ParamBegCustNum", _ParamBegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamEndCustNum", _ParamEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamThruDate", _ParamThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamResetPeriod", _ParamResetPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParamRecCount", _ParamRecCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThruDateOffset", _ThruDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ParamRecCount = _ParamRecCount;
				
				return (Severity, Infobar, ParamRecCount);
			}
		}
	}
}
