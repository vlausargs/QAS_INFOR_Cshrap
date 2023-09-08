//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContSROGenCopyOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContSROGenCopyOper : ISSSFSContSROGenCopyOper
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContSROGenCopyOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? NewSroOper,
			string Infobar) SSSFSContSROGenCopyOperSp(
			string Contract,
			int? MntSeq,
			string SROCopyLevel,
			string SroCopyTransFrom,
			string ToSroNum,
			int? ToSroLine,
			string TemplateSroNum,
			int? TemplateSroLine,
			DateTime? Date,
			string LeadPartner,
			int? NewSroOper,
			string Infobar,
			int? KeepOperNums = 0,
			int? UseSroWhse = 0,
			string iSroCopyTransTo = "P")
		{
			FSContractType _Contract = Contract;
			FSSeqType _MntSeq = MntSeq;
			StringType _SROCopyLevel = SROCopyLevel;
			StringType _SroCopyTransFrom = SroCopyTransFrom;
			FSSRONumType _ToSroNum = ToSroNum;
			FSSROLineType _ToSroLine = ToSroLine;
			FSSRONumType _TemplateSroNum = TemplateSroNum;
			FSSROLineType _TemplateSroLine = TemplateSroLine;
			DateTimeType _Date = Date;
			FSPartnerType _LeadPartner = LeadPartner;
			FSSROOperType _NewSroOper = NewSroOper;
			InfobarType _Infobar = Infobar;
			ListYesNoType _KeepOperNums = KeepOperNums;
			ListYesNoType _UseSroWhse = UseSroWhse;
			StringType _iSroCopyTransTo = iSroCopyTransTo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContSROGenCopyOperSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MntSeq", _MntSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROCopyLevel", _SROCopyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroCopyTransFrom", _SroCopyTransFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroNum", _ToSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSroLine", _ToSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TemplateSroNum", _TemplateSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TemplateSroLine", _TemplateSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadPartner", _LeadPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSroOper", _NewSroOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "KeepOperNums", _KeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseSroWhse", _UseSroWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroCopyTransTo", _iSroCopyTransTo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewSroOper = _NewSroOper;
				Infobar = _Infobar;
				
				return (Severity, NewSroOper, Infobar);
			}
		}
	}
}
