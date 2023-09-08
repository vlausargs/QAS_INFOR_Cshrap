//PROJECT NAME: Material
//CLASS NAME: AU_AddParentContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class AU_AddParentContainer : IAU_AddParentContainer
	{
		readonly IApplicationDB appDB;
		
		
		public AU_AddParentContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AU_AddParentContainerSp(string ContainerNum,
		string ParentContainerNum,
		string Infobar)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			ContainerNumType _ParentContainerNum = ParentContainerNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_AddParentContainerSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentContainerNum", _ParentContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
