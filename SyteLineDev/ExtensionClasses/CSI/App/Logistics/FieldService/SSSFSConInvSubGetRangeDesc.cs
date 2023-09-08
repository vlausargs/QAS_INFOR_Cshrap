//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubGetRangeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubGetRangeDesc : ISSSFSConInvSubGetRangeDesc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubGetRangeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string OBillRange1,
			string OBillRange2) SSSFSConInvSubGetRangeDescSp(
			string IContPriceBasis,
			DateTime? IBillingStartDate,
			DateTime? IBillingEndDate,
			int? IBillingStartMeter,
			int? IBillingEndMeter,
			string OBillRange1,
			string OBillRange2)
		{
			FSContPriceBasisType _IContPriceBasis = IContPriceBasis;
			DateTimeType _IBillingStartDate = IBillingStartDate;
			DateTimeType _IBillingEndDate = IBillingEndDate;
			FSMeterAmtType _IBillingStartMeter = IBillingStartMeter;
			FSMeterAmtType _IBillingEndMeter = IBillingEndMeter;
			StringType _OBillRange1 = OBillRange1;
			StringType _OBillRange2 = OBillRange2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubGetRangeDescSp";
				
				appDB.AddCommandParameter(cmd, "IContPriceBasis", _IContPriceBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBillingStartDate", _IBillingStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBillingEndDate", _IBillingEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBillingStartMeter", _IBillingStartMeter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBillingEndMeter", _IBillingEndMeter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OBillRange1", _OBillRange1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OBillRange2", _OBillRange2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OBillRange1 = _OBillRange1;
				OBillRange2 = _OBillRange2;
				
				return (Severity, OBillRange1, OBillRange2);
			}
		}
	}
}
