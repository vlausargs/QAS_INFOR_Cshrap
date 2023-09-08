//PROJECT NAME: CSICustomer
//CLASS NAME: DelRma.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDelRma
	{
		(int? ReturnCode, string Infobar) DelRmaSp(string BeginRmaNum,
		string EndRmaNum,
		DateTime? RmaEndDate,
		string Infobar,
		short? RMADateOffset = null);
	}
	
	public class DelRma : IDelRma
	{
		readonly IApplicationDB appDB;
		
		public DelRma(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DelRmaSp(string BeginRmaNum,
		string EndRmaNum,
		DateTime? RmaEndDate,
		string Infobar,
		short? RMADateOffset = null)
		{
			RmaNumType _BeginRmaNum = BeginRmaNum;
			RmaNumType _EndRmaNum = EndRmaNum;
			DateType _RmaEndDate = RmaEndDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _RMADateOffset = RMADateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelRmaSp";
				
				appDB.AddCommandParameter(cmd, "BeginRmaNum", _BeginRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRmaNum", _EndRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaEndDate", _RmaEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RMADateOffset", _RMADateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
