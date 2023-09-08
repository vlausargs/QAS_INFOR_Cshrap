//PROJECT NAME: Logistics
//CLASS NAME: MobileSROCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class MobileSROCreate : IMobileSROCreate
	{
		readonly IApplicationDB appDB;
		
		
		public MobileSROCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MobileSROCreateSp(Guid? RowPointer,
		string Description = null,
		string CustNum = null,
		int? CustSeq = null,
		string PartnerId = null,
		string Contact = null,
		string Email = null,
		string Phone = null,
		string SroStat = null,
		string StatCode = null,
		string PriorCode = null,
		string BillCode = null,
		string BillType = null,
		DateTime? OpenDate = null,
		DateTime? CloseDate = null,
		string Infobar = null)
		{
			RowPointerType _RowPointer = RowPointer;
			DescriptionType _Description = Description;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSPartnerType _PartnerId = PartnerId;
			NameType _Contact = Contact;
			EmailType _Email = Email;
			PhoneType _Phone = Phone;
			FSSROStatType _SroStat = SroStat;
			FSStatCodeType _StatCode = StatCode;
			FSIncPriorCodeType _PriorCode = PriorCode;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROBillTypeType _BillType = BillType;
			DateType _OpenDate = OpenDate;
			DateType _CloseDate = CloseDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MobileSROCreateSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroStat", _SroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCode", _StatCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpenDate", _OpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CloseDate", _CloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
