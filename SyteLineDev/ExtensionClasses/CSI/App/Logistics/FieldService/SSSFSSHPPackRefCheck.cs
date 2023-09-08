//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSHPPackRefCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSHPPackRefCheck : ISSSFSSHPPackRefCheck
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSHPPackRefCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string ShipCode,
			string Infobar) SSSFSSHPPackRefCheckSp(
			string SroNum,
			string CustNum,
			int? CustSeq,
			string ShipCode,
			string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ShipCodeType _ShipCode = ShipCode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSHPPackRefCheckSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				ShipCode = _ShipCode;
				Infobar = _Infobar;
				
				return (Severity, CustNum, CustSeq, ShipCode, Infobar);
			}
		}
	}
}
