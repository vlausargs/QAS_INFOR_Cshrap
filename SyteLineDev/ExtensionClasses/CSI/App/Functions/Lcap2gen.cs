//PROJECT NAME: Data
//CLASS NAME: Lcap2gen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Lcap2gen : ILcap2gen
	{
		readonly IApplicationDB appDB;
		
		public Lcap2gen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TDistSeq,
			string Infobar) Lcap2genSp(
			int? PSign,
			Guid? AptrxRowPointer,
			string TVendNum,
			decimal? TAmtDuty,
			decimal? TAmtFreight,
			decimal? TAmtBrokerage,
			decimal? TAmtLocFreight,
			decimal? TAmtInsurance,
			int? TDistSeq,
			string Infobar)
		{
			GenericNoType _PSign = PSign;
			RowPointerType _AptrxRowPointer = AptrxRowPointer;
			VendNumType _TVendNum = TVendNum;
			AmountType _TAmtDuty = TAmtDuty;
			AmountType _TAmtFreight = TAmtFreight;
			AmountType _TAmtBrokerage = TAmtBrokerage;
			AmountType _TAmtLocFreight = TAmtLocFreight;
			AmountType _TAmtInsurance = TAmtInsurance;
			GenericNoType _TDistSeq = TDistSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Lcap2genSp";
				
				appDB.AddCommandParameter(cmd, "PSign", _PSign, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxRowPointer", _AptrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVendNum", _TVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAmtDuty", _TAmtDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAmtFreight", _TAmtFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAmtBrokerage", _TAmtBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAmtLocFreight", _TAmtLocFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAmtInsurance", _TAmtInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDistSeq", _TDistSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDistSeq = _TDistSeq;
				Infobar = _Infobar;
				
				return (Severity, TDistSeq, Infobar);
			}
		}
	}
}
