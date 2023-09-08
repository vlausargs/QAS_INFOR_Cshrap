//PROJECT NAME: Data
//CLASS NAME: LcapGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LcapGen : ILcapGen
	{
		readonly IApplicationDB appDB;
		
		public LcapGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LcapGenSp(
			Guid? ProcessId,
			string VendNum,
			DateTime? InvoiceDate,
			DateTime? GLDistDate,
			string VendorInvoice,
			decimal? AmtDuty,
			decimal? AmtFreight,
			decimal? AmtBrokerage,
			decimal? AmtInsurance,
			decimal? AmtLocFreight,
			string CurPoNum,
			string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			VendNumType _VendNum = VendNum;
			GenericDateType _InvoiceDate = InvoiceDate;
			GenericDateType _GLDistDate = GLDistDate;
			VendInvNumType _VendorInvoice = VendorInvoice;
			AmountType _AmtDuty = AmtDuty;
			AmountType _AmtFreight = AmtFreight;
			AmountType _AmtBrokerage = AmtBrokerage;
			AmountType _AmtInsurance = AmtInsurance;
			AmountType _AmtLocFreight = AmtLocFreight;
			PoTrnNumType _CurPoNum = CurPoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LcapGenSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLDistDate", _GLDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorInvoice", _VendorInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtDuty", _AmtDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtFreight", _AmtFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtBrokerage", _AmtBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtInsurance", _AmtInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtLocFreight", _AmtLocFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurPoNum", _CurPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
