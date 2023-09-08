//PROJECT NAME: Production
//CLASS NAME: PP_InsertMaterialUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_InsertMaterialUsage : IPP_InsertMaterialUsage
	{
		readonly IApplicationDB appDB;
		
		
		public PP_InsertMaterialUsage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PP_InsertMaterialUsageSp(string Job = null,
		int? Suffix = null,
		int? Oper_num = null,
		int? Sequence = null,
		string Item = null,
		decimal? Length = null,
		decimal? Width = null,
		decimal? Height = null,
		int? Number_of_joints = null,
		int? Use_for_matching_criteria = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Oper_num = Oper_num;
			JobmatlSequenceType _Sequence = Sequence;
			ItemType _Item = Item;
			PP_OperationDimensionType _Length = Length;
			PP_OperationDimensionType _Width = Width;
			PP_OperationDimensionType _Height = Height;
			PP_NumberOfJointsType _Number_of_joints = Number_of_joints;
			ListYesNoType _Use_for_matching_criteria = Use_for_matching_criteria;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_InsertMaterialUsageSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Oper_num", _Oper_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Length", _Length, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Width", _Width, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Height", _Height, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Number_of_joints", _Number_of_joints, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Use_for_matching_criteria", _Use_for_matching_criteria, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
