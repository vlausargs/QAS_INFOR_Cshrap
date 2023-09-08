//PROJECT NAME: Production
//CLASS NAME: ApsMessageString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMessageString : IApsMessageString
	{
		readonly IApplicationDB appDB;
		
		public ApsMessageString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsMessageStringFn(
			int? MsgID,
			string Parm1,
			string Parm2,
			string Parm3,
			string Parm4)
		{
			ApsIntType _MsgID = MsgID;
			ApsMsgParmType _Parm1 = Parm1;
			ApsMsgParmType _Parm2 = Parm2;
			ApsMsgParmType _Parm3 = Parm3;
			ApsMsgParmType _Parm4 = Parm4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsMessageString](@MsgID, @Parm1, @Parm2, @Parm3, @Parm4)";
				
				appDB.AddCommandParameter(cmd, "MsgID", _MsgID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm1", _Parm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2", _Parm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm3", _Parm3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm4", _Parm4, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
