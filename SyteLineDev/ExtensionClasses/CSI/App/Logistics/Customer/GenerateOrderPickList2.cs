//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickList2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickList2 : IGenerateOrderPickList2
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickList2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateOrderPickList2Sp(
			int? PFromCo14R,
			int? PProcessBatchId,
			Guid? PSessionId,
			int? PBarLoc,
			string PCoNum,
			string PCustNum,
			int? PCustSeq,
			string PWhse,
			DateTime? PStartDueDate,
			DateTime? PEndDueDate,
			string PParmsSite,
			string PDetSummBoth,
			int? PDisplayDescription,
			int? PListByLoc,
			string PPickwarn,
			int? PPostMatlIssues,
			DateTime? PPostDate,
			int? PPrintBc,
			string PPrItemCi,
			int? PPrPlanItemMatl,
			int? PPrSerialNumbers,
			int? PPrStdOrderText,
			int? PSuppressErrorWhenCustomerLcrNotReqd,
			int? PSkipOrderLineCycCnt,
			string PText,
			string PCoparmsCoText1,
			string PCoparmsCoText2,
			string PCoparmsCoText3,
			int? PCoparmsPickwarnCo,
			string PInvparmsFbomBlank,
			string PInvparmsFeatTempl,
			string Infobar)
		{
			ListYesNoType _PFromCo14R = PFromCo14R;
			BatchIdType _PProcessBatchId = PProcessBatchId;
			RowPointerType _PSessionId = PSessionId;
			ListYesNoType _PBarLoc = PBarLoc;
			CoNumType _PCoNum = PCoNum;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			WhseType _PWhse = PWhse;
			DateType _PStartDueDate = PStartDueDate;
			DateType _PEndDueDate = PEndDueDate;
			SiteType _PParmsSite = PParmsSite;
			StringType _PDetSummBoth = PDetSummBoth;
			FlagNyType _PDisplayDescription = PDisplayDescription;
			ListYesNoType _PListByLoc = PListByLoc;
			StringType _PPickwarn = PPickwarn;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			DateType _PPostDate = PPostDate;
			ListYesNoType _PPrintBc = PPrintBc;
			StringType _PPrItemCi = PPrItemCi;
			ListYesNoType _PPrPlanItemMatl = PPrPlanItemMatl;
			ListYesNoType _PPrSerialNumbers = PPrSerialNumbers;
			ListYesNoType _PPrStdOrderText = PPrStdOrderText;
			ListYesNoType _PSuppressErrorWhenCustomerLcrNotReqd = PSuppressErrorWhenCustomerLcrNotReqd;
			ListYesNoType _PSkipOrderLineCycCnt = PSkipOrderLineCycCnt;
			FormNameType _PText = PText;
			ReportTxtType _PCoparmsCoText1 = PCoparmsCoText1;
			ReportTxtType _PCoparmsCoText2 = PCoparmsCoText2;
			ReportTxtType _PCoparmsCoText3 = PCoparmsCoText3;
			ListYesNoType _PCoparmsPickwarnCo = PCoparmsPickwarnCo;
			FeatBlankType _PInvparmsFbomBlank = PInvparmsFbomBlank;
			FeatTemplateType _PInvparmsFeatTempl = PInvparmsFeatTempl;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickList2Sp";
				
				appDB.AddCommandParameter(cmd, "PFromCo14R", _PFromCo14R, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessBatchId", _PProcessBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBarLoc", _PBarLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDueDate", _PStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDueDate", _PEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsSite", _PParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDetSummBoth", _PDetSummBoth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayDescription", _PDisplayDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PListByLoc", _PListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickwarn", _PPickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintBc", _PPrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrItemCi", _PPrItemCi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrPlanItemMatl", _PPrPlanItemMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrSerialNumbers", _PPrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrStdOrderText", _PPrStdOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuppressErrorWhenCustomerLcrNotReqd", _PSuppressErrorWhenCustomerLcrNotReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSkipOrderLineCycCnt", _PSkipOrderLineCycCnt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PText", _PText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsCoText1", _PCoparmsCoText1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsCoText2", _PCoparmsCoText2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsCoText3", _PCoparmsCoText3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsPickwarnCo", _PCoparmsPickwarnCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvparmsFbomBlank", _PInvparmsFbomBlank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvparmsFeatTempl", _PInvparmsFeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
