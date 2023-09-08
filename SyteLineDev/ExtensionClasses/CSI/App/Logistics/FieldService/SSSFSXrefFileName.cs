//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefFileName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefFileName : ISSSFSXrefFileName
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefFileName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string RefType,
			string Name,
			string Infobar) SSSFSXrefFileNameSp(
			string RefType,
			string Name,
			string Infobar)
		{
			GenericCodeType _RefType = RefType;
			LongListType _Name = Name;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefFileNameSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefType = _RefType;
				Name = _Name;
				Infobar = _Infobar;
				
				return (Severity, RefType, Name, Infobar);
			}
		}
	}
}
