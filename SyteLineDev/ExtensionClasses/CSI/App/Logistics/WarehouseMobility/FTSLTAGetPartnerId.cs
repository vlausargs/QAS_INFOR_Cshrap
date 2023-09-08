//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAGetPartnerId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLTAGetPartnerId
	{
		int FTSLTAGetPartnerIdSp(string EmployeeNumber,
		                         string PartnerID,
		                         ref string Name);
	}
	
	public class FTSLTAGetPartnerId : IFTSLTAGetPartnerId
	{
		readonly IApplicationDB appDB;
		
		public FTSLTAGetPartnerId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLTAGetPartnerIdSp(string EmployeeNumber,
		                                string PartnerID,
		                                ref string Name)
		{
			EmpNumType _EmployeeNumber = EmployeeNumber;
			FSPartnerType _PartnerID = PartnerID;
			NameType _Name = Name;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLTAGetPartnerIdSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeNumber", _EmployeeNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				
				return Severity;
			}
		}
	}
}
