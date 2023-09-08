//PROJECT NAME: Material
//CLASS NAME: JobtranSerialSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class JobtranSerialSave : IJobtranSerialSave
	{
		readonly IApplicationDB appDB;
		
		
		public JobtranSerialSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobtranSerialSaveSp(string SerNum,
		int? Selected,
		Guid? TmpSerId = null,
		string Item = null,
		int? PreassignSerials = null,
		string TrxRestrictCode = null)
		{
			SerNumType _SerNum = SerNum;
			ListYesNoType _Selected = Selected;
			RowPointerType _TmpSerId = TmpSerId;
			ItemType _Item = Item;
			ListYesNoType _PreassignSerials = PreassignSerials;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranSerialSaveSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpSerId", _TmpSerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
