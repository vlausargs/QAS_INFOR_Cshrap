//PROJECT NAME: Production
//CLASS NAME: EngWBPsSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class EngWBPsSave : IEngWBPsSave
	{
		readonly IApplicationDB appDB;
		
		
		public EngWBPsSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EngWBPsSaveSp(int? InsertFlag,
		string PsNum,
		string PsStatus,
		string PsDescription,
		string Item,
		string Whse,
		string Revision)
		{
			ListYesNoType _InsertFlag = InsertFlag;
			PsNumType _PsNum = PsNum;
			PsStatusType _PsStatus = PsStatus;
			DescriptionType _PsDescription = PsDescription;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBPsSaveSp";
				
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsStatus", _PsStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsDescription", _PsDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
