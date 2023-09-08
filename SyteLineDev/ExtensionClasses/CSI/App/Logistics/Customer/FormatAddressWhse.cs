//PROJECT NAME: CSICustomer
//CLASS NAME: FormatAddressWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IFormatAddressWhse
	{
		int FormatAddressWhseSp(string CustNum,
		                        int? CustSeq,
		                        ref string BillToAddress,
		                        ref string ShipToAddress,
		                        ref string Whse,
		                        ref string Infobar);
	}
	
	public class FormatAddressWhse : IFormatAddressWhse
	{
		readonly IApplicationDB appDB;
		
		public FormatAddressWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FormatAddressWhseSp(string CustNum,
		                               int? CustSeq,
		                               ref string BillToAddress,
		                               ref string ShipToAddress,
		                               ref string Whse,
		                               ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			LongAddress _BillToAddress = BillToAddress;
			LongAddress _ShipToAddress = ShipToAddress;
			WhseType _Whse = Whse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatAddressWhseSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillToAddress = _BillToAddress;
				ShipToAddress = _ShipToAddress;
				Whse = _Whse;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
