//PROJECT NAME: CSIVendor
//CLASS NAME: PoDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPoDel
	{
		(int? ReturnCode, int? POsDeleted, string Infobar) PoDelSp(string StartingPONum,
		string EndingPONum,
		DateTime? StartingPODate,
		DateTime? EndingPODate,
		string StartingVendNum,
		string EndingVendNum,
		int? DeleteHistPOReqs,
		int? POsDeleted,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null);
	}
	
	public class PoDel : IPoDel
	{
		readonly IApplicationDB appDB;
		
		public PoDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? POsDeleted, string Infobar) PoDelSp(string StartingPONum,
		string EndingPONum,
		DateTime? StartingPODate,
		DateTime? EndingPODate,
		string StartingVendNum,
		string EndingVendNum,
		int? DeleteHistPOReqs,
		int? POsDeleted,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null)
		{
			PoNumType _StartingPONum = StartingPONum;
			PoNumType _EndingPONum = EndingPONum;
			DateType _StartingPODate = StartingPODate;
			DateType _EndingPODate = EndingPODate;
			VendNumType _StartingVendNum = StartingVendNum;
			VendNumType _EndingVendNum = EndingVendNum;
			IntType _DeleteHistPOReqs = DeleteHistPOReqs;
			IntType _POsDeleted = POsDeleted;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
			DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoDelSp";
				
				appDB.AddCommandParameter(cmd, "StartingPONum", _StartingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPONum", _EndingPONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPODate", _StartingPODate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPODate", _EndingPODate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteHistPOReqs", _DeleteHistPOReqs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POsDeleted", _POsDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POsDeleted = _POsDeleted;
				Infobar = _Infobar;
				
				return (Severity, POsDeleted, Infobar);
			}
		}
	}
}
