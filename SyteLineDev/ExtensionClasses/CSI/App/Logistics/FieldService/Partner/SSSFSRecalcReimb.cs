//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRecalcReimb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSRecalcReimb : ISSSFSRecalcReimb
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSRecalcReimb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSRecalcReimbSp(string PartnerID,
		string CurrCode)
		{
			FSPartnerType _PartnerID = PartnerID;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRecalcReimbSp";
				
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
