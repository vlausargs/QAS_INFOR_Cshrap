//PROJECT NAME: Data
//CLASS NAME: InvPostP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvPostP : IInvPostP
	{
		readonly IApplicationDB appDB;
		
		public InvPostP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TInvNum,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			int? InvoiceCount,
			int? EDINoPaperInvoiceCount) InvPostPSp(
			string InvCred = "I",
			DateTime? InvDate = null,
			string StartCustomer = null,
			string EndCustomer = null,
			string StartOrderNum = null,
			string EndOrderNum = null,
			int? StartLine = null,
			int? EndLine = null,
			int? StartRelease = null,
			int? EndRelease = null,
			string pMooreForms = "N",
			string TInvNum = "0",
			string StartInvNum = null,
			string EndInvNum = null,
			string Infobar = null,
			Guid? ProcessId = null,
			int? InvoiceCount = 0,
			int? EDINoPaperInvoiceCount = 0,
			string CalledFrom = null,
			Guid? InvoicBuilderProcessID = null)
		{
			StringType _InvCred = InvCred;
			DateType _InvDate = InvDate;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			CoLineType _StartLine = StartLine;
			CoLineType _EndLine = EndLine;
			CoReleaseType _StartRelease = StartRelease;
			CoReleaseType _EndRelease = EndRelease;
			StringType _pMooreForms = pMooreForms;
			InvNumType _TInvNum = TInvNum;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			InfobarType _Infobar = Infobar;
			RowPointerType _ProcessId = ProcessId;
			IntType _InvoiceCount = InvoiceCount;
			IntType _EDINoPaperInvoiceCount = EDINoPaperInvoiceCount;
			InfobarType _CalledFrom = CalledFrom;
			RowPointerType _InvoicBuilderProcessID = InvoicBuilderProcessID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostPSp";
				
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMooreForms", _pMooreForms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceCount", _InvoiceCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EDINoPaperInvoiceCount", _EDINoPaperInvoiceCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoicBuilderProcessID", _InvoicBuilderProcessID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TInvNum = _TInvNum;
				StartInvNum = _StartInvNum;
				EndInvNum = _EndInvNum;
				Infobar = _Infobar;
				InvoiceCount = _InvoiceCount;
				EDINoPaperInvoiceCount = _EDINoPaperInvoiceCount;
				
				return (Severity, TInvNum, StartInvNum, EndInvNum, Infobar, InvoiceCount, EDINoPaperInvoiceCount);
			}
		}
	}
}
