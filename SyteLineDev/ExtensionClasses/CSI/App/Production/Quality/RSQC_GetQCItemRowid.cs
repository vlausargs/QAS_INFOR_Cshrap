//PROJECT NAME: Production
//CLASS NAME: RSQC_GetQCItemRowid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetQCItemRowid : IRSQC_GetQCItemRowid
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetQCItemRowid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? o_RowPointer,
		string Infobar) RSQC_GetQCItemRowidSp(string i_Item,
		string i_RefType,
		string i_VendNum,
		string i_CustNum,
		int? i_OperNum,
		int? i_TestSeq,
		Guid? o_RowPointer,
		string Infobar)
		{
			ItemType _i_Item = i_Item;
			QCRefType _i_RefType = i_RefType;
			VendNumType _i_VendNum = i_VendNum;
			CustNumType _i_CustNum = i_CustNum;
			OperNumType _i_OperNum = i_OperNum;
			QCTestSeqType _i_TestSeq = i_TestSeq;
			RowPointerType _o_RowPointer = o_RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetQCItemRowidSp";
				
				appDB.AddCommandParameter(cmd, "i_Item", _i_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefType", _i_RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_VendNum", _i_VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_CustNum", _i_CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_OperNum", _i_OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TestSeq", _i_TestSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_RowPointer", _o_RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_RowPointer = _o_RowPointer;
				Infobar = _Infobar;
				
				return (Severity, o_RowPointer, Infobar);
			}
		}
	}
}
