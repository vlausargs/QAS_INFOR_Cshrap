//PROJECT NAME: Production
//CLASS NAME: CreateJobCompEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreateJobCompEsig : ICreateJobCompEsig
	{
		readonly IApplicationDB appDB;
		
		
		public CreateJobCompEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? EsigRowpointer) CreateJobCompEsigSp(string UserName,
		string ReasonCode,
		string Job,
		string Suffix,
		string Item,
		string OperNum,
		string Qty,
		string Loc,
		string ContainerNum = null,
		string Lot = null,
		string Project = null,
		Guid? EsigRowpointer = null)
		{
			ElectronicSignatureColumnValueType _UserName = UserName;
			ElectronicSignatureColumnValueType _ReasonCode = ReasonCode;
			ElectronicSignatureColumnValueType _Job = Job;
			ElectronicSignatureColumnValueType _Suffix = Suffix;
			ElectronicSignatureColumnValueType _Item = Item;
			ElectronicSignatureColumnValueType _OperNum = OperNum;
			ElectronicSignatureColumnValueType _Qty = Qty;
			ElectronicSignatureColumnValueType _Loc = Loc;
			ElectronicSignatureColumnValueType _ContainerNum = ContainerNum;
			ElectronicSignatureColumnValueType _Lot = Lot;
			ElectronicSignatureColumnValueType _Project = Project;
			RowPointerType _EsigRowpointer = EsigRowpointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateJobCompEsigSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Project", _Project, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRowpointer", _EsigRowpointer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EsigRowpointer = _EsigRowpointer;
				
				return (Severity, EsigRowpointer);
			}
		}
	}
}
