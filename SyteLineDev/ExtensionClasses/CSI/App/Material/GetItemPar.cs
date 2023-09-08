//PROJECT NAME: Material
//CLASS NAME: GetItemPar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetItemPar : IGetItemPar
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemPar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string Infobar) GetItemParSp(string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string Infobar,
		string PSite = null)
		{
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			ListYesNoType _TrackTaxFreeimports = TrackTaxFreeimports;
			UserCodeType _RUserCode = RUserCode;
			TolerancePercentType _POToleranceOver = POToleranceOver;
			TolerancePercentType _POToleranceUnder = POToleranceUnder;
			ListYesNoType _Vchrauthorize = Vchrauthorize;
			TolerancePercentType _VchrOverPoCostTolerance = VchrOverPoCostTolerance;
			TolerancePercentType _VchrUnderPoCostTolerance = VchrUnderPoCostTolerance;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemParSp";
				
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrackTaxFreeimports", _TrackTaxFreeimports, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RUserCode", _RUserCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceOver", _POToleranceOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceUnder", _POToleranceUnder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vchrauthorize", _Vchrauthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrOverPoCostTolerance", _VchrOverPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrUnderPoCostTolerance", _VchrUnderPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ApsParmApsmode = _ApsParmApsmode;
				TrackTaxFreeimports = _TrackTaxFreeimports;
				RUserCode = _RUserCode;
				POToleranceOver = _POToleranceOver;
				POToleranceUnder = _POToleranceUnder;
				Vchrauthorize = _Vchrauthorize;
				VchrOverPoCostTolerance = _VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = _VchrUnderPoCostTolerance;
				Infobar = _Infobar;
				
				return (Severity, ApsParmApsmode, TrackTaxFreeimports, RUserCode, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, Infobar);
			}
		}
	}
}
