//PROJECT NAME: Production
//CLASS NAME: PmfFmImportValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmImportValidate
	{
		int? PmfFmImportValidateSp(Guid? SessionID);
	}
	
	public class PmfFmImportValidate : IPmfFmImportValidate
	{
		readonly IApplicationDB appDB;
		
		public PmfFmImportValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmImportValidateSp(Guid? SessionID)
		{
			GuidType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmImportValidateSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
