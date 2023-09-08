//PROJECT NAME: Data
//CLASS NAME: CommCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CommCalc : ICommCalc
	{
		readonly IApplicationDB appDB;
		
		public CommCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TCommBaseTot,
			decimal? TCommCalc,
			decimal? TCommBase,
			string Infobar) CommCalcSp(
			string TMode,
			string TInvNum,
			string TCoNum,
			string TCurSlsman,
			string TCurrCode,
			int? TPlaces,
			decimal? TExchRate,
			decimal? TRevPercent,
			decimal? TCommPercent,
			int? TCoLine,
			Guid? TInvItemRecid,
			decimal? TCommBaseTot,
			decimal? TCommCalc,
			decimal? TCommBase,
			string Infobar,
			string ParmsSite = null,
			int? CreateFromPackSlip = 0)
		{
			LongListType _TMode = TMode;
			InvNumType _TInvNum = TInvNum;
			CoNumType _TCoNum = TCoNum;
			SlsmanType _TCurSlsman = TCurSlsman;
			CurrCodeType _TCurrCode = TCurrCode;
			DecimalPlacesType _TPlaces = TPlaces;
			ExchRateType _TExchRate = TExchRate;
			CommPercentType _TRevPercent = TRevPercent;
			CommPercentType _TCommPercent = TCommPercent;
			CoLineType _TCoLine = TCoLine;
			RowPointerType _TInvItemRecid = TInvItemRecid;
			AmountType _TCommBaseTot = TCommBaseTot;
			AmountType _TCommCalc = TCommCalc;
			AmountType _TCommBase = TCommBase;
			InfobarType _Infobar = Infobar;
			SiteType _ParmsSite = ParmsSite;
			ListYesNoType _CreateFromPackSlip = CreateFromPackSlip;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CommCalcSp";
				
				appDB.AddCommandParameter(cmd, "TMode", _TMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoNum", _TCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurSlsman", _TCurSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurrCode", _TCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPlaces", _TPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExchRate", _TExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRevPercent", _TRevPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCommPercent", _TCommPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoLine", _TCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvItemRecid", _TInvItemRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCommBaseTot", _TCommBaseTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCommCalc", _TCommCalc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCommBase", _TCommBase, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateFromPackSlip", _CreateFromPackSlip, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TCommBaseTot = _TCommBaseTot;
				TCommCalc = _TCommCalc;
				TCommBase = _TCommBase;
				Infobar = _Infobar;
				
				return (Severity, TCommBaseTot, TCommCalc, TCommBase, Infobar);
			}
		}
	}
}
