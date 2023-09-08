//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadPostedVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_LoadPostedVouchers
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CHSCLM_LoadPostedVouchersSp(short? fiscal_year = null,
		byte? period = null,
		string CrntNmbrStart = null,
		string CrntNmbrEnd = null,
		string TypeCode = null,
		string Infobar = null);
	}
	
	public class CHSCLM_LoadPostedVouchers : ICHSCLM_LoadPostedVouchers
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSCLM_LoadPostedVouchers(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CHSCLM_LoadPostedVouchersSp(short? fiscal_year = null,
		byte? period = null,
		string CrntNmbrStart = null,
		string CrntNmbrEnd = null,
		string TypeCode = null,
		string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				FiscalYearType _fiscal_year = fiscal_year;
				FinPeriodType _period = period;
				GenericMedCodeType _CrntNmbrStart = CrntNmbrStart;
				GenericMedCodeType _CrntNmbrEnd = CrntNmbrEnd;
				TransNatType _TypeCode = TypeCode;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CHSCLM_LoadPostedVouchersSp";
					
					appDB.AddCommandParameter(cmd, "fiscal_year", _fiscal_year, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "period", _period, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CrntNmbrStart", _CrntNmbrStart, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CrntNmbrEnd", _CrntNmbrEnd, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TypeCode", _TypeCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
