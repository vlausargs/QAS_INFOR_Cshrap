//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSCopyDefMaint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSCopyDefMaint
	{
		int SSSFSCopyDefMaintSp(string iItem,
		                        string iSerNum,
		                        ref string Infobar);
	}
	
	public class SSSFSCopyDefMaint : ISSSFSCopyDefMaint
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCopyDefMaint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSCopyDefMaintSp(string iItem,
		                               string iSerNum,
		                               ref string Infobar)
		{
			ItemType _iItem = iItem;
			SerNumType _iSerNum = iSerNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCopyDefMaintSp";
				
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
