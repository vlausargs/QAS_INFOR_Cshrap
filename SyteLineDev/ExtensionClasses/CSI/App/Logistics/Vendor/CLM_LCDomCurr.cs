//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_LCDomCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_LCDomCurr
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LCDomCurrSp(string CurrCode1,
		byte? UseBuyRate = (byte)0,
		decimal? TRate1 = null,
		DateTime? PossibleDate = null,
		decimal? V1Amount1 = null,
		decimal? V1Amount2 = null,
		decimal? V1Amount3 = null,
		decimal? V1Amount4 = null,
		decimal? V1Amount5 = null,
		string CurrCode2 = null,
		decimal? TRate2 = null,
		decimal? V2Amount1 = null,
		decimal? V2Amount2 = null,
		decimal? V2Amount3 = null,
		decimal? V2Amount4 = null,
		decimal? V2Amount5 = null,
		string CurrCode3 = null,
		decimal? TRate3 = null,
		decimal? V3Amount1 = null,
		decimal? V3Amount2 = null,
		decimal? V3Amount3 = null,
		decimal? V3Amount4 = null,
		decimal? V3Amount5 = null,
		string CurrCode4 = null,
		decimal? TRate4 = null,
		decimal? V4Amount1 = null,
		decimal? V4Amount2 = null,
		decimal? V4Amount3 = null,
		decimal? V4Amount4 = null,
		decimal? V4Amount5 = null,
		decimal? V4Amount6 = null,
		decimal? V4Amount7 = null,
		decimal? V4Amount8 = null,
		decimal? V4Amount9 = null,
		decimal? V4Amount10 = null,
		decimal? V4Amount11 = null,
		string CurrCode5 = null,
		decimal? TRate5 = null,
		decimal? V5Amount1 = null,
		decimal? V5Amount2 = null,
		decimal? V5Amount3 = null,
		decimal? V5Amount4 = null,
		decimal? V5Amount5 = null,
		string CurrCode6 = null,
		decimal? TRate6 = null,
		decimal? V6Amount1 = null,
		decimal? V6Amount2 = null,
		decimal? V6Amount3 = null,
		decimal? V6Amount4 = null,
		decimal? V6Amount5 = null,
		string PoNum = null,
		string GrnNum = null);
	}
	
	public class CLM_LCDomCurr : ICLM_LCDomCurr
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_LCDomCurr(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_LCDomCurrSp(string CurrCode1,
		byte? UseBuyRate = (byte)0,
		decimal? TRate1 = null,
		DateTime? PossibleDate = null,
		decimal? V1Amount1 = null,
		decimal? V1Amount2 = null,
		decimal? V1Amount3 = null,
		decimal? V1Amount4 = null,
		decimal? V1Amount5 = null,
		string CurrCode2 = null,
		decimal? TRate2 = null,
		decimal? V2Amount1 = null,
		decimal? V2Amount2 = null,
		decimal? V2Amount3 = null,
		decimal? V2Amount4 = null,
		decimal? V2Amount5 = null,
		string CurrCode3 = null,
		decimal? TRate3 = null,
		decimal? V3Amount1 = null,
		decimal? V3Amount2 = null,
		decimal? V3Amount3 = null,
		decimal? V3Amount4 = null,
		decimal? V3Amount5 = null,
		string CurrCode4 = null,
		decimal? TRate4 = null,
		decimal? V4Amount1 = null,
		decimal? V4Amount2 = null,
		decimal? V4Amount3 = null,
		decimal? V4Amount4 = null,
		decimal? V4Amount5 = null,
		decimal? V4Amount6 = null,
		decimal? V4Amount7 = null,
		decimal? V4Amount8 = null,
		decimal? V4Amount9 = null,
		decimal? V4Amount10 = null,
		decimal? V4Amount11 = null,
		string CurrCode5 = null,
		decimal? TRate5 = null,
		decimal? V5Amount1 = null,
		decimal? V5Amount2 = null,
		decimal? V5Amount3 = null,
		decimal? V5Amount4 = null,
		decimal? V5Amount5 = null,
		string CurrCode6 = null,
		decimal? TRate6 = null,
		decimal? V6Amount1 = null,
		decimal? V6Amount2 = null,
		decimal? V6Amount3 = null,
		decimal? V6Amount4 = null,
		decimal? V6Amount5 = null,
		string PoNum = null,
		string GrnNum = null)
		{
			CurrCodeType _CurrCode1 = CurrCode1;
			Flag _UseBuyRate = UseBuyRate;
			ExchRateType _TRate1 = TRate1;
			GenericDate _PossibleDate = PossibleDate;
			GenericDecimalType _V1Amount1 = V1Amount1;
			GenericDecimalType _V1Amount2 = V1Amount2;
			GenericDecimalType _V1Amount3 = V1Amount3;
			GenericDecimalType _V1Amount4 = V1Amount4;
			GenericDecimalType _V1Amount5 = V1Amount5;
			CurrCodeType _CurrCode2 = CurrCode2;
			ExchRateType _TRate2 = TRate2;
			GenericDecimalType _V2Amount1 = V2Amount1;
			GenericDecimalType _V2Amount2 = V2Amount2;
			GenericDecimalType _V2Amount3 = V2Amount3;
			GenericDecimalType _V2Amount4 = V2Amount4;
			GenericDecimalType _V2Amount5 = V2Amount5;
			CurrCodeType _CurrCode3 = CurrCode3;
			ExchRateType _TRate3 = TRate3;
			GenericDecimalType _V3Amount1 = V3Amount1;
			GenericDecimalType _V3Amount2 = V3Amount2;
			GenericDecimalType _V3Amount3 = V3Amount3;
			GenericDecimalType _V3Amount4 = V3Amount4;
			GenericDecimalType _V3Amount5 = V3Amount5;
			CurrCodeType _CurrCode4 = CurrCode4;
			ExchRateType _TRate4 = TRate4;
			GenericDecimalType _V4Amount1 = V4Amount1;
			GenericDecimalType _V4Amount2 = V4Amount2;
			GenericDecimalType _V4Amount3 = V4Amount3;
			GenericDecimalType _V4Amount4 = V4Amount4;
			GenericDecimalType _V4Amount5 = V4Amount5;
			GenericDecimalType _V4Amount6 = V4Amount6;
			GenericDecimalType _V4Amount7 = V4Amount7;
			GenericDecimalType _V4Amount8 = V4Amount8;
			GenericDecimalType _V4Amount9 = V4Amount9;
			GenericDecimalType _V4Amount10 = V4Amount10;
			GenericDecimalType _V4Amount11 = V4Amount11;
			CurrCodeType _CurrCode5 = CurrCode5;
			ExchRateType _TRate5 = TRate5;
			GenericDecimalType _V5Amount1 = V5Amount1;
			GenericDecimalType _V5Amount2 = V5Amount2;
			GenericDecimalType _V5Amount3 = V5Amount3;
			GenericDecimalType _V5Amount4 = V5Amount4;
			GenericDecimalType _V5Amount5 = V5Amount5;
			CurrCodeType _CurrCode6 = CurrCode6;
			ExchRateType _TRate6 = TRate6;
			GenericDecimalType _V6Amount1 = V6Amount1;
			GenericDecimalType _V6Amount2 = V6Amount2;
			GenericDecimalType _V6Amount3 = V6Amount3;
			GenericDecimalType _V6Amount4 = V6Amount4;
			GenericDecimalType _V6Amount5 = V6Amount5;
			PoNumType _PoNum = PoNum;
			GrnNumType _GrnNum = GrnNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_LCDomCurrSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode1", _CurrCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate1", _TRate1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PossibleDate", _PossibleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V1Amount1", _V1Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V1Amount2", _V1Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V1Amount3", _V1Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V1Amount4", _V1Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V1Amount5", _V1Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode2", _CurrCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate2", _TRate2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V2Amount1", _V2Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V2Amount2", _V2Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V2Amount3", _V2Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V2Amount4", _V2Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V2Amount5", _V2Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode3", _CurrCode3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate3", _TRate3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V3Amount1", _V3Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V3Amount2", _V3Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V3Amount3", _V3Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V3Amount4", _V3Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V3Amount5", _V3Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode4", _CurrCode4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate4", _TRate4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount1", _V4Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount2", _V4Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount3", _V4Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount4", _V4Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount5", _V4Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount6", _V4Amount6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount7", _V4Amount7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount8", _V4Amount8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount9", _V4Amount9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount10", _V4Amount10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V4Amount11", _V4Amount11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode5", _CurrCode5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate5", _TRate5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V5Amount1", _V5Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V5Amount2", _V5Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V5Amount3", _V5Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V5Amount4", _V5Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V5Amount5", _V5Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode6", _CurrCode6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRate6", _TRate6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V6Amount1", _V6Amount1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V6Amount2", _V6Amount2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V6Amount3", _V6Amount3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V6Amount4", _V6Amount4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "V6Amount5", _V6Amount5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
