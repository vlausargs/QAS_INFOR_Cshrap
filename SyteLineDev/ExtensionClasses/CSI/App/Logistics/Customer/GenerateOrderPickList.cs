//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickList : IGenerateOrderPickList
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateOrderPickList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateOrderPickListSp(Guid? PSessionId,
		string PCoNum,
		DateTime? PStartDueDate,
		DateTime? PEndDueDate,
		string PWhse,
		string PCustNum,
		int? PCustSeq,
		string PParmsSite,
		DateTime? PPostDate,
		int? PPostMatlIssues,
		int? PBarLoc,
		int? PShowExternal,
		int? PShowInternal,
		int? PDisplayHeader,
		int? PPrintBc,
		int? PPrint80,
		string PDetSummBoth,
		string PPrItemCi,
		int? PPrSerialNumbers,
		int? PPrPlanItemMatl,
		int? PPrStdOrderText,
		int? PDisplayDescription,
		int? PListByLoc,
		string PPickwarn,
		int? PSuppressErrorWhenCustomerLcrNotReqd,
		int? PSkipOrderLineCycCnt,
		int? PProcessBatchId = null,
		string PText = null,
		string Infobar = null)
		{
			RowPointerType _PSessionId = PSessionId;
			CoNumType _PCoNum = PCoNum;
			DateType _PStartDueDate = PStartDueDate;
			DateType _PEndDueDate = PEndDueDate;
			WhseType _PWhse = PWhse;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			SiteType _PParmsSite = PParmsSite;
			DateType _PPostDate = PPostDate;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			ListYesNoType _PBarLoc = PBarLoc;
			FlagNyType _PShowExternal = PShowExternal;
			FlagNyType _PShowInternal = PShowInternal;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			ListYesNoType _PPrintBc = PPrintBc;
			ListYesNoType _PPrint80 = PPrint80;
			StringType _PDetSummBoth = PDetSummBoth;
			StringType _PPrItemCi = PPrItemCi;
			ListYesNoType _PPrSerialNumbers = PPrSerialNumbers;
			ListYesNoType _PPrPlanItemMatl = PPrPlanItemMatl;
			ListYesNoType _PPrStdOrderText = PPrStdOrderText;
			FlagNyType _PDisplayDescription = PDisplayDescription;
			ListYesNoType _PListByLoc = PListByLoc;
			StringType _PPickwarn = PPickwarn;
			ListYesNoType _PSuppressErrorWhenCustomerLcrNotReqd = PSuppressErrorWhenCustomerLcrNotReqd;
			ListYesNoType _PSkipOrderLineCycCnt = PSkipOrderLineCycCnt;
			BatchIdType _PProcessBatchId = PProcessBatchId;
			FormNameType _PText = PText;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListSp";
				
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDueDate", _PStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDueDate", _PEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsSite", _PParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBarLoc", _PBarLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowExternal", _PShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowInternal", _PShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintBc", _PPrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrint80", _PPrint80, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDetSummBoth", _PDetSummBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrItemCi", _PPrItemCi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrSerialNumbers", _PPrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrPlanItemMatl", _PPrPlanItemMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrStdOrderText", _PPrStdOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayDescription", _PDisplayDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PListByLoc", _PListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickwarn", _PPickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuppressErrorWhenCustomerLcrNotReqd", _PSuppressErrorWhenCustomerLcrNotReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSkipOrderLineCycCnt", _PSkipOrderLineCycCnt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessBatchId", _PProcessBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
