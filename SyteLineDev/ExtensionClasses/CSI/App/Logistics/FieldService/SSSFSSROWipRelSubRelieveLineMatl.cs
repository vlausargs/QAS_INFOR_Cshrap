//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROWipRelSubRelieveLineMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROWipRelSubRelieveLineMatl : ISSSFSSROWipRelSubRelieveLineMatl
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROWipRelSubRelieveLineMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSFSSROWipRelSubRelieveLineMatlSp(
			string PSroNum,
			int? PSroLine,
			DateTime? PBegTransDate,
			DateTime? PEndTransDate,
			int? PInclBillHold,
			int? PMarkBilled,
			int? CurrencyPlaces,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar)
		{
			FSSRONumType _PSroNum = PSroNum;
			FSSROLineType _PSroLine = PSroLine;
			DateType _PBegTransDate = PBegTransDate;
			DateType _PEndTransDate = PEndTransDate;
			FlagNyType _PInclBillHold = PInclBillHold;
			FlagNyType _PMarkBilled = PMarkBilled;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			AmountType _MatlCost = MatlCost;
			AmountType _LbrCost = LbrCost;
			AmountType _FovCost = FovCost;
			AmountType _VovCost = VovCost;
			AmountType _OutCost = OutCost;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROWipRelSubRelieveLineMatlSp";
				
				appDB.AddCommandParameter(cmd, "PSroNum", _PSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroLine", _PSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTransDate", _PBegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTransDate", _PEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclBillHold", _PInclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMarkBilled", _PMarkBilled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovCost", _FovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovCost", _VovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovCost = _FovCost;
				VovCost = _VovCost;
				OutCost = _OutCost;
				Infobar = _Infobar;
				
				return (Severity, MatlCost, LbrCost, FovCost, VovCost, OutCost, Infobar);
			}
		}
	}
}
