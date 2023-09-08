//PROJECT NAME: CSIMaterial
//CLASS NAME: PortalProductsCriteriaSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPortalProductsCriteriaSave
	{
		int? PortalProductsCriteriaSaveSp(Guid? SessionID,
		                                  string Criteria,
		                                  string CriterionTypes,
		                                  string ResellerCustNum,
		                                  string CustNum);
	}
	
	public class PortalProductsCriteriaSave : IPortalProductsCriteriaSave
	{
		readonly IApplicationDB appDB;
		
		public PortalProductsCriteriaSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalProductsCriteriaSaveSp(Guid? SessionID,
		                                         string Criteria,
		                                         string CriterionTypes,
		                                         string ResellerCustNum,
		                                         string CustNum)
		{
			RowPointerType _SessionID = SessionID;
			StringType _Criteria = Criteria;
			StringType _CriterionTypes = CriterionTypes;
			CustNumType _ResellerCustNum = ResellerCustNum;
			CustNumType _CustNum = CustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalProductsCriteriaSaveSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Criteria", _Criteria, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CriterionTypes", _CriterionTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCustNum", _ResellerCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
