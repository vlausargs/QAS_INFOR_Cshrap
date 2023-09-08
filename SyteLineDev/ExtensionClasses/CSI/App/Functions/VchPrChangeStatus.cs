//PROJECT NAME: Data
//CLASS NAME: VchPrChangeStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VchPrChangeStatus : IVchPrChangeStatus
	{
		readonly IApplicationDB appDB;
		
		public VchPrChangeStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) VchPrChangeStatusSp(
			Guid? RowPointer,
			int? PreRegister,
			string Stat,
			DateTime? Date,
			DateTime? VchDate,
			string VendNum,
			decimal? MatlCost,
			decimal? Freight,
			decimal? MiscCharges,
			decimal? SalesTax,
			decimal? SalesTax_2,
			decimal? ExchRate,
			string SuspenseAcct,
			string SuspenseAcctUnit1,
			string SuspenseAcctUnit2,
			string SuspenseAcctUnit3,
			string SuspenseAcctUnit4,
			string UnmatchedAcct,
			string UnmatchedAcctUnit1,
			string UnmatchedAcctUnit2,
			string UnmatchedAcctUnit3,
			string UnmatchedAcctUnit4,
			string FreightAcct,
			string FreightAcctUnit1,
			string FreightAcctUnit2,
			string FreightAcctUnit3,
			string FreightAcctUnit4,
			string MiscAcct,
			string MiscAcctUnit1,
			string MiscAcctUnit2,
			string MiscAcctUnit3,
			string MiscAcctUnit4,
			string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			PreRegisterType _PreRegister = PreRegister;
			VchPrStatusType _Stat = Stat;
			Date4Type _Date = Date;
			Date4Type _VchDate = VchDate;
			VendNumType _VendNum = VendNum;
			AmountType _MatlCost = MatlCost;
			AmountType _Freight = Freight;
			AmountType _MiscCharges = MiscCharges;
			AmountType _SalesTax = SalesTax;
			AmountType _SalesTax_2 = SalesTax_2;
			ExchRateType _ExchRate = ExchRate;
			AcctType _SuspenseAcct = SuspenseAcct;
			UnitCode1Type _SuspenseAcctUnit1 = SuspenseAcctUnit1;
			UnitCode2Type _SuspenseAcctUnit2 = SuspenseAcctUnit2;
			UnitCode3Type _SuspenseAcctUnit3 = SuspenseAcctUnit3;
			UnitCode4Type _SuspenseAcctUnit4 = SuspenseAcctUnit4;
			AcctType _UnmatchedAcct = UnmatchedAcct;
			UnitCode1Type _UnmatchedAcctUnit1 = UnmatchedAcctUnit1;
			UnitCode2Type _UnmatchedAcctUnit2 = UnmatchedAcctUnit2;
			UnitCode3Type _UnmatchedAcctUnit3 = UnmatchedAcctUnit3;
			UnitCode4Type _UnmatchedAcctUnit4 = UnmatchedAcctUnit4;
			AcctType _FreightAcct = FreightAcct;
			UnitCode1Type _FreightAcctUnit1 = FreightAcctUnit1;
			UnitCode2Type _FreightAcctUnit2 = FreightAcctUnit2;
			UnitCode3Type _FreightAcctUnit3 = FreightAcctUnit3;
			UnitCode4Type _FreightAcctUnit4 = FreightAcctUnit4;
			AcctType _MiscAcct = MiscAcct;
			UnitCode1Type _MiscAcctUnit1 = MiscAcctUnit1;
			UnitCode2Type _MiscAcctUnit2 = MiscAcctUnit2;
			UnitCode3Type _MiscAcctUnit3 = MiscAcctUnit3;
			UnitCode4Type _MiscAcctUnit4 = MiscAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VchPrChangeStatusSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreRegister", _PreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchDate", _VchDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax_2", _SalesTax_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuspenseAcct", _SuspenseAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit1", _SuspenseAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit2", _SuspenseAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit3", _SuspenseAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuspenseAcctUnit4", _SuspenseAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnmatchedAcct", _UnmatchedAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnmatchedAcctUnit1", _UnmatchedAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnmatchedAcctUnit2", _UnmatchedAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnmatchedAcctUnit3", _UnmatchedAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnmatchedAcctUnit4", _UnmatchedAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAcct", _FreightAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit1", _FreightAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit2", _FreightAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit3", _FreightAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightAcctUnit4", _FreightAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscAcct", _MiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit1", _MiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit2", _MiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit3", _MiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscAcctUnit4", _MiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
