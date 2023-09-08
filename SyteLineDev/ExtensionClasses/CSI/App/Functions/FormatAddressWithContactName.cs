//PROJECT NAME: Data
//CLASS NAME: FormatAddressWithContactName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatAddressWithContactName : IFormatAddressWithContactName
	{
		readonly IApplicationDB appDB;
		
		public FormatAddressWithContactName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string BillToAddress,
			string ShipToAddress,
			string Infobar) FormatAddressWithContactNameSp(
			string CustNum,
			int? CustSeq,
			string BillToAddress,
			string ShipToAddress,
			string Infobar,
			string Contact = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			LongAddress _BillToAddress = BillToAddress;
			LongAddress _ShipToAddress = ShipToAddress;
			Infobar _Infobar = Infobar;
			ContactType _Contact = Contact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatAddressWithContactNameSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillToAddress = _BillToAddress;
				ShipToAddress = _ShipToAddress;
				Infobar = _Infobar;
				
				return (Severity, BillToAddress, ShipToAddress, Infobar);
			}
		}
	}
}
