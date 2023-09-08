//PROJECT NAME: Material
//CLASS NAME: UpdateContainerItemSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateContainerItemSerial : IUpdateContainerItemSerial
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateContainerItemSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateContainerItemSerialSp(string PItem,
		string PLot,
		string PContainerNum,
		Guid? PSessionId,
		string Infobar)
		{
			ItemType _PItem = PItem;
			LotType _PLot = PLot;
			ContainerNumType _PContainerNum = PContainerNum;
			RowPointerType _PSessionId = PSessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateContainerItemSerialSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContainerNum", _PContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
