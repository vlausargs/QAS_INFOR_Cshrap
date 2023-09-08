//PROJECT NAME: Logistics
//CLASS NAME: ValidateCOConsignValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateCOConsignValues : IValidateCOConsignValues
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateCOConsignValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ConsignableOrder,
		string Infobar) ValidateCOConsignValuesSp(string CustNum,
		int? CustSeq,
		string Whse,
		int? Consignment,
		string CoNum,
		int? ConsignableOrder,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			WhseType _Whse = Whse;
			ListYesNoType _Consignment = Consignment;
			CoNumType _CoNum = CoNum;
			ListYesNoType _ConsignableOrder = ConsignableOrder;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateCOConsignValuesSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Consignment", _Consignment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignableOrder", _ConsignableOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConsignableOrder = _ConsignableOrder;
				Infobar = _Infobar;
				
				return (Severity, ConsignableOrder, Infobar);
			}
		}
	}
}
