//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchAddCompForCur.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchAddCompForCur : ISSSFSConfigSearchAddCompForCur
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigSearchAddCompForCur(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConfigSearchAddCompForCurSp(
			int? CompId,
			string Search,
			int? Level,
			int? CompSer,
			int? CompItem,
			int? CompCustItem,
			int? CompDesc)
		{
			FSCompIdType _CompId = CompId;
			DescriptionType _Search = Search;
			IntType _Level = Level;
			ListYesNoType _CompSer = CompSer;
			ListYesNoType _CompItem = CompItem;
			ListYesNoType _CompCustItem = CompCustItem;
			ListYesNoType _CompDesc = CompDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigSearchAddCompForCurSp";
				
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Search", _Search, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompSer", _CompSer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompItem", _CompItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompCustItem", _CompCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompDesc", _CompDesc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
