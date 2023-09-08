//PROJECT NAME: Data
//CLASS NAME: EdiGenFindCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiGenFindCo : IEdiGenFindCo
	{
		readonly IApplicationDB appDB;
		
		public EdiGenFindCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PCoNum,
			Guid? PCoRecid,
			int? PNewCoFlag,
			int? PError,
			string Infobar) EdiGenFindCoSp(
			string PCustNum,
			int? PCustSeq,
			string PCustPo,
			string POrdType,
			string PEdiCoNum,
			int? PCreateCo,
			string PTrxCode,
			string PCoNum,
			Guid? PCoRecid,
			int? PNewCoFlag,
			int? PError,
			string Infobar,
			string Site = null)
		{
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			CustPoType _PCustPo = PCustPo;
			LongListType _POrdType = POrdType;
			CoNumType _PEdiCoNum = PEdiCoNum;
			FlagNyType _PCreateCo = PCreateCo;
			EdiTrxCodeType _PTrxCode = PTrxCode;
			CoNumType _PCoNum = PCoNum;
			RowPointerType _PCoRecid = PCoRecid;
			FlagNyType _PNewCoFlag = PNewCoFlag;
			FlagNyType _PError = PError;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiGenFindCoSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustPo", _PCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdType", _POrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiCoNum", _PEdiCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreateCo", _PCreateCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrxCode", _PTrxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCoRecid", _PCoRecid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PNewCoFlag", _PNewCoFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PError", _PError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCoNum = _PCoNum;
				PCoRecid = _PCoRecid;
				PNewCoFlag = _PNewCoFlag;
				PError = _PError;
				Infobar = _Infobar;
				
				return (Severity, PCoNum, PCoRecid, PNewCoFlag, PError, Infobar);
			}
		}
	}
}
