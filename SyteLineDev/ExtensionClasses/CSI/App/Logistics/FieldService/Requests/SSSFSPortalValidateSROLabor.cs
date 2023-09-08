//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalValidateSROLabor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSPortalValidateSROLabor
	{
		int SSSFSPortalValidateSROLaborSp(string SroNum,
		                                  int? SroLine,
		                                  int? SroOper,
		                                  string PartnerID,
		                                  DateTime? TransDate,
		                                  string CustNum,
		                                  string CustSeq,
		                                  string Username,
		                                  string WorkCode,
		                                  ref string Infobar);
	}
	
	public class SSSFSPortalValidateSROLabor : ISSSFSPortalValidateSROLabor
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalValidateSROLabor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSPortalValidateSROLaborSp(string SroNum,
		                                         int? SroLine,
		                                         int? SroOper,
		                                         string PartnerID,
		                                         DateTime? TransDate,
		                                         string CustNum,
		                                         string CustSeq,
		                                         string Username,
		                                         string WorkCode,
		                                         ref string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			FSPartnerType _PartnerID = PartnerID;
			DateTimeType _TransDate = TransDate;
			CustNumType _CustNum = CustNum;
			CustNumType _CustSeq = CustSeq;
			UsernameType _Username = Username;
			FSWorkCodeType _WorkCode = WorkCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalValidateSROLaborSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCode", _WorkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
