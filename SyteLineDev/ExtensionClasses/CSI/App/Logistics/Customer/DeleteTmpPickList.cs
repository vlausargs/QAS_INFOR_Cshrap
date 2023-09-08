//PROJECT NAME: CSICustomer
//CLASS NAME: DeleteTmpPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDeleteTmpPickList
	{
		int DeleteTmpPickListSp(Guid? ProcessID,
		                        string CoNum,
		                        short? CoLIne,
		                        short? CoRelease,
		                        ref string Infobar);
	}
	
	public class DeleteTmpPickList : IDeleteTmpPickList
	{
		readonly IApplicationDB appDB;
		
		public DeleteTmpPickList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DeleteTmpPickListSp(Guid? ProcessID,
		                               string CoNum,
		                               short? CoLIne,
		                               short? CoRelease,
		                               ref string Infobar)
		{
			RowPointerType _ProcessID = ProcessID;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLIne = CoLIne;
			CoReleaseType _CoRelease = CoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteTmpPickListSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLIne", _CoLIne, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
