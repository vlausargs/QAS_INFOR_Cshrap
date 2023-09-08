//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSSROInspectFailCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROInspectFailCount
	{
		int SSSFSSROInspectFailCountSp(string SroNum,
		                               int? SroLine,
		                               string InspectType,
		                               string SectionCode,
		                               int? CompId,
		                               ref int? IntialFailCnt,
		                               ref int? AdjustFailCnt,
		                               ref string Infobar);
	}
	
	public class SSSFSSROInspectFailCount : ISSSFSSROInspectFailCount
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInspectFailCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSROInspectFailCountSp(string SroNum,
		                                      int? SroLine,
		                                      string InspectType,
		                                      string SectionCode,
		                                      int? CompId,
		                                      ref int? IntialFailCnt,
		                                      ref int? AdjustFailCnt,
		                                      ref string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSInspectTypeType _InspectType = InspectType;
			FSSectionCodeType _SectionCode = SectionCode;
			FSCompIdType _CompId = CompId;
			IntType _IntialFailCnt = IntialFailCnt;
			IntType _AdjustFailCnt = AdjustFailCnt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInspectFailCountSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InspectType", _InspectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SectionCode", _SectionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntialFailCnt", _IntialFailCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdjustFailCnt", _AdjustFailCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IntialFailCnt = _IntialFailCnt;
				AdjustFailCnt = _AdjustFailCnt;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
