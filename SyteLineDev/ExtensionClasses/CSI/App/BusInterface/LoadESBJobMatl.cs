//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBJobMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBJobMatl
	{
		int LoadESBJobMatlSp(string Job,
		                     short? Suffix,
		                     int? OperNum,
		                     string ActionExpression,
		                     string InputItem,
		                     decimal? InputPlanQty,
		                     string InputISOUM,
		                     string InputDescription,
		                     string InputDrawingNumber,
		                     string InputFixedQuantity,
		                     string OutputItem,
		                     decimal? OutputPlanQty,
		                     string OutputISOUM,
		                     string OutputDescription,
		                     string OutputDrawingNumber,
		                     string OutputFixedQuantity,
		                     string OutputItemType,
		                     ref string Infobar);
	}
	
	public class LoadESBJobMatl : ILoadESBJobMatl
	{
		readonly IApplicationDB appDB;
		
		public LoadESBJobMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBJobMatlSp(string Job,
		                            short? Suffix,
		                            int? OperNum,
		                            string ActionExpression,
		                            string InputItem,
		                            decimal? InputPlanQty,
		                            string InputISOUM,
		                            string InputDescription,
		                            string InputDrawingNumber,
		                            string InputFixedQuantity,
		                            string OutputItem,
		                            decimal? OutputPlanQty,
		                            string OutputISOUM,
		                            string OutputDescription,
		                            string OutputDrawingNumber,
		                            string OutputFixedQuantity,
		                            string OutputItemType,
		                            ref string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			StringType _ActionExpression = ActionExpression;
			ItemType _InputItem = InputItem;
			QtyPerType _InputPlanQty = InputPlanQty;
			UMType _InputISOUM = InputISOUM;
			DescriptionType _InputDescription = InputDescription;
			DrawingNbrType _InputDrawingNumber = InputDrawingNumber;
			StringType _InputFixedQuantity = InputFixedQuantity;
			ItemType _OutputItem = OutputItem;
			QtyPerType _OutputPlanQty = OutputPlanQty;
			UMType _OutputISOUM = OutputISOUM;
			DescriptionType _OutputDescription = OutputDescription;
			DrawingNbrType _OutputDrawingNumber = OutputDrawingNumber;
			StringType _OutputFixedQuantity = OutputFixedQuantity;
			StringType _OutputItemType = OutputItemType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBJobMatlSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputItem", _InputItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputPlanQty", _InputPlanQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputISOUM", _InputISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputDescription", _InputDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputDrawingNumber", _InputDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InputFixedQuantity", _InputFixedQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputItem", _OutputItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputPlanQty", _OutputPlanQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputISOUM", _OutputISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputDescription", _OutputDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputDrawingNumber", _OutputDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputFixedQuantity", _OutputFixedQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputItemType", _OutputItemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
