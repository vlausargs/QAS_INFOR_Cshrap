//PROJECT NAME: Logistics
//CLASS NAME: CiGenP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CiGenP : ICiGenP
	{
		readonly IApplicationDB appDB;
		
		
		public CiGenP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CiGenPSp(string BeginCustomerNum,
		string EndCustomerNum,
		string InvFreq,
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
		string Infobar,
		string ProcessMode = null,
		Guid? SessionId = null)
		{
			CustNumType _BeginCustomerNum = BeginCustomerNum;
			CustNumType _EndCustomerNum = EndCustomerNum;
			StringType _InvFreq = InvFreq;
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
			InfobarType _Infobar = Infobar;
			StringType _ProcessMode = ProcessMode;
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CiGenPSp";
				
				appDB.AddCommandParameter(cmd, "BeginCustomerNum", _BeginCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomerNum", _EndCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvFreq", _InvFreq, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessMode", _ProcessMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
