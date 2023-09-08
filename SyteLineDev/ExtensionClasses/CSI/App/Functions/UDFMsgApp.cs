//PROJECT NAME: Data
//CLASS NAME: UDFMsgApp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UDFMsgApp : IUDFMsgApp
	{
		readonly IApplicationDB appDB;
		
		public UDFMsgApp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string UDFMsgAppFn(
			string Infobar,
			string BaseMsg,
			string Parm1 = "",
			string Parm2 = "",
			string Parm3 = "",
			string Parm4 = "",
			string Parm5 = "",
			string Parm6 = "",
			string Parm7 = "",
			string Parm8 = "",
			string Parm9 = "",
			string Parm10 = "",
			string Parm11 = "",
			string Parm12 = "",
			string Parm13 = "",
			string Parm14 = "",
			string Parm15 = "")
		{
			InfobarType _Infobar = Infobar;
			InfobarType _BaseMsg = BaseMsg;
			InfobarType _Parm1 = Parm1;
			InfobarType _Parm2 = Parm2;
			InfobarType _Parm3 = Parm3;
			InfobarType _Parm4 = Parm4;
			InfobarType _Parm5 = Parm5;
			InfobarType _Parm6 = Parm6;
			InfobarType _Parm7 = Parm7;
			InfobarType _Parm8 = Parm8;
			InfobarType _Parm9 = Parm9;
			InfobarType _Parm10 = Parm10;
			InfobarType _Parm11 = Parm11;
			InfobarType _Parm12 = Parm12;
			InfobarType _Parm13 = Parm13;
			InfobarType _Parm14 = Parm14;
			InfobarType _Parm15 = Parm15;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UDFMsgApp](@Infobar, @BaseMsg, @Parm1, @Parm2, @Parm3, @Parm4, @Parm5, @Parm6, @Parm7, @Parm8, @Parm9, @Parm10, @Parm11, @Parm12, @Parm13, @Parm14, @Parm15)";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseMsg", _BaseMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm1", _Parm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2", _Parm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm3", _Parm3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm4", _Parm4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm5", _Parm5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm6", _Parm6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm7", _Parm7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm8", _Parm8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm9", _Parm9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm10", _Parm10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm11", _Parm11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm12", _Parm12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm13", _Parm13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm14", _Parm14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm15", _Parm15, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
