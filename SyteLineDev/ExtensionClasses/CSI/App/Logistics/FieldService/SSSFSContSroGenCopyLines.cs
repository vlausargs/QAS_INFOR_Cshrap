//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContSROGenCopyLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContSROGenCopyLines : ISSSFSContSROGenCopyLines
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContSROGenCopyLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SROLine,
			int? SROOper,
			string Infobar) SSSFSContSROGenCopyLinesSp(
			string Contract,
			string SROCopyLevel,
			string SroCopyTransFrom,
			int? MntSeq,
			string ToSroNum,
			string TemplateSroNum,
			DateTime? Date,
			string LeadPartner,
			int? SROLine,
			int? SROOper,
			string Infobar,
			int? KeepOperNums = 0,
			int? UseSroWhse = 0,
			string iSroCopyTransTo = "P")
		{
			FSContractType _Contract = Contract;
			StringType _SROCopyLevel = SROCopyLevel;
			StringType _SroCopyTransFrom = SroCopyTransFrom;
			FSSeqType _MntSeq = MntSeq;
			FSSRONumType _ToSroNum = ToSroNum;
			FSSRONumType _TemplateSroNum = TemplateSroNum;
			DateTimeType _Date = Date;
			FSPartnerType _LeadPartner = LeadPartner;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			InfobarType _Infobar = Infobar;
			ListYesNoType _KeepOperNums = KeepOperNums;
			ListYesNoType _UseSroWhse = UseSroWhse;
			StringType _iSroCopyTransTo = iSroCopyTransTo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContSROGenCopyLinesSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROCopyLevel", _SROCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroCopyTransFrom", _SroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MntSeq", _MntSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroNum", _ToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TemplateSroNum", _TemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadPartner", _LeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "KeepOperNums", _KeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseSroWhse", _UseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROLine = _SROLine;
				SROOper = _SROOper;
				Infobar = _Infobar;
				
				return (Severity, SROLine, SROOper, Infobar);
			}
		}
	}
}
