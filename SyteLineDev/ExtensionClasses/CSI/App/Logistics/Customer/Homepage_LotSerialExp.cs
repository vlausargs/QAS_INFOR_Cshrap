//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_LotSerialExp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_LotSerialExp
	{
		(int? ReturnCode, int? SerialCount, decimal? SerialValue, int? LotCount, decimal? LotValue) Homepage_LotSerialExpSp(DateTime? Date,
		string DateType = "D",
		int? SerialCount = null,
		decimal? SerialValue = null,
		int? LotCount = null,
		decimal? LotValue = null);
	}
	
	public class Homepage_LotSerialExp : IHomepage_LotSerialExp
	{
		readonly IApplicationDB appDB;
		
		public Homepage_LotSerialExp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerialCount, decimal? SerialValue, int? LotCount, decimal? LotValue) Homepage_LotSerialExpSp(DateTime? Date,
		string DateType = "D",
		int? SerialCount = null,
		decimal? SerialValue = null,
		int? LotCount = null,
		decimal? LotValue = null)
		{
			DateType _Date = Date;
			StringType _DateType = DateType;
			IntType _SerialCount = SerialCount;
			AmtTotType _SerialValue = SerialValue;
			IntType _LotCount = LotCount;
			AmtTotType _LotValue = LotValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_LotSerialExpSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialCount", _SerialCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialValue", _SerialValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotCount", _LotCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotValue", _LotValue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerialCount = _SerialCount;
				SerialValue = _SerialValue;
				LotCount = _LotCount;
				LotValue = _LotValue;
				
				return (Severity, SerialCount, SerialValue, LotCount, LotValue);
			}
		}
	}
}
