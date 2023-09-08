//PROJECT NAME: Material
//CLASS NAME: GetPurchasingParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetPurchasingParms : IGetPurchasingParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetPurchasingParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance) GetPurchasingParmsSp(decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PSite = null)
		{
			TolerancePercentType _POToleranceOver = POToleranceOver;
			TolerancePercentType _POToleranceUnder = POToleranceUnder;
			ListYesNoType _Vchrauthorize = Vchrauthorize;
			TolerancePercentType _VchrOverPoCostTolerance = VchrOverPoCostTolerance;
			TolerancePercentType _VchrUnderPoCostTolerance = VchrUnderPoCostTolerance;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPurchasingParmsSp";
				
				appDB.AddCommandParameter(cmd, "POToleranceOver", _POToleranceOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceUnder", _POToleranceUnder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vchrauthorize", _Vchrauthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrOverPoCostTolerance", _VchrOverPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrUnderPoCostTolerance", _VchrUnderPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POToleranceOver = _POToleranceOver;
				POToleranceUnder = _POToleranceUnder;
				Vchrauthorize = _Vchrauthorize;
				VchrOverPoCostTolerance = _VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = _VchrUnderPoCostTolerance;
				
				return (Severity, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance);
			}
		}
	}
}
