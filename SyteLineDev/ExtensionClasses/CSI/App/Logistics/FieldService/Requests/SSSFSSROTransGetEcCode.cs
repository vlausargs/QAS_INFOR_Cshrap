//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROTransGetEcCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransGetEcCode
	{
		int SSSFSSROTransGetEcCodeSp(string SroNum,
		                             string DropType,
		                             string DropNum,
		                             int? DropSeq,
		                             ref string EcCode);
	}
	
	public class SSSFSSROTransGetEcCode : ISSSFSSROTransGetEcCode
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransGetEcCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSROTransGetEcCodeSp(string SroNum,
		                                    string DropType,
		                                    string DropNum,
		                                    int? DropSeq,
		                                    ref string EcCode)
		{
			FSSRONumType _SroNum = SroNum;
			FSDropShipTypeType _DropType = DropType;
			FSPartnerType _DropNum = DropNum;
			DropSeqType _DropSeq = DropSeq;
			EcCodeType _EcCode = EcCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransGetEcCodeSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropType", _DropType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropNum", _DropNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DropSeq", _DropSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EcCode = _EcCode;
				
				return Severity;
			}
		}
	}
}
