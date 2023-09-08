//PROJECT NAME: Finance
//CLASS NAME: SSSVTXTXWCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXTXWCalc : ISSSVTXTXWCalc
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXTXWCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) SSSVTXTXWCalcSp(
			string PInvType,
			DateTime? PInvDate,
			string PRefType,
			Guid? pHdrPtr,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar)
		{
			DefaultCharType _PInvType = PInvType;
			GenericDate _PInvDate = PInvDate;
			VTXRefTypeType _PRefType = PRefType;
			RowPointer _pHdrPtr = pHdrPtr;
			AmountType _PSalesTax1 = PSalesTax1;
			AmountType _PSalesTax2 = PSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSVTXTXWCalcSp";
				
				appDB.AddCommandParameter(cmd, "PInvType", _PInvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHdrPtr", _pHdrPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax1 = _PSalesTax1;
				PSalesTax2 = _PSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, PSalesTax1, PSalesTax2, Infobar);
			}
		}
	}
}
