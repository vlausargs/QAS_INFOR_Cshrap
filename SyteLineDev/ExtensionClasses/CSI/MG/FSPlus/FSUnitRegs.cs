//PROJECT NAME: FSPlusExt
//CLASS NAME: FSUnitRegs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSUnitRegs")]
    public class FSUnitRegs : ExtensionClassBase, IFSUnitRegs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSUnitRegistrationPostingSP(decimal? TransNum,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSUnitRegistrationPostingExt = new SSSFSUnitRegistrationPostingFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSUnitRegistrationPostingExt.SSSFSUnitRegistrationPostingSP(TransNum,
                                                                                               ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalValidateUnitRegSp(string SerNum,
		                                        string Item,
		                                        string Name,
		                                        string Addr1,
		                                        string City,
		                                        string State,
		                                        string Zip,
		                                        string Country,
		                                        string Phone,
		                                        string Email,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalValidateUnitRegExt = new SSSFSPortalValidateUnitRegFactory().Create(appDb);
				
				int Severity = iSSSFSPortalValidateUnitRegExt.SSSFSPortalValidateUnitRegSp(SerNum,
				                                                                           Item,
				                                                                           Name,
				                                                                           Addr1,
				                                                                           City,
				                                                                           State,
				                                                                           Zip,
				                                                                           Country,
				                                                                           Phone,
				                                                                           Email,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSCLM_SearchForRegistrationPostingSp(decimal? TransNum,
		                                                         [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSCLM_SearchForRegistrationPostingExt = new SSSFSCLM_SearchForRegistrationPostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSCLM_SearchForRegistrationPostingExt.SSSFSCLM_SearchForRegistrationPostingSp(TransNum,
				                                                                                               FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalCreateUnitRegSp(string SerNum,
		                                      string Item,
		                                      string Name,
		                                      string Addr1,
		                                      string Addr2,
		                                      string Addr3,
		                                      string Addr4,
		                                      string City,
		                                      string State,
		                                      string Zip,
		                                      string Country,
		                                      string Phone,
		                                      string Email,
		                                      string RegNotes,
		                                      [Optional, DefaultParameterValue((byte)0)] byte? Validate,
		ref string TransNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalCreateUnitRegExt = new SSSFSPortalCreateUnitRegFactory().Create(appDb);
				
				var result = iSSSFSPortalCreateUnitRegExt.SSSFSPortalCreateUnitRegSp(SerNum,
				                                                                     Item,
				                                                                     Name,
				                                                                     Addr1,
				                                                                     Addr2,
				                                                                     Addr3,
				                                                                     Addr4,
				                                                                     City,
				                                                                     State,
				                                                                     Zip,
				                                                                     Country,
				                                                                     Phone,
				                                                                     Email,
				                                                                     RegNotes,
				                                                                     Validate,
				                                                                     TransNum,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				TransNum = result.TransNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalAddConsumerSp([Optional] string Name,
		                                    [Optional] string Addr_1,
		                                    [Optional] string Addr_2,
		                                    [Optional] string Addr_3,
		                                    [Optional] string Addr_4,
		                                    [Optional] string City,
		                                    [Optional] string State,
		                                    [Optional] string Zip,
		                                    [Optional] string Country,
		                                    [Optional] string Phone,
		                                    [Optional] string Email,
		                                    ref string NewUsrNum,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalAddConsumerExt = new SSSFSPortalAddConsumerFactory().Create(appDb);
				
				var result = iSSSFSPortalAddConsumerExt.SSSFSPortalAddConsumerSp(Name,
				                                                                 Addr_1,
				                                                                 Addr_2,
				                                                                 Addr_3,
				                                                                 Addr_4,
				                                                                 City,
				                                                                 State,
				                                                                 Zip,
				                                                                 Country,
				                                                                 Phone,
				                                                                 Email,
				                                                                 NewUsrNum,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				NewUsrNum = result.NewUsrNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalAddCustomerSp([Optional] string Name,
		                                    [Optional] string Addr_1,
		                                    [Optional] string Addr_2,
		                                    [Optional] string Addr_3,
		                                    [Optional] string Addr_4,
		                                    [Optional] string City,
		                                    [Optional] string State,
		                                    [Optional] string Zip,
		                                    [Optional] string Country,
		                                    [Optional] string Phone,
		                                    [Optional] string Email,
		                                    ref string NewCustNum,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalAddCustomerExt = new SSSFSPortalAddCustomerFactory().Create(appDb);
				
				var result = iSSSFSPortalAddCustomerExt.SSSFSPortalAddCustomerSp(Name,
				                                                                 Addr_1,
				                                                                 Addr_2,
				                                                                 Addr_3,
				                                                                 Addr_4,
				                                                                 City,
				                                                                 State,
				                                                                 Zip,
				                                                                 Country,
				                                                                 Phone,
				                                                                 Email,
				                                                                 NewCustNum,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				NewCustNum = result.NewCustNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
