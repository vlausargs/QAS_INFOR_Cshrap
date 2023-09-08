//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoCo : ICpSoCpSoCo
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CpSoCpSoCoSp(
			string PFromCoType,
			string PFromCoNum,
			string PToCoType,
			string PToCoNum,
			string PToCoOrigSite,
			string PToCurr,
			string Infobar)
		{
			CoTypeType _PFromCoType = PFromCoType;
			CoNumType _PFromCoNum = PFromCoNum;
			CoTypeType _PToCoType = PToCoType;
			CoNumType _PToCoNum = PToCoNum;
			SiteType _PToCoOrigSite = PToCoOrigSite;
			CurrCodeType _PToCurr = PToCurr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoCoSp";
				
				appDB.AddCommandParameter(cmd, "PFromCoType", _PFromCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCoNum", _PFromCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoType", _PToCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoNum", _PToCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoOrigSite", _PToCoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurr", _PToCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
