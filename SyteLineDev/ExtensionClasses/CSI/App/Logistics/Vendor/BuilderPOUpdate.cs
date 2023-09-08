//PROJECT NAME: Logistics
//CLASS NAME: BuilderPOUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class BuilderPOUpdate : IBuilderPOUpdate
	{
		readonly IApplicationDB appDB;
		
		public BuilderPOUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) BuilderPOUpdateSp(
			string pPoType,
			string pPoStat,
			int? pPostFlag,
			string pReviewPrint,
			string pOrigSite,
			string pStartvendor,
			string pEndVendor,
			int? pTransDomCurr,
			string pStartBuilderPoNum,
			string pEndBuilderPoNum,
			int? pStartPoLine,
			int? pEndPoLine,
			int? pStartPoRelease,
			int? pEndPoRelease,
			DateTime? pStartDueDate,
			DateTime? pEndDueDate,
			string pPoitemStat,
			DateTime? pStartOrderDate,
			DateTime? pEndOrderDate,
			int? pIncludeRegularPO,
			int? pIncludeBlanketPO,
			int? pIncludeBlnsWOReleases,
			int? pIncludePlannedPO,
			int? pIncludeOrderedPO,
			int? pIncludeCompletePO,
			int? pIncludePlannedLineRel,
			int? pIncludeOrderedLineRel,
			int? pIncludeFilledLineRel,
			int? pIncludeCompleteLineRel,
			int? pPrPoNotes,
			int? pPrPoBlnNotes,
			int? pPrPoItemNotes,
			int? pShowInternal,
			int? pShowExternal,
			string pPrintSite,
			Guid? pProcessId,
			string Infobar)
		{
			StringType _pPoType = pPoType;
			StringType _pPoStat = pPoStat;
			ListYesNoType _pPostFlag = pPostFlag;
			StringType _pReviewPrint = pReviewPrint;
			SiteType _pOrigSite = pOrigSite;
			VendNumType _pStartvendor = pStartvendor;
			VendNumType _pEndVendor = pEndVendor;
			ListYesNoType _pTransDomCurr = pTransDomCurr;
			BuilderPoNumType _pStartBuilderPoNum = pStartBuilderPoNum;
			BuilderPoNumType _pEndBuilderPoNum = pEndBuilderPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			PoReleaseType _pStartPoRelease = pStartPoRelease;
			PoReleaseType _pEndPoRelease = pEndPoRelease;
			DateType _pStartDueDate = pStartDueDate;
			DateType _pEndDueDate = pEndDueDate;
			StringType _pPoitemStat = pPoitemStat;
			DateType _pStartOrderDate = pStartOrderDate;
			DateType _pEndOrderDate = pEndOrderDate;
			ListYesNoType _pIncludeRegularPO = pIncludeRegularPO;
			ListYesNoType _pIncludeBlanketPO = pIncludeBlanketPO;
			ListYesNoType _pIncludeBlnsWOReleases = pIncludeBlnsWOReleases;
			ListYesNoType _pIncludePlannedPO = pIncludePlannedPO;
			ListYesNoType _pIncludeOrderedPO = pIncludeOrderedPO;
			ListYesNoType _pIncludeCompletePO = pIncludeCompletePO;
			ListYesNoType _pIncludePlannedLineRel = pIncludePlannedLineRel;
			ListYesNoType _pIncludeOrderedLineRel = pIncludeOrderedLineRel;
			ListYesNoType _pIncludeFilledLineRel = pIncludeFilledLineRel;
			ListYesNoType _pIncludeCompleteLineRel = pIncludeCompleteLineRel;
			ListYesNoType _pPrPoNotes = pPrPoNotes;
			ListYesNoType _pPrPoBlnNotes = pPrPoBlnNotes;
			ListYesNoType _pPrPoItemNotes = pPrPoItemNotes;
			ListYesNoType _pShowInternal = pShowInternal;
			ListYesNoType _pShowExternal = pShowExternal;
			SiteType _pPrintSite = pPrintSite;
			RowPointerType _pProcessId = pProcessId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuilderPOUpdateSp";
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostFlag", _pPostFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReviewPrint", _pReviewPrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrigSite", _pOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartBuilderPoNum", _pStartBuilderPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndBuilderPoNum", _pEndBuilderPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRelease", _pStartPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartOrderDate", _pStartOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeRegularPO", _pIncludeRegularPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeBlanketPO", _pIncludeBlanketPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeBlnsWOReleases", _pIncludeBlnsWOReleases, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludePlannedPO", _pIncludePlannedPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeOrderedPO", _pIncludeOrderedPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeCompletePO", _pIncludeCompletePO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludePlannedLineRel", _pIncludePlannedLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeOrderedLineRel", _pIncludeOrderedLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeFilledLineRel", _pIncludeFilledLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIncludeCompleteLineRel", _pIncludeCompleteLineRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoNotes", _pPrPoNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoBlnNotes", _pPrPoBlnNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoItemNotes", _pPrPoItemNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowInternal", _pShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowExternal", _pShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintSite", _pPrintSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProcessId", _pProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
