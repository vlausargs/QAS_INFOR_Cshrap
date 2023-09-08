//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateInternationalOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IValidateInternationalOrder
	{
		int ValidateInternationalOrderSp(string CoNum,
		                                 string PaymentMethod,
		                                 string ShipMethod,
		                                 ref string Infobar);
	}
	
	public class ValidateInternationalOrder : IValidateInternationalOrder
	{
		readonly IApplicationDB appDB;
		
		public ValidateInternationalOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateInternationalOrderSp(string CoNum,
		                                        string PaymentMethod,
		                                        string ShipMethod,
		                                        ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			PaymentMethodType _PaymentMethod = PaymentMethod;
			ShipMethodType _ShipMethod = ShipMethod;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInternationalOrderSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentMethod", _PaymentMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipMethod", _ShipMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
