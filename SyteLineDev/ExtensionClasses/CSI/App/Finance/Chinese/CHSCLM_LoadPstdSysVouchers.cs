//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadPstdSysVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_LoadPstdSysVouchers
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadPstdSysVouchersSp(short? FiscalYear = null,
		byte? Period = null,
		string FromVoucherNum = null,
		string ToVoucherNum = null,
		string TypeCode = null,
		Guid? SessionId = null,
		string Infobar = null);
	}
	
	public class CHSCLM_LoadPstdSysVouchers : ICHSCLM_LoadPstdSysVouchers
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSCLM_LoadPstdSysVouchers(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadPstdSysVouchersSp(short? FiscalYear = null,
		byte? Period = null,
		string FromVoucherNum = null,
		string ToVoucherNum = null,
		string TypeCode = null,
		Guid? SessionId = null,
		string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FiscalYearType _FiscalYear = FiscalYear;
				FinPeriodType _Period = Period;
				GenericMedCodeType _FromVoucherNum = FromVoucherNum;
				GenericMedCodeType _ToVoucherNum = ToVoucherNum;
				TransNatType _TypeCode = TypeCode;
				RowPointerType _SessionId = SessionId;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CHSCLM_LoadPstdSysVouchersSp";
					
					appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromVoucherNum", _FromVoucherNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToVoucherNum", _ToVoucherNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
