//PROJECT NAME: Logistics
//CLASS NAME: CiDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CiDel : ICiDel
	{
		readonly IApplicationDB appDB;
		
		public CiDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CiDelSp(
			string BeginCustomerNum,
			string EndCustomerNum,
			int? ProcessCustOrders,
			string BeginCONum,
			string EndCONum,
			int? ProcessDelOrders,
			string BeginDONum,
			string EndDONum,
			string BeginCustPONum,
			string EndCustPONum,
			int? ProcessShipments,
			decimal? BeginShipment,
			decimal? EndShipment,
			string Infobar)
		{
			CustNumType _BeginCustomerNum = BeginCustomerNum;
			CustNumType _EndCustomerNum = EndCustomerNum;
			ListYesNoType _ProcessCustOrders = ProcessCustOrders;
			CoNumType _BeginCONum = BeginCONum;
			CoNumType _EndCONum = EndCONum;
			ListYesNoType _ProcessDelOrders = ProcessDelOrders;
			DoNumType _BeginDONum = BeginDONum;
			DoNumType _EndDONum = EndDONum;
			CustPoType _BeginCustPONum = BeginCustPONum;
			CustPoType _EndCustPONum = EndCustPONum;
			ListYesNoType _ProcessShipments = ProcessShipments;
			ShipmentIDType _BeginShipment = BeginShipment;
			ShipmentIDType _EndShipment = EndShipment;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CiDelSp";
				
				appDB.AddCommandParameter(cmd, "BeginCustomerNum", _BeginCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomerNum", _EndCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessCustOrders", _ProcessCustOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCONum", _BeginCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCONum", _EndCONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessDelOrders", _ProcessDelOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginDONum", _BeginDONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDONum", _EndDONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCustPONum", _BeginCustPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustPONum", _EndCustPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessShipments", _ProcessShipments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginShipment", _BeginShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipment", _EndShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
