//PROJECT NAME: Admin
//CLASS NAME: BI_SaveBILinkSites.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IBI_SaveBILinkSites
	{
		int? BI_SaveBILinkSitesSp(string ServerName,
		string DatabaseName,
		string Site,
		string Description,
		Guid? RowPointer = null);
	}
	
	public class BI_SaveBILinkSites : IBI_SaveBILinkSites
	{
		IApplicationDB appDB;
		
		public BI_SaveBILinkSites(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_SaveBILinkSitesSp(string ServerName,
		string DatabaseName,
		string Site,
		string Description,
		Guid? RowPointer = null)
		{
			OSLocationType _ServerName = ServerName;
			ObjectNameType _DatabaseName = DatabaseName;
			SiteType _Site = Site;
			DescriptionType _Description = Description;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_SaveBILinkSitesSp";
				
				appDB.AddCommandParameter(cmd, "ServerName", _ServerName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
