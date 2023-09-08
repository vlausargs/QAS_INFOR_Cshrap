//PROJECT NAME: Data
//CLASS NAME: FSBCheckPermissionOnTransDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FSBCheckPermissionOnTransDate : IFSBCheckPermissionOnTransDate
	{
		readonly IApplicationDB appDB;
		
		public FSBCheckPermissionOnTransDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OutOfPeriod,
			int? CanTransact,
			string Infobar) FSBCheckPermissionOnTransDateSp(
			string FSBName,
			DateTime? PTransDate,
			string Site = null,
			int? OutOfPeriod = null,
			int? CanTransact = null,
			string Infobar = null)
		{
			FSBNameType _FSBName = FSBName;
			CurrentDateType _PTransDate = PTransDate;
			SiteType _Site = Site;
			ListYesNoType _OutOfPeriod = OutOfPeriod;
			ListYesNoType _CanTransact = CanTransact;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FSBCheckPermissionOnTransDateSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutOfPeriod", _OutOfPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanTransact", _CanTransact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutOfPeriod = _OutOfPeriod;
				CanTransact = _CanTransact;
				Infobar = _Infobar;
				
				return (Severity, OutOfPeriod, CanTransact, Infobar);
			}
		}
	}
}
