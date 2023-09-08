//PROJECT NAME: Data
//CLASS NAME: ValUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValUnit : IValUnit
	{
		readonly IApplicationDB appDB;
		
		public ValUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValUnitSp(
			Guid? PItemlocRowPointer,
			Guid? PProdcodeRowPointer,
			string Infobar,
			string Site = null)
		{
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			RowPointerType _PProdcodeRowPointer = PProdcodeRowPointer;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValUnitSp";
				
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProdcodeRowPointer", _PProdcodeRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
