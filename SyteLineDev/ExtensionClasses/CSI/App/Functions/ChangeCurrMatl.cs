//PROJECT NAME: Data
//CLASS NAME: ChangeCurrMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeCurrMatl : IChangeCurrMatl
	{
		readonly IApplicationDB appDB;
		
		public ChangeCurrMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Description,
			string MatlType,
			string UM,
			int? Backflush,
			string RefType,
			string Infobar) ChangeCurrMatlSp(
			string Item,
			string PreqJob,
			string Description,
			string MatlType,
			string UM,
			int? Backflush,
			string RefType,
			string Infobar)
		{
			ItemType _Item = Item;
			JobType _PreqJob = PreqJob;
			DescriptionType _Description = Description;
			MatlTypeType _MatlType = MatlType;
			UMType _UM = UM;
			ListYesNoType _Backflush = Backflush;
			RefTypeIJPRTType _RefType = RefType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeCurrMatlSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqJob", _PreqJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				MatlType = _MatlType;
				UM = _UM;
				Backflush = _Backflush;
				RefType = _RefType;
				Infobar = _Infobar;
				
				return (Severity, Description, MatlType, UM, Backflush, RefType, Infobar);
			}
		}
	}
}
