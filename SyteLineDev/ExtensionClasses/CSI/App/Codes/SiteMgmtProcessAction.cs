//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtProcessAction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class SiteMgmtProcessAction : ISiteMgmtProcessAction
	{
		readonly IApplicationDB appDB;
		
		
		public SiteMgmtProcessAction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SiteMgmtProcessActionSp(string PSite,
		string PSiteName,
		string PSiteDescription,
		string PSiteType,
		string PSiteTimeZone,
		string PSiteGroup,
		string Infobar)
		{
			SiteType _PSite = PSite;
			NameType _PSiteName = PSiteName;
			DescriptionType _PSiteDescription = PSiteDescription;
			SiteTypeType _PSiteType = PSiteType;
			TimeZoneType _PSiteTimeZone = PSiteTimeZone;
			SiteGroupType _PSiteGroup = PSiteGroup;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SiteMgmtProcessActionSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteName", _PSiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteDescription", _PSiteDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteType", _PSiteType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteTimeZone", _PSiteTimeZone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
