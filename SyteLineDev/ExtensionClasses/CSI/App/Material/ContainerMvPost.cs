//PROJECT NAME: CSIMaterial
//CLASS NAME: ContainerMvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IContainerMvPost
	{
		int ContainerMvPostSp(string ContainNum,
		                      string PType,
		                      DateTime? PDate,
		                      string FromWhse,
		                      string ToWhse,
		                      string ToLoc,
		                      byte? PZeroCost,
		                      string PStat,
		                      ref string Infobar);
	}
	
	public class ContainerMvPost : IContainerMvPost
	{
		readonly IApplicationDB appDB;
		
		public ContainerMvPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ContainerMvPostSp(string ContainNum,
		                             string PType,
		                             DateTime? PDate,
		                             string FromWhse,
		                             string ToWhse,
		                             string ToLoc,
		                             byte? PZeroCost,
		                             string PStat,
		                             ref string Infobar)
		{
			ContainerNumType _ContainNum = ContainNum;
			DefaultCharType _PType = PType;
			DateType _PDate = PDate;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			ListYesNoType _PZeroCost = PZeroCost;
			SerialStatusType _PStat = PStat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ContainerMvPostSp";
				
				appDB.AddCommandParameter(cmd, "ContainNum", _ContainNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PZeroCost", _PZeroCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStat", _PStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
