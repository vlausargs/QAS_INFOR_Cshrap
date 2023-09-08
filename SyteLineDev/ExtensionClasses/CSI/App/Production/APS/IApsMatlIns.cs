//PROJECT NAME: Production
//CLASS NAME: IApsMatlIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMatlIns
	{
		int? ApsMatlInsSp(string MatlID,
		string Descr,
		decimal? QuOnHand,
		decimal? FLeadTime,
		decimal? VLeadTime,
		int? DerExp,
		decimal? FExplTime,
		decimal? VExplTime,
		decimal? OrdMin,
		decimal? OrdMult,
		decimal? OrdMax,
		string UnitMeas,
		decimal? Shrink,
		int? Prec,
		int? LowLevel,
		int? DerSupTol,
		decimal? SupplyTol,
		int? TfRule,
		decimal? TfValue,
		string ShiftID,
		DateTime? ExpoDate,
		int? POTolIn,
		int? POTolOut,
		int? JobTolIn,
		int? JobTolOut,
		int? DerPassMfg,
		int? DerPassPur,
		int? DerAccReq,
		int? DerAccReqNoEnd,
		int? DerUnconst,
		int? DerUnresMfg,
		int? DerMRP,
		int? DerMfgSS,
		int? DerReord,
		int? DerTrans,
		int? DerPurchased,
		int? DerMustUseFuturePOs,
		int? PrtFlags,
		int? AltNo,
		decimal? MinCap,
		int? PURule,
		decimal? PUValue,
		int? DerChargeItem,
		int? DerForecastBOMSupply);
	}
}

