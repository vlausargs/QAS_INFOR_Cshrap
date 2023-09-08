using CSI.Data;
using CSI.Data.SQL;
using CSI.Interfaces.Data;
using CSI.MG.MGCore;

namespace CSI.MG
{
    public interface IMongooseDependencies
    {
        ILogger MGLogger { get; }
        IParameterProvider SQLParameterProvider { get; }
        ISQLBulkCopyFactory SQLBulkCopyFactory { get; }
        IBunchedLoadCollection BunchedLoadCollection { get; }
        IProcessVariableProvider ProcessVariableProvider { get; }
        IMGBunchedRequest MGBunchedRequest { get; }
        IMessageProvider MGMessageProvider { get; }
        ILiteralProvider MGLiteralProvider { get; }
        ICommandExecutor MGCommandExecutor { get; }
        ICommandParameters MGCommandParameters { get; }
        ICommandProvider MGCommandProvider { get; }
        IUserPrincipal UserPrincipal { get; }
        IAddProcessErrorLog AddProcessErrorLog { get; }
        IAllSitesSameDb AllSitesSameDb { get; }
        IAndSqlWhere AndSqlWhere { get; }
        IAnticipateSessionIdentity AnticipateSessionIdentity { get; }
        IApplyDateOffset ApplyDateOffset { get; }
        IBGTaskSubmit BGTaskSubmit { get; }
        IBuildXMLFilterString BuildXMLFilterString { get; }
        ICanAny CanAny { get; }
        ICloseSession CloseSession { get; }
        ICloseSessionContext CloseSessionContext { get; }
        ICopySessionVariables CopySessionVariables { get; }
        ICopyUetColumns CopyUetColumns { get; }
        ICreateSpecificNote CreateSpecificNote { get; }
        ICstr Cstr { get; }
        ICU_Notes CU_Notes { get; }
        IDayEndOf DayEndOf { get; }
        IDefaultToLocalSite DefaultToLocalSite { get; }
        IDefinedValue DefinedValue { get; }
        IDefineProcessVariable DefineProcessVariable { get; }
        IDefineVariable DefineVariable { get; }
        IDefineVariableBySessionId DefineVariableBySessionId { get; }
        IDoubleQuote DoubleQuote { get; }
        IEntry Entry { get; }
        IExecuteDynamicSQL ExecuteDynamicSQL { get; }
        IFireEvent FireEvent { get; }
        IFireGenericNotify FireGenericNotify { get; }
        IGetLabel GetLabel { get; }
        IGetLabel GetLabelCache { get; }
        IGetProcessVariable GetProcessVariable { get; }
        IGetReplicationCounter GetReplicationCounter { get; }
        IGetSiteContext GetSiteContext { get; }
        IGetSiteDate GetSiteDate { get; }
        IGetStringValue GetStringValue { get; }
        IGetUserPrivileges GetUserPrivileges { get; }
        IGetVariable GetVariable { get; }
        IHighCharacter HighCharacter { get; }
        IHighCharacter HighCharacterCache { get; }
        IHighDate HighDate { get; }
        IHighDate HighDateCache { get; }
        IHighInt HighInt { get; }
        IHighInt HighIntCache { get; }
        IHighString HighString { get; }
        IHighString HighStringCache { get; }
        IInitSessionContext InitSessionContext { get; }
        IInitSessionContextWithUser InitSessionContextWithUser { get; }
        IInsertEventInputParameter InsertEventInputParameter { get; }
        IInterpretText InterpretText { get; }
        IIsInteger IsInteger { get; }
        ILowCharacter LowCharacter { get; }
        ILowCharacter LowCharacterCache { get; }
        ILowString LowString { get; }
        ILowString LowStringCache { get; }
        IAssemblyLoader AssemblyLoader { get; }
        IMidnightOf MidnightOf { get; }
        IMinDate MinDate { get; }
        IMsgAppFunction MsgAppFunction { get; }
        IMsgAsk MsgAsk { get; }
        IMsgPre MsgPre { get; }
        INextKey NextKey { get; }
        INotifyPublicationSubscribers NotifyPublicationSubscribers { get; }
        IPrefixOnly PrefixOnly { get; }
        IRemoteInfobarSave RemoteInfobarSave { get; }
        IRemoteMethodForReplicationTargets RemoteMethodForReplicationTargets { get; }
        IResetSessionID ResetSessionID { get; }
        IRestoreTriggerState RestoreTriggerState { get; }
        IRetrieveSessionIdentity RetrieveSessionIdentity { get; }
        ISessionID SessionID { get; }
        ISetNextKey SetNextKey { get; }
        ISetSite SetSite { get; }
        ISetTriggerState SetTriggerState { get; }
        ISplitString SplitString { get; }
        IStringLines StringLines { get; }
        IStringOf StringOf { get; }
        IStringOf StringOfCache { get; }
        ITransferNotesToSite TransferNotesToSite { get; }
        IUndefineVariable UndefineVariable { get; }
        IUndefineVariableBySessionId UndefineVariableBySessionId { get; }
        string UserName { get; }
        IUserName2 UserName2 { get; }
        IUserNameBySessionId UserNameBySessionId { get; }
        IVariableIsDefined VariableIsDefined { get; }
        IVariableIsDefinedBySessionId VariableIsDefinedBySessionId { get; }
        IWBPerGet WBPerGet { get; }
        ILowInt LowInt { get; }
        ILowInt LowIntCache { get; }
        ILowDate LowDate { get; }
        ILowDate LowDateCache { get; }
        IGetIsolationLevel GetIsolationLevel { get; }
        IUndefineProcessVariable UndefineProcessVariable { get; }
        ISqlFilter SqlFilter { get; }
        IDefinedValueBySessionId DefinedValueBySessionId { get; }
        IFileServer FileServer { get; }
        IApplicationEvent MGApplicationEvent { get; }
        IEmail MGEmail { get; }
    }
}
