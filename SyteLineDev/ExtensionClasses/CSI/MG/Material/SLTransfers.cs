//PROJECT NAME: MaterialExt
//CLASS NAME: SLTransfers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.WarehouseMobility;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTransfers")]
    public class SLTransfers : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AlloctrSp(string CurTrnNum,
                                     ref int? ProcessLevel,
                                     ref string PromptMsg,
                                     ref string PromptButtons,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAlloctrExt = new AlloctrFactory().Create(appDb);

                IntType oProcessLevel = ProcessLevel;
                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iAlloctrExt.AlloctrSp(CurTrnNum,
                                                         ref oProcessLevel,
                                                         ref oPromptMsg,
                                                         ref oPromptButtons,
                                                         ref oInfobar);

                ProcessLevel = oProcessLevel;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CpTrSp(string FTrn,
                           short? FSLine,
                           short? FELine,
                           byte? TCpCharge,
                           ref DateTime? TSchShipDate,
                           ref DateTime? TSchRcvDate,
                           ref string TTrn,
                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCpTrExt = new CpTrFactory().Create(appDb);

                DateType oTSchShipDate = TSchShipDate;
                DateType oTSchRcvDate = TSchRcvDate;
                TrnNumType oTTrn = TTrn;
                InfobarType oInfobar = Infobar;

                int Severity = iCpTrExt.CpTrSp(FTrn,
                                                      FSLine,
                                                      FELine,
                                                      TCpCharge,
                                                      ref oTSchShipDate,
                                                      ref oTSchRcvDate,
                                                      ref oTTrn,
                                                      ref oInfobar);

                TSchShipDate = oTSchShipDate;
                TSchRcvDate = oTSchRcvDate;
                TTrn = oTTrn;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetSiteInvParmsInfoSp(string Site,
                                                 ref byte? TrackTaxFreeImports,
                                                 ref string Country)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetSiteInvParmsInfoExt = new GetSiteInvParmsInfoFactory().Create(appDb);

                ListYesNoType oTrackTaxFreeImports = TrackTaxFreeImports;
                CountryType oCountry = Country;

                int Severity = iGetSiteInvParmsInfoExt.GetSiteInvParmsInfoSp(Site,
                                                                     ref oTrackTaxFreeImports,
                                                                     ref oCountry);

                TrackTaxFreeImports = oTrackTaxFreeImports;
                Country = oCountry;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTransferFobSiteSp(string FromSite,
                                                string ToSite,
                                                ref string FobSite,
                                                ref decimal? ExchRate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTransferFobSiteExt = new GetTransferFobSiteFactory().Create(appDb);

                SiteType oFobSite = FobSite;
                ExchRateType oExchRate = ExchRate;

                int Severity = iGetTransferFobSiteExt.GetTransferFobSiteSp(FromSite,
                                                                    ToSite,
                                                                    ref oFobSite,
                                                                    ref oExchRate);

                FobSite = oFobSite;
                ExchRate = oExchRate;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTransferInfoSp(string TrnNum,
                                      ref string FromSite,
                                      ref string ToSite,
                                      ref string FromWhse,
                                      ref string ToWhse,
                                      ref string Status,
                                      ref string Pricecode,
                                      ref string TransNat,
                                      ref string TransNat2,
                                      ref string Delterm,
                                      ref string ProcessInd,
                                      ref string SitenetPostingMethod,
                                      ref string EcCode,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTransferInfoExt = new GetTransferInfoFactory().Create(appDb);

                SiteType oFromSite = FromSite;
                SiteType oToSite = ToSite;
                WhseType oFromWhse = FromWhse;
                WhseType oToWhse = ToWhse;
                TransferStatusType oStatus = Status;
                PriceCodeType oPricecode = Pricecode;
                TransNatType oTransNat = TransNat;
                TransNat2Type oTransNat2 = TransNat2;
                DeltermType oDelterm = Delterm;
                ProcessIndType oProcessInd = ProcessInd;
                IntersitePostingMethodType oSitenetPostingMethod = SitenetPostingMethod;
                EcCodeType oEcCode = EcCode;
                InfobarType oInfobar = Infobar;

                int Severity = iGetTransferInfoExt.GetTransferInfoSp(TrnNum,
                                                                 ref oFromSite,
                                                                 ref oToSite,
                                                                 ref oFromWhse,
                                                                 ref oToWhse,
                                                                 ref oStatus,
                                                                 ref oPricecode,
                                                                 ref oTransNat,
                                                                 ref oTransNat2,
                                                                 ref oDelterm,
                                                                 ref oProcessInd,
                                                                 ref oSitenetPostingMethod,
                                                                 ref oEcCode,
                                                                 ref oInfobar);

                FromSite = oFromSite;
                ToSite = oToSite;
                FromWhse = oFromWhse;
                ToWhse = oToWhse;
                Status = oStatus;
                Pricecode = oPricecode;
                TransNat = oTransNat;
                TransNat2 = oTransNat2;
                Delterm = oDelterm;
                ProcessInd = oProcessInd;
                SitenetPostingMethod = oSitenetPostingMethod;
                EcCode = oEcCode;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TransferDefaultsSp(string FromSite,
                                              ref string FromWhse,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTransferDefaultsExt = new TransferDefaultsFactory().Create(appDb);

                WhseType oFromWhse = FromWhse;
                InfobarType oInfobar = Infobar;

                int Severity = iTransferDefaultsExt.TransferDefaultsSp(FromSite,
                                                                  ref oFromWhse,
                                                                  ref oInfobar);

                FromWhse = oFromWhse;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TransferExistsSp(string TrnNum,
                                            string Item,
                                            ref string FromSite,
                                            ref string FromWhse,
                                            ref string ToSite,
                                            ref string ToWhse,
                                            ref byte? TransferExists,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iTransferExistsExt = new TransferExistsFactory().Create(appDb);

                SiteType oFromSite = FromSite;
                WhseType oFromWhse = FromWhse;
                SiteType oToSite = ToSite;
                WhseType oToWhse = ToWhse;
                FlagNyType oTransferExists = TransferExists;
                InfobarType oInfobar = Infobar;

                int Severity = iTransferExistsExt.TransferExistsSp(TrnNum,
                                                                Item,
                                                                ref oFromSite,
                                                                ref oFromWhse,
                                                                ref oToSite,
                                                                ref oToWhse,
                                                                ref oTransferExists,
                                                                ref oInfobar);

                FromSite = oFromSite;
                FromWhse = oFromWhse;
                ToSite = oToSite;
                ToWhse = oToWhse;
                TransferExists = oTransferExists;
                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateTargetTrnNumForCopySp(string TargetTrnNum,
                                                         string SourceTrnNum,
                                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateTargetTrnNumForCopyExt = new ValidateTargetTrnNumForCopyFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iValidateTargetTrnNumForCopyExt.ValidateTargetTrnNumForCopySp(TargetTrnNum,
                                                                             SourceTrnNum,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Whse02RPreSp(string BegTrnNum,
                                        string EndTrnNum,
                                        DateTime? PostDate,
                                        byte? PostMatlIssues,
                                        ref string PromptMsg,
                                        ref string PromptButtons,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWhse02RPreExt = new Whse02RPreFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iWhse02RPreExt.Whse02RPreSp(BegTrnNum,
                                                            EndTrnNum,
                                                            PostDate,
                                                            PostMatlIssues,
                                                            ref oPromptMsg,
                                                            ref oPromptButtons,
                                                            ref oInfobar);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TrpurgeSp(string SiteGroup,
		                     string BegTrnNum,
		                     string EndTrnNum,
		                     string BegFromWhse,
		                     string EndFromWhse,
		                     string BegToWhse,
		                     string EndToWhse,
		                     [Optional] DateTime? OrderDateStarting,
		                     [Optional] DateTime? OrderDateEnding,
		                     [Optional] short? OrderStartingOffset,
		                     [Optional] short? OrderEndingOffset,
		                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTrpurgeExt = new TrpurgeFactory().Create(appDb);
				
				var result = iTrpurgeExt.TrpurgeSp(SiteGroup,
				                                   BegTrnNum,
				                                   EndTrnNum,
				                                   BegFromWhse,
				                                   EndFromWhse,
				                                   BegToWhse,
				                                   EndToWhse,
				                                   OrderDateStarting,
				                                   OrderDateEnding,
				                                   OrderStartingOffset,
				                                   OrderEndingOffset,
				                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateSourceTrnNumForCopySp(string SourceTrnNum,
		                                         ref short? StartLineNum,
		                                         ref short? EndLineNum,
		                                         ref string Infobar,
		                                         [Optional] ref string FromSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateSourceTrnNumForCopyExt = new ValidateSourceTrnNumForCopyFactory().Create(appDb);
				
				var result = iValidateSourceTrnNumForCopyExt.ValidateSourceTrnNumForCopySp(SourceTrnNum,
				                                                                           StartLineNum,
				                                                                           EndLineNum,
				                                                                           Infobar,
				                                                                           FromSite);
				
				int Severity = result.ReturnCode.Value;
				StartLineNum = result.StartLineNum;
				EndLineNum = result.EndLineNum;
				Infobar = result.Infobar;
				FromSite = result.FromSite;
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextTrnSp(string Context,
		string Prefix,
		int? KeyLength,
		ref string Key,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextTrnExt = new NextTrnFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextTrnExt.NextTrnSp(Context,
				Prefix,
				KeyLength,
				Key,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransNextKeyDelSp(string TrnNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransNextKeyDelExt = new TransNextKeyDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransNextKeyDelExt.TransNextKeyDelSp(TrnNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CpTSp(string FTrn,
		string FromParmsSite,
		string TTransferFromSite,
		string TTransferToSite,
		int? FSLine,
		int? FELine,
		int? TCpCharge,
		ref DateTime? TSchShipDate,
		ref DateTime? TSchRcvDate,
		ref string TTrn,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCpTExt = new CpTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCpTExt.CpTSp(FTrn,
				FromParmsSite,
				TTransferFromSite,
				TTransferToSite,
				FSLine,
				FELine,
				TCpCharge,
				TSchShipDate,
				TSchRcvDate,
				TTrn,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TSchShipDate = result.TSchShipDate;
				TSchRcvDate = result.TSchRcvDate;
				TTrn = result.TTrn;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateTrnPickHeaderSp(string PTrnNum,
		string PToSite,
		string PFromWhse,
		string PToWhse,
		string PTransStatT,
		string PTransStatC,
		decimal? PWeight,
		int? PQtyPackages,
		string PShipCode,
		DateTime? PPackDate,
		string PLineStatT,
		string PLineStatC,
		int? PBegTrnLine,
		int? PEndTrnLine,
		DateTime? PBegDueDate,
		DateTime? PEndDueDate,
		int? DoLines,
		ref int? PackNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateTrnPickHeaderExt = new CreateTrnPickHeaderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateTrnPickHeaderExt.CreateTrnPickHeaderSp(PTrnNum,
				PToSite,
				PFromWhse,
				PToWhse,
				PTransStatT,
				PTransStatC,
				PWeight,
				PQtyPackages,
				PShipCode,
				PPackDate,
				PLineStatT,
				PLineStatC,
				PBegTrnLine,
				PEndTrnLine,
				PBegDueDate,
				PEndDueDate,
				DoLines,
				PackNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PackNum = result.PackNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
