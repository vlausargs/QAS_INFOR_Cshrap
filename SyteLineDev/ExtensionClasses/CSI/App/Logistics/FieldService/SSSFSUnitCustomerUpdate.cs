//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitCustomerUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitCustomerUpdate
	{
		(int? ReturnCode, string Infobar) SSSFSUnitCustomerUpdateSp(string CustNum,
		int? CustSeq,
		string Target,
		string RefNum,
		string SerNum,
		string Infobar,
		string UsrNum = null,
		int? UsrSeq = null,
		string Item = null);
	}
	
	public class SSSFSUnitCustomerUpdate : ISSSFSUnitCustomerUpdate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitCustomerUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSUnitCustomerUpdateSp(string CustNum,
		int? CustSeq,
		string Target,
		string RefNum,
		string SerNum,
		string Infobar,
		string UsrNum = null,
		int? UsrSeq = null,
		string Item = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			StringType _Target = Target;
			FSIncNumType _RefNum = RefNum;
			SerNumType _SerNum = SerNum;
			Infobar _Infobar = Infobar;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitCustomerUpdateSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Target", _Target, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
