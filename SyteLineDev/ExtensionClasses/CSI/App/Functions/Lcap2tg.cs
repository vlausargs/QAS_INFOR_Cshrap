//PROJECT NAME: Data
//CLASS NAME: Lcap2tg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Lcap2tg : ILcap2tg
	{
		readonly IApplicationDB appDB;
		
		public Lcap2tg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TSalesTax1,
			decimal? TSalesTax2,
			string Infobar) Lcap2tgSp(
			string PoNum,
			string VendNum,
			decimal? TmpFreightSum,
			decimal? TmpBrokerageSum,
			decimal? TmpDutySum,
			decimal? TmpLocFrtSum,
			decimal? TmpInsuranceSum,
			DateTime? InvoiceDate,
			int? PAskFlag,
			decimal? TSalesTax1,
			decimal? TSalesTax2,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			VendNumType _VendNum = VendNum;
			AmountType _TmpFreightSum = TmpFreightSum;
			AmountType _TmpBrokerageSum = TmpBrokerageSum;
			AmountType _TmpDutySum = TmpDutySum;
			AmountType _TmpLocFrtSum = TmpLocFrtSum;
			AmountType _TmpInsuranceSum = TmpInsuranceSum;
			GenericDateType _InvoiceDate = InvoiceDate;
			FlagNyType _PAskFlag = PAskFlag;
			AmountType _TSalesTax1 = TSalesTax1;
			AmountType _TSalesTax2 = TSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Lcap2tgSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpFreightSum", _TmpFreightSum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpBrokerageSum", _TmpBrokerageSum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpDutySum", _TmpDutySum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpLocFrtSum", _TmpLocFrtSum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpInsuranceSum", _TmpInsuranceSum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAskFlag", _PAskFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSalesTax1", _TSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSalesTax2", _TSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSalesTax1 = _TSalesTax1;
				TSalesTax2 = _TSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, TSalesTax1, TSalesTax2, Infobar);
			}
		}
	}
}
