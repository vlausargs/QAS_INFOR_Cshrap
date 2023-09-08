//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSerialGetReturnSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSerialGetReturnSerial
	{
		int? SSSFSSerialGetReturnSerialSp(Guid? SessionId,
		string Item,
		string RefNum,
		short? RefLine = 0,
		short? RefRelease = 0,
		string Site = null);
	}
	
	public class SSSFSSerialGetReturnSerial : ISSSFSSerialGetReturnSerial
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSerialGetReturnSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSerialGetReturnSerialSp(Guid? SessionId,
		string Item,
		string RefNum,
		short? RefLine = 0,
		short? RefRelease = 0,
		string Site = null)
		{
			RowPointerType _SessionId = SessionId;
			ItemType _Item = Item;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoReleaseType _RefRelease = RefRelease;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSerialGetReturnSerialSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
