//PROJECT NAME: CSICustomer
//CLASS NAME: ARFinanceChargeGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IARFinanceChargeGen
	{
		(int? ReturnCode, int? pCount, string Infobar) ARFinanceChargeGenSp(string pSiteGroup,
		string pStartCustNum,
		string pEndCustNum,
		string pStateCycle,
		DateTime? pCutoffDate,
		int? pInclPaid,
		int? pDelFirst,
		int? pCount,
		string Infobar,
		int? CutoffDateOffset = null,
		string pStartDunGroup = null,
		string pEndDunGroup = null);
	}
	
	public class ARFinanceChargeGen : IARFinanceChargeGen
	{
		readonly IApplicationDB appDB;
		
		public ARFinanceChargeGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pCount, string Infobar) ARFinanceChargeGenSp(string pSiteGroup,
		string pStartCustNum,
		string pEndCustNum,
		string pStateCycle,
		DateTime? pCutoffDate,
		int? pInclPaid,
		int? pDelFirst,
		int? pCount,
		string Infobar,
		int? CutoffDateOffset = null,
		string pStartDunGroup = null,
		string pEndDunGroup = null)
		{
			SiteGroupType _pSiteGroup = pSiteGroup;
			HighLowCharType _pStartCustNum = pStartCustNum;
			HighLowCharType _pEndCustNum = pEndCustNum;
			StatementCycleType _pStateCycle = pStateCycle;
			DateType _pCutoffDate = pCutoffDate;
			ListYesNoType _pInclPaid = pInclPaid;
			ListYesNoType _pDelFirst = pDelFirst;
			IntType _pCount = pCount;
			InfobarType _Infobar = Infobar;
			DateOffsetType _CutoffDateOffset = CutoffDateOffset;
			HighLowCharType _pStartDunGroup = pStartDunGroup;
			HighLowCharType _pEndDunGroup = pEndDunGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARFinanceChargeGenSp";
				
				appDB.AddCommandParameter(cmd, "pSiteGroup", _pSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStateCycle", _pStateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInclPaid", _pInclPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDelFirst", _pDelFirst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCount", _pCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDunGroup", _pStartDunGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDunGroup", _pEndDunGroup, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCount = _pCount;
				Infobar = _Infobar;
				
				return (Severity, pCount, Infobar);
			}
		}
	}
}
