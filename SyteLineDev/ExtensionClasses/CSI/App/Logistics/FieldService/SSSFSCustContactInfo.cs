//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCustContactInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSCustContactInfo : ISSSFSCustContactInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCustContactInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Phone,
			string FaxNum,
			string Email,
			string Infobar) SSSFSCustContactInfoSp(
			string CustNum,
			int? CustSeq,
			string Name,
			string Phone,
			string FaxNum,
			string Email,
			string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			NameType _Name = Name;
			PhoneType _Phone = Phone;
			PhoneType _FaxNum = FaxNum;
			EmailType _Email = Email;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCustContactInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Phone = _Phone;
				FaxNum = _FaxNum;
				Email = _Email;
				Infobar = _Infobar;
				
				return (Severity, Phone, FaxNum, Email, Infobar);
			}
		}
	}
}
