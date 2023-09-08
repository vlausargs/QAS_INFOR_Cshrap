//PROJECT NAME: CSICustomer
//CLASS NAME: DelShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDelShipment
	{
		(int? ReturnCode, string Infobar) DelShipmentSp(decimal? StartingShipment,
		decimal? EndingShipment,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string StartingCustNum,
		string EndingCustNum,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		string Infobar = null);
	}
	
	public class DelShipment : IDelShipment
	{
		readonly IApplicationDB appDB;
		
		public DelShipment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DelShipmentSp(decimal? StartingShipment,
		decimal? EndingShipment,
		DateTime? StartingDate,
		DateTime? EndingDate,
		string StartingCustNum,
		string EndingCustNum,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		string Infobar = null)
		{
			ShipmentIDType _StartingShipment = StartingShipment;
			ShipmentIDType _EndingShipment = EndingShipment;
			DateType _StartingDate = StartingDate;
			DateType _EndingDate = EndingDate;
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DelShipmentSp";
				
				appDB.AddCommandParameter(cmd, "StartingShipment", _StartingShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingShipment", _EndingShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
