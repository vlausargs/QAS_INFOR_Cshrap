//PROJECT NAME: Data
//CLASS NAME: SumCol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SumCol : ISumCol
	{
		readonly IApplicationDB appDB;
		
		public SumCol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PNetAmt,
			decimal? PAmtDisc,
			decimal? PAmtPrepaid,
			decimal? PAmtMiscCharges,
			decimal? PAmtSalesTax,
			decimal? PAmtSalesTax2,
			decimal? PAmtFreight,
			decimal? PAmtTotal) SumColSp(
			string PTable,
			string PSite,
			string PCoNum,
			int? PCalcTax,
			decimal? PNetAmt,
			decimal? PAmtDisc,
			decimal? PAmtPrepaid,
			decimal? PAmtMiscCharges,
			decimal? PAmtSalesTax,
			decimal? PAmtSalesTax2,
			decimal? PAmtFreight,
			decimal? PAmtTotal)
		{
			StringType _PTable = PTable;
			SiteType _PSite = PSite;
			CoNumType _PCoNum = PCoNum;
			FlagNyType _PCalcTax = PCalcTax;
			AmountType _PNetAmt = PNetAmt;
			AmountType _PAmtDisc = PAmtDisc;
			AmountType _PAmtPrepaid = PAmtPrepaid;
			AmountType _PAmtMiscCharges = PAmtMiscCharges;
			AmountType _PAmtSalesTax = PAmtSalesTax;
			AmountType _PAmtSalesTax2 = PAmtSalesTax2;
			AmountType _PAmtFreight = PAmtFreight;
			AmountType _PAmtTotal = PAmtTotal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumColSp";
				
				appDB.AddCommandParameter(cmd, "PTable", _PTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCalcTax", _PCalcTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNetAmt", _PNetAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtDisc", _PAmtDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtPrepaid", _PAmtPrepaid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtMiscCharges", _PAmtMiscCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtSalesTax", _PAmtSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtSalesTax2", _PAmtSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtFreight", _PAmtFreight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtTotal", _PAmtTotal, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNetAmt = _PNetAmt;
				PAmtDisc = _PAmtDisc;
				PAmtPrepaid = _PAmtPrepaid;
				PAmtMiscCharges = _PAmtMiscCharges;
				PAmtSalesTax = _PAmtSalesTax;
				PAmtSalesTax2 = _PAmtSalesTax2;
				PAmtFreight = _PAmtFreight;
				PAmtTotal = _PAmtTotal;
				
				return (Severity, PNetAmt, PAmtDisc, PAmtPrepaid, PAmtMiscCharges, PAmtSalesTax, PAmtSalesTax2, PAmtFreight, PAmtTotal);
			}
		}
	}
}
