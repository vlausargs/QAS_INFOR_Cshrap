//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROWipRelSubRelieveMisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROWipRelSubRelieveMisc : ISSSFSSROWipRelSubRelieveMisc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROWipRelSubRelieveMisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? MiscCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSFSSROWipRelSubRelieveMiscSp(
			string PSroNum,
			int? PSroLine,
			int? PSroOper,
			DateTime? PBegTransDate,
			DateTime? PEndTransDate,
			int? PInclBillHold,
			int? PMarkBilled,
			int? CurrencyPlaces,
			decimal? MiscCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar)
		{
			FSSRONumType _PSroNum = PSroNum;
			FSSROLineType _PSroLine = PSroLine;
			FSSROOperType _PSroOper = PSroOper;
			DateType _PBegTransDate = PBegTransDate;
			DateType _PEndTransDate = PEndTransDate;
			FlagNyType _PInclBillHold = PInclBillHold;
			FlagNyType _PMarkBilled = PMarkBilled;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			AmountType _MiscCost = MiscCost;
			AmountType _LbrCost = LbrCost;
			AmountType _FovCost = FovCost;
			AmountType _VovCost = VovCost;
			AmountType _OutCost = OutCost;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROWipRelSubRelieveMiscSp";
				
				appDB.AddCommandParameter(cmd, "PSroNum", _PSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroLine", _PSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSroOper", _PSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTransDate", _PBegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTransDate", _PEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclBillHold", _PInclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMarkBilled", _PMarkBilled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCost", _MiscCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovCost", _FovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovCost", _VovCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MiscCost = _MiscCost;
				LbrCost = _LbrCost;
				FovCost = _FovCost;
				VovCost = _VovCost;
				OutCost = _OutCost;
				Infobar = _Infobar;
				
				return (Severity, MiscCost, LbrCost, FovCost, VovCost, OutCost, Infobar);
			}
		}
	}
}
