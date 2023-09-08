//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCProcess")]
	public class RS_QCProcess : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CanCloseProcessSp(string flow_num,
		ref string can_close)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CanCloseProcessExt = new RSQC_CanCloseProcessFactory().Create(appDb);
				
				var result = iRSQC_CanCloseProcessExt.RSQC_CanCloseProcessSp(flow_num,
				can_close);
				
				int Severity = result.ReturnCode.Value;
				can_close = result.can_close;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefCMRDataSp(string i_cmr,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefCMRDataExt = new RSQC_GetXrefCMRDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefCMRDataExt.RSQC_GetXrefCMRDataSp(i_cmr,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefCODataSp(string i_co,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefCODataExt = new RSQC_GetXrefCODataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefCODataExt.RSQC_GetXrefCODataSp(i_co,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefCustomerDataSp(string i_custnum,
		int? i_custseq,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefCustomerDataExt = new RSQC_GetXrefCustomerDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefCustomerDataExt.RSQC_GetXrefCustomerDataSp(i_custnum,
				i_custseq,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefEstimateDataSp(string i_co,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefEstimateDataExt = new RSQC_GetXrefEstimateDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefEstimateDataExt.RSQC_GetXrefEstimateDataSp(i_co,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefEstimateJobDataSp(string i_job,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefEstimateJobDataExt = new RSQC_GetXrefEstimateJobDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefEstimateJobDataExt.RSQC_GetXrefEstimateJobDataSp(i_job,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefItemDataSp(string i_item,
			ref string o_desc,
			ref string Infobar)
		{
			var iRSQC_GetXrefItemDataExt = this.GetService<IRSQC_GetXrefItemData>();
			
			var result = iRSQC_GetXrefItemDataExt.RSQC_GetXrefItemDataSp(i_item,
				o_desc,
				Infobar);
			
			o_desc = result.o_desc;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefJobDataSp(string i_job,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefJobDataExt = new RSQC_GetXrefJobDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefJobDataExt.RSQC_GetXrefJobDataSp(i_job,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefMRRDataSp(string i_mrr,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefMRRDataExt = new RSQC_GetXrefMRRDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefMRRDataExt.RSQC_GetXrefMRRDataSp(i_mrr,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefPODataSp(string i_po,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefPODataExt = new RSQC_GetXrefPODataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefPODataExt.RSQC_GetXrefPODataSp(i_po,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefProdCodeDataSp(string i_prodcode,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefProdCodeDataExt = new RSQC_GetXrefProdCodeDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefProdCodeDataExt.RSQC_GetXrefProdCodeDataSp(i_prodcode,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefProjectDataSp(string i_proj,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefProjectDataExt = new RSQC_GetXrefProjectDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefProjectDataExt.RSQC_GetXrefProjectDataSp(i_proj,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefTRRDataSp(string i_trr,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefTRRDataExt = new RSQC_GetXrefTRRDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefTRRDataExt.RSQC_GetXrefTRRDataSp(i_trr,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetXrefVendorDataSp(string i_vendnum,
		ref string o_desc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetXrefVendorDataExt = new RSQC_GetXrefVendorDataFactory().Create(appDb);
				
				var result = iRSQC_GetXrefVendorDataExt.RSQC_GetXrefVendorDataSp(i_vendnum,
				o_desc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_desc = result.o_desc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetProjectedDateSp(string flow_num,
		ref DateTime? projected_date)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetProjectedDateExt = new RSQC_SetProjectedDateFactory().Create(appDb);
				
				var result = iRSQC_SetProjectedDateExt.RSQC_SetProjectedDateSp(flow_num,
				projected_date);
				
				int Severity = result.ReturnCode.Value;
				projected_date = result.projected_date;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_XRefChangeSp(string i_change,
		int? i_priority,
		ref int? o_change_num)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_XRefChangeExt = new RSQC_XRefChangeFactory().Create(appDb);
				
				var result = iRSQC_XRefChangeExt.RSQC_XRefChangeSp(i_change,
				i_priority,
				o_change_num);
				
				int Severity = result.ReturnCode.Value;
				o_change_num = result.o_change_num;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_XRefTopicSp(string i_topic,
		int? i_priority,
		ref int? o_topic_num)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_XRefTopicExt = new RSQC_XRefTopicFactory().Create(appDb);
				
				var result = iRSQC_XRefTopicExt.RSQC_XRefTopicSp(i_topic,
				i_priority,
				o_topic_num);
				
				int Severity = result.ReturnCode.Value;
				o_topic_num = result.o_topic_num;
				return Severity;
			}
		}
	}
}
