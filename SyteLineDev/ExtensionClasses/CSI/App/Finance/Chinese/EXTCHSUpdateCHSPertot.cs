//PROJECT NAME: Finance
//CLASS NAME: EXTCHSUpdateCHSPertot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSUpdateCHSPertot : IEXTCHSUpdateCHSPertot
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSUpdateCHSPertot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) EXTCHSUpdateCHSPertotSp(
			decimal? pLedgerDomAmount,
			string pLedgerRef,
			int? pPerSortMethod,
			string pCurrency,
			string pLedgerHierarchy,
			string pSF1,
			string pSF2,
			string pSF3,
			string pSF4,
			string pSF5,
			DateTime? pLedgerTransDate,
			decimal? pTransNum,
			decimal? pLedgerExchRate,
			string InfoBar)
		{
			AmountType _pLedgerDomAmount = pLedgerDomAmount;
			ReferenceType _pLedgerRef = pLedgerRef;
			SortMethodType _pPerSortMethod = pPerSortMethod;
			CurrCodeType _pCurrency = pCurrency;
			HierarchyType _pLedgerHierarchy = pLedgerHierarchy;
			PertotSortFieldType _pSF1 = pSF1;
			PertotSortFieldType _pSF2 = pSF2;
			PertotSortFieldType _pSF3 = pSF3;
			PertotSortFieldType _pSF4 = pSF4;
			PertotSortFieldType _pSF5 = pSF5;
			DateType _pLedgerTransDate = pLedgerTransDate;
			MatlTransNumType _pTransNum = pTransNum;
			ExchRateType _pLedgerExchRate = pLedgerExchRate;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSUpdateCHSPertotSp";
				
				appDB.AddCommandParameter(cmd, "pLedgerDomAmount", _pLedgerDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerRef", _pLedgerRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPerSortMethod", _pPerSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrency", _pCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerHierarchy", _pLedgerHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSF1", _pSF1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSF2", _pSF2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSF3", _pSF3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSF4", _pSF4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSF5", _pSF5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerTransDate", _pLedgerTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransNum", _pTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerExchRate", _pLedgerExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
