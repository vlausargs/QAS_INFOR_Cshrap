//PROJECT NAME: Production
//CLASS NAME: ApsMatlIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMatlIns : IApsMatlIns
	{
		readonly IApplicationDB appDB;
		
		
		public ApsMatlIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsMatlInsSp(string MatlID,
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
		int? DerForecastBOMSupply)
		{
			ApsMaterialType _MatlID = MatlID;
			ApsDescriptType _Descr = Descr;
			ApsFloatType _QuOnHand = QuOnHand;
			ApsDurationType _FLeadTime = FLeadTime;
			ApsDurationType _VLeadTime = VLeadTime;
			ListYesNoType _DerExp = DerExp;
			ApsDurationType _FExplTime = FExplTime;
			ApsDurationType _VExplTime = VExplTime;
			ApsFloatType _OrdMin = OrdMin;
			ApsMultiplierType _OrdMult = OrdMult;
			ApsFloatType _OrdMax = OrdMax;
			ApsDescriptType _UnitMeas = UnitMeas;
			ApsMultiplierType _Shrink = Shrink;
			ApsSmallIntType _Prec = Prec;
			ApsSmallIntType _LowLevel = LowLevel;
			ListYesNoType _DerSupTol = DerSupTol;
			ApsFloatType _SupplyTol = SupplyTol;
			ApsSmallIntType _TfRule = TfRule;
			ApsFloatType _TfValue = TfValue;
			ApsShiftType _ShiftID = ShiftID;
			DateTimeType _ExpoDate = ExpoDate;
			ApsIntType _POTolIn = POTolIn;
			ApsIntType _POTolOut = POTolOut;
			ApsIntType _JobTolIn = JobTolIn;
			ApsIntType _JobTolOut = JobTolOut;
			ListYesNoType _DerPassMfg = DerPassMfg;
			ListYesNoType _DerPassPur = DerPassPur;
			ListYesNoType _DerAccReq = DerAccReq;
			ListYesNoType _DerAccReqNoEnd = DerAccReqNoEnd;
			ListYesNoType _DerUnconst = DerUnconst;
			ListYesNoType _DerUnresMfg = DerUnresMfg;
			ListYesNoType _DerMRP = DerMRP;
			ListYesNoType _DerMfgSS = DerMfgSS;
			ListYesNoType _DerReord = DerReord;
			ListYesNoType _DerTrans = DerTrans;
			ListYesNoType _DerPurchased = DerPurchased;
			ListYesNoType _DerMustUseFuturePOs = DerMustUseFuturePOs;
			ApsBitFlagsType _PrtFlags = PrtFlags;
			ApsAltNoType _AltNo = AltNo;
			ApsFloatType _MinCap = MinCap;
			ApsSmallIntType _PURule = PURule;
			ApsFloatType _PUValue = PUValue;
			ListYesNoType _DerChargeItem = DerChargeItem;
			ListYesNoType _DerForecastBOMSupply = DerForecastBOMSupply;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsMatlInsSp";
				
				appDB.AddCommandParameter(cmd, "MatlID", _MatlID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuOnHand", _QuOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FLeadTime", _FLeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VLeadTime", _VLeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerExp", _DerExp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FExplTime", _FExplTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VExplTime", _VExplTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdMin", _OrdMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdMult", _OrdMult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdMax", _OrdMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMeas", _UnitMeas, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shrink", _Shrink, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prec", _Prec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LowLevel", _LowLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerSupTol", _DerSupTol, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyTol", _SupplyTol, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TfRule", _TfRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TfValue", _TfValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiftID", _ShiftID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpoDate", _ExpoDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POTolIn", _POTolIn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POTolOut", _POTolOut, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTolIn", _JobTolIn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTolOut", _JobTolOut, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPassMfg", _DerPassMfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPassPur", _DerPassPur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerAccReq", _DerAccReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerAccReqNoEnd", _DerAccReqNoEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerUnconst", _DerUnconst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerUnresMfg", _DerUnresMfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerMRP", _DerMRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerMfgSS", _DerMfgSS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerReord", _DerReord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerTrans", _DerTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerPurchased", _DerPurchased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerMustUseFuturePOs", _DerMustUseFuturePOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtFlags", _PrtFlags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinCap", _MinCap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PURule", _PURule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUValue", _PUValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerChargeItem", _DerChargeItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerForecastBOMSupply", _DerForecastBOMSupply, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
