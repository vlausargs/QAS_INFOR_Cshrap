//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAccountUnitCodeList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSAccountUnitCodeList
	{
		int CHSAccountUnitCodeListSp(string DataType);
	}
	
	public class CHSAccountUnitCodeList : ICHSAccountUnitCodeList
	{
		readonly IApplicationDB appDB;
		
		public CHSAccountUnitCodeList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CHSAccountUnitCodeListSp(string DataType)
		{
			DeTypeType _DataType = DataType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSAccountUnitCodeListSp";
				
				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
