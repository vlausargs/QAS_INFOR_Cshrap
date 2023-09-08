//PROJECT NAME: Logistics
//CLASS NAME: CLM_CiGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CLM_CiGen : ICLM_CiGen
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_CiGen(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_CiGenSp(string BeginCustomerNum,
		string EndCustomerNum,
		int? OtherInvFreq,
		int? DailyInvFreq,
		int? WeeklyInvFreq,
		int? BiMonthlyInvFreq,
		int? MonthlyInvFreq,
		int? HoldInvFreq,
		int? ProcessCustOrders,
		string BeginCONum,
		string EndCONum,
		int? ProcessDelOrders,
		string BeginDONum,
		string EndDONum,
		string BeginCustPONum,
		string EndCustPONum,
		int? GenerateByShipDate,
		DateTime? ShipDate,
		int? ProcessShipments,
		decimal? BeginShipment,
		decimal? EndShipment,
		Guid? SessionId,
		string Infobar)
		{
			CustNumType _BeginCustomerNum = BeginCustomerNum;
			CustNumType _EndCustomerNum = EndCustomerNum;
			ListYesNoType _OtherInvFreq = OtherInvFreq;
			ListYesNoType _DailyInvFreq = DailyInvFreq;
			ListYesNoType _WeeklyInvFreq = WeeklyInvFreq;
			ListYesNoType _BiMonthlyInvFreq = BiMonthlyInvFreq;
			ListYesNoType _MonthlyInvFreq = MonthlyInvFreq;
			ListYesNoType _HoldInvFreq = HoldInvFreq;
			ListYesNoType _ProcessCustOrders = ProcessCustOrders;
			CoNumType _BeginCONum = BeginCONum;
			CoNumType _EndCONum = EndCONum;
			ListYesNoType _ProcessDelOrders = ProcessDelOrders;
			DoNumType _BeginDONum = BeginDONum;
			DoNumType _EndDONum = EndDONum;
			CustPoType _BeginCustPONum = BeginCustPONum;
			CustPoType _EndCustPONum = EndCustPONum;
			ListYesNoType _GenerateByShipDate = GenerateByShipDate;
			GenericDateType _ShipDate = ShipDate;
			ListYesNoType _ProcessShipments = ProcessShipments;
			ShipmentIDType _BeginShipment = BeginShipment;
			ShipmentIDType _EndShipment = EndShipment;
			RowPointerType _SessionId = SessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_CiGenSp";
				
				appDB.AddCommandParameter(cmd, "BeginCustomerNum", _BeginCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomerNum", _EndCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OtherInvFreq", _OtherInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DailyInvFreq", _DailyInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WeeklyInvFreq", _WeeklyInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BiMonthlyInvFreq", _BiMonthlyInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MonthlyInvFreq", _MonthlyInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldInvFreq", _HoldInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessCustOrders", _ProcessCustOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCONum", _BeginCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCONum", _EndCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessDelOrders", _ProcessDelOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginDONum", _BeginDONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDONum", _EndDONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCustPONum", _BeginCustPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustPONum", _EndCustPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateByShipDate", _GenerateByShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipDate", _ShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessShipments", _ProcessShipments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginShipment", _BeginShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipment", _EndShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
