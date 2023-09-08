//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalGetUnitRegInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPortalGetUnitRegInfo : ISSSFSPortalGetUnitRegInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalGetUnitRegInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Email,
			string SerNum,
			string Infobar) SSSFSPortalGetUnitRegInfoSp(
			decimal? TransNum,
			string Email,
			string SerNum,
			string Infobar)
		{
			HugeTransNumType _TransNum = TransNum;
			EmailType _Email = Email;
			SerNumType _SerNum = SerNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalGetUnitRegInfoSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Email = _Email;
				SerNum = _SerNum;
				Infobar = _Infobar;
				
				return (Severity, Email, SerNum, Infobar);
			}
		}
	}
}
