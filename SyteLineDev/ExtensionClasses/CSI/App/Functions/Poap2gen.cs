//PROJECT NAME: Data
//CLASS NAME: Poap2gen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Poap2gen : IPoap2gen
	{
		readonly IApplicationDB appDB;
		
		public Poap2gen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TDistSeq,
			string Infobar) Poap2genSp(
			int? PSign,
			Guid? AptrxRowPointer,
			string PVendCurrCode,
			int? PCurrPlaces,
			decimal? PFreight,
			decimal? PMiscCharges,
			decimal? PSalesTax,
			decimal? PSalesTax2,
			string PFormTitle,
			string CalledFrom,
			Guid? PProcessId,
			int? TDistSeq,
			string Infobar)
		{
			GenericNoType _PSign = PSign;
			RowPointerType _AptrxRowPointer = AptrxRowPointer;
			CurrCodeType _PVendCurrCode = PVendCurrCode;
			DecimalPlacesType _PCurrPlaces = PCurrPlaces;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			InfobarType _PFormTitle = PFormTitle;
			StringType _CalledFrom = CalledFrom;
			RowPointerType _PProcessId = PProcessId;
			GenericNoType _TDistSeq = TDistSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Poap2genSp";
				
				appDB.AddCommandParameter(cmd, "PSign", _PSign, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxRowPointer", _AptrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendCurrCode", _PVendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrPlaces", _PCurrPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFormTitle", _PFormTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
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
