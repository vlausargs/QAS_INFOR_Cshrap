using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Data;
using CSI.Logger;
using CSI.MG.MGCore;
using System;
using CSI.Interfaces.Data;

namespace CSI.MG
{
    public class MGCoreFeatures : IMongooseDependencies
    {
        IBunchedLoadCollection bunchedLoadCollection;
        ICommandExecutor commandExecutor;
        ICommandParameters commandParameters;
        ICommandProvider commandProvider;
        ILiteralProvider literalProvider;
        ILogger logger;
        IMessageProvider messageProvider;
        IMGBunchedRequest mgBunchedRequest;
        IParameterProvider parameterProvider;
        IProcessVariableProvider processVariableProvider;
        IFileServer fileServer;
        private IApplicationEvent mgApplicationEvent;
        private IEmail mgEmail;

        readonly ICSIExtensionClassBase csiExtensionClassBase;
        public MGCoreFeatures(ICSIExtensionClassBase csiExtensionClassBase)
        {
            this.csiExtensionClassBase = csiExtensionClassBase;
        }

        public ILogger MGLogger
        {
            get
            {
                if (this.logger == null)
                    logger = new MGLogger();
                return logger;
            }
        }
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IParameterProvider SQLParameterProvider
        {
            get
            {
                if (this.parameterProvider == null)
                    parameterProvider = new SQLParameterProvider();
                return parameterProvider;
            }
        }
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISQLBulkCopyFactory SQLBulkCopyFactory => new SQLBulkCopyFactory();
        ILoadCollectionDataBaseProvider LoadCollectionDataBaseProvider => new LoadCollectionDataBaseProvider(this.csiExtensionClassBase);
        IAppDBProvider AppDBProvider => new AppDBProvider(this.csiExtensionClassBase);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IBunchedLoadCollection BunchedLoadCollection
        {
            get
            {
                if (this.bunchedLoadCollection == null)
                    bunchedLoadCollection = new SQLBunchedLoadCollection(this.ProcessVariableProvider, this.MGBunchedRequest);
                return bunchedLoadCollection;
            }
        }

        public IProcessVariableProvider ProcessVariableProvider
        {
            get
            {
                if (this.processVariableProvider == null)
                    processVariableProvider = new ProcessVariableProvider(this.AppDBProvider);
                return processVariableProvider;
            }
        }
        public IMGBunchedRequest MGBunchedRequest
        {
            get
            {
                if (this.mgBunchedRequest == null)
                    mgBunchedRequest = new MGBunchedRequest(this.LoadCollectionDataBaseProvider);
                return mgBunchedRequest;
            }
        }
        public IMessageProvider MGMessageProvider
        {
            get
            {
                if (this.messageProvider == null)
                    messageProvider = new MGMessageProvider(this.csiExtensionClassBase);
                return messageProvider;
            }
        }
        public ILiteralProvider MGLiteralProvider
        {
            get
            {
                if (literalProvider == null)
                    literalProvider = new MGLiteralProvider();
                return literalProvider;
            }
        }
        public ICommandExecutor MGCommandExecutor
        {
            get
            {
                if (commandExecutor == null)
                    commandExecutor = new MGCommandExecutor(this.AppDBProvider, this.MGCommandParameters);
                return commandExecutor;
            }
        }
        public ICommandParameters MGCommandParameters
        {
            get
            {
                if (commandParameters == null)
                    commandParameters = new MGCommandParameters(this.AppDBProvider);
                return commandParameters;
            }
        }
        public ICommandProvider MGCommandProvider
        {
            get
            {
                if (commandProvider == null)
                    commandProvider = new MGCommandProvider(this.AppDBProvider);
                return commandProvider;
            }
        }

        public IUserPrincipal UserPrincipal => new UserPrincipal();
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IAddProcessErrorLog AddProcessErrorLog => new AddProcessErrorLogFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IAllSitesSameDb AllSitesSameDb => new AllSitesSameDbFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IAndSqlWhere AndSqlWhere => new AndSqlWhereFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IAnticipateSessionIdentity AnticipateSessionIdentity => new AnticipateSessionIdentityFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IApplyDateOffset ApplyDateOffset => new ApplyDateOffsetFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IBGTaskSubmit BGTaskSubmit => new BGTaskSubmitFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IBuildXMLFilterString BuildXMLFilterString => new BuildXMLFilterStringFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICanAny CanAny => new CanAnyFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICloseSession CloseSession => new CloseSessionFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICloseSessionContext CloseSessionContext => new CloseSessionContextFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICopySessionVariables CopySessionVariables => new CopySessionVariablesFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICopyUetColumns CopyUetColumns => new CopyUetColumnsFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICreateSpecificNote CreateSpecificNote => new CreateSpecificNoteFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICstr Cstr => new CstrFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ICU_Notes CU_Notes => new CU_NotesFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDayEndOf DayEndOf => new DayEndOfFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDefaultToLocalSite DefaultToLocalSite => new DefaultToLocalSiteFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDefinedValue DefinedValue => new DefinedValueFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public IDefineProcessVariable DefineProcessVariable => new DefineProcessVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDefineVariable DefineVariable => new DefineVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDefineVariableBySessionId DefineVariableBySessionId => new DefineVariableBySessionIdFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDoubleQuote DoubleQuote => new DoubleQuoteFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IEntry Entry => new EntryFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IExecuteDynamicSQL ExecuteDynamicSQL => new ExecuteDynamicSQLFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.BunchedLoadCollection, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IFireEvent FireEvent => new FireEventFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IFireGenericNotify FireGenericNotify => new FireGenericNotifyFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetLabel GetLabel => new GetLabelFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public IGetLabel GetLabelCache => new GetLabelCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetProcessVariable GetProcessVariable => new GetProcessVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetReplicationCounter GetReplicationCounter => new GetReplicationCounterFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetSiteContext GetSiteContext => new GetSiteContextFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetSiteDate GetSiteDate => new GetSiteDateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetStringValue GetStringValue => new GetStringValueFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetUserPrivileges GetUserPrivileges => new GetUserPrivilegesFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetVariable GetVariable => new GetVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public IHighCharacter HighCharacter => new HighCharacterFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IHighCharacter HighCharacterCache => new HighCharacterCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public IHighDate HighDate => new HighDateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IHighDate HighDateCache => new HighDateCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public IHighString HighString => new HighStringFactory().Create(this.csiExtensionClassBase);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IHighString HighStringCache => new HighStringCacheFactory().Create(this.csiExtensionClassBase);
        public IHighInt HighInt => new HighIntFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IHighInt HighIntCache => new HighIntCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IInitSessionContext InitSessionContext => new InitSessionContextFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IInitSessionContextWithUser InitSessionContextWithUser => new InitSessionContextWithUserFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IInsertEventInputParameter InsertEventInputParameter => new InsertEventInputParameterFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IInterpretText InterpretText => new InterpretTextFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IIsInteger IsInteger => new IsIntegerFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public ILowCharacter LowCharacter => new LowCharacterFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ILowCharacter LowCharacterCache => new LowCharacterCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public ILowString LowString => new LowStringFactory().Create(this.csiExtensionClassBase);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ILowString LowStringCache => new LowStringCacheFactory().Create(this.csiExtensionClassBase);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IAssemblyLoader AssemblyLoader => new CSI.MG.MGCore.AssemblyLoader();
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IMidnightOf MidnightOf => new MidnightOfFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IMinDate MinDate => new MinDateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IMsgAppFunction MsgAppFunction => new MsgAppFunctionFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IMsgAsk MsgAsk => new MsgAskFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IMsgPre MsgPre => new MsgPreFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public INextKey NextKey => new NextKeyFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public INotifyPublicationSubscribers NotifyPublicationSubscribers => new NotifyPublicationSubscribersFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IPrefixOnly PrefixOnly => new PrefixOnlyFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IRemoteInfobarSave RemoteInfobarSave => new RemoteInfobarSaveFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IRemoteMethodForReplicationTargets RemoteMethodForReplicationTargets => new RemoteMethodForReplicationTargetsFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.BunchedLoadCollection, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IResetSessionID ResetSessionID => new ResetSessionIDFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IRestoreTriggerState RestoreTriggerState => new RestoreTriggerStateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IRetrieveSessionIdentity RetrieveSessionIdentity => new RetrieveSessionIdentityFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISessionID SessionID => new SessionIDFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISetNextKey SetNextKey => new SetNextKeyFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISetSite SetSite => new SetSiteFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISetTriggerState SetTriggerState => new SetTriggerStateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public ISplitString SplitString => new SplitStringFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.BunchedLoadCollection, this.csiExtensionClassBase.ParameterProvider, new Data.Utilities.DataTableUtil(new Data.Functions.SQLExpressionExecutorFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.ParameterProvider)), true);
        public IStringLines StringLines => new StringLinesFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.BunchedLoadCollection, this.csiExtensionClassBase.ParameterProvider, new Data.Utilities.DataTableUtil(new Data.Functions.SQLExpressionExecutorFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.ParameterProvider)), true);
        public IStringOf StringOf => new StringOfFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IStringOf StringOfCache => new StringOfCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ITransferNotesToSite TransferNotesToSite => new TransferNotesToSiteFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IUndefineVariable UndefineVariable => new UndefineVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IUndefineVariableBySessionId UndefineVariableBySessionId => new UndefineVariableBySessionIdFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public string UserName => csiExtensionClassBase.UserName;
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IUserName2 UserName2 => new UserName2Factory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IUserNameBySessionId UserNameBySessionId => new UserNameBySessionIdFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IVariableIsDefined VariableIsDefined => new VariableIsDefinedFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IVariableIsDefinedBySessionId VariableIsDefinedBySessionId => new VariableIsDefinedBySessionIdFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IWBPerGet WBPerGet => new WBPerGetFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public ILowInt LowInt => new LowIntFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ILowInt LowIntCache => new LowIntCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        public ILowDate LowDate => new LowDateFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ILowDate LowDateCache => new LowDateCacheFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IGetIsolationLevel GetIsolationLevel => new GetIsolationLevelFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IUndefineProcessVariable UndefineProcessVariable => new UndefineProcessVariableFactory().Create(this.csiExtensionClassBase.AppDB, this.csiExtensionClassBase.MGInvoker, this.csiExtensionClassBase.ParameterProvider, true);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public ISqlFilter SqlFilter => new SqlFilterFactory().Create(csiExtensionClassBase);
        [Obsolete("Please use CompositionRoot to create instance.")]
        public IDefinedValueBySessionId DefinedValueBySessionId => new DefinedValueBySessionIdFactory().Create(csiExtensionClassBase);

        public IFileServer FileServer => fileServer ?? (fileServer = new FileServer());

        public IApplicationEvent MGApplicationEvent => mgApplicationEvent ?? (mgApplicationEvent = new MGApplicationEvent(csiExtensionClassBase));

        public IEmail MGEmail => mgEmail ?? (mgEmail = new MGEmail(MGApplicationEvent));
    }
}

