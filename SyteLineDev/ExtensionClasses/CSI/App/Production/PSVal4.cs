//PROJECT NAME: Production
//CLASS NAME: PSVal4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSVal4
	{
		(int? ReturnCode, int? OperNum, string Infobar) PSVal4Sp(string PSNum,
		string PSItem,
		string Wc,
		byte? Cmpl = (byte)0,
		int? OperNum = null,
		string Infobar = null
            );
	}
	
	public class PSVal4 : IPSVal4
	{
		readonly IApplicationDB appDB;
		
		public PSVal4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OperNum, string Infobar) PSVal4Sp(string PSNum,
		string PSItem,
		string Wc,
		byte? Cmpl = (byte)0,
		int? OperNum = null,
		string Infobar = null
        )
		{
			PsNumType _PSNum = PSNum;
			ItemType _PSItem = PSItem;
			WcType _Wc = Wc;
			FlagNyType _Cmpl = Cmpl;
			OperNumType _OperNum = OperNum;
			InfobarType _Infobar = Infobar;
            
            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSVal4Sp";
				
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSItem", _PSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cmpl", _Cmpl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);				

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperNum = _OperNum;
				Infobar = _Infobar;
				
				return (Severity, OperNum, Infobar);
			}
		}
	}
}
