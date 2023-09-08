//PROJECT NAME: Finance
//CLASS NAME: PrtAcctDis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PrtAcctDis : IPrtAcctDis
	{
		readonly IApplicationDB appDB;
		
		public PrtAcctDis(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PrtAcctDisSp(
			string pAcct,
			decimal? pAmount,
			string pList,
			string pCurrCode,
			string pCrDbTxt,
			string pChartDescription,
			int? pDomCurrPlaces,
			int? pDetailSeq,
			DateTime? pDate,
			decimal? pForAmount)
		{
			AcctType _pAcct = pAcct;
			AmountType _pAmount = pAmount;
			LongListType _pList = pList;
			CurrCodeType _pCurrCode = pCurrCode;
			CategoryType _pCrDbTxt = pCrDbTxt;
			DescriptionType _pChartDescription = pChartDescription;
			DecimalPlacesType _pDomCurrPlaces = pDomCurrPlaces;
			JournalSeqType _pDetailSeq = pDetailSeq;
			DateType _pDate = pDate;
			AmountType _pForAmount = pForAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrtAcctDisSp";
				
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pList", _pList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCrDbTxt", _pCrDbTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartDescription", _pChartDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomCurrPlaces", _pDomCurrPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDetailSeq", _pDetailSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDate", _pDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForAmount", _pForAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
