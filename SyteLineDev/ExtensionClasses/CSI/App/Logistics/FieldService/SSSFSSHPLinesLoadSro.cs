//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSHPLinesLoadSro.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSHPLinesLoadSro : ISSSFSSHPLinesLoadSro
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSHPLinesLoadSro(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSHPLinesLoadSroSp(
			string CustNum,
			int? CustSeq,
			string Infobar,
			string RefType = "S")
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			Infobar _Infobar = Infobar;
			StringType _RefType = RefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSHPLinesLoadSroSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
