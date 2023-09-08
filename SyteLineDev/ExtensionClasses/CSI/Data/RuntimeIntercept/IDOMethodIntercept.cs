using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSI.Data
{
    
    public class IDOMethodIntercept<T> : DispatchProxy
    {
        T decorated;
        string IDO;
        string Method;
        IMGInvoker mgInvoker;
        IInterceptConfiguration interceptConfiguration;

        /// <summary>
        /// This is the internal construction method called by the factory method Create()
        /// </summary>
        private void Constructor(T decorated, string IDO, string Method, IMGInvoker mgInvoker, IInterceptConfiguration interceptConfiguration)
        {
            // The parameters of this method are what would be passed to a constructor

            if (decorated == null)
                throw new ArgumentNullException(nameof(decorated));

            this.decorated = decorated;
            this.IDO = IDO;
            this.Method = Method;
            this.mgInvoker = mgInvoker;
            this.interceptConfiguration = interceptConfiguration;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try { 
            if (!interceptConfiguration.InterceptEnabled(IDO, Method))
            {
                var result = targetMethod.Invoke(decorated, args);
                return result;
            }
            if (targetMethod.ReturnType == typeof(int))
            {
                return _callStandardIDOMethod(IDO, Method, args);
            }
            else if (targetMethod.ReturnType == typeof(DataTable))
            {
                return _callCustomLoadIDOMethod(IDO, Method, args);
            }
            else if (targetMethod.ReturnType.Name.StartsWith("ValueTuple"))
            {
                var returnTupleFieldTypes = EnumerateTupleFieldTypes(targetMethod.ReturnType);

                //mongoose methods must return either an int or a DataTable, so we can't intercept this one because it doesn't have a return type
                if (returnTupleFieldTypes.Count() < 1 || returnTupleFieldTypes.First() == typeof(void))
                    throw new Exception(string.Format($"Missing or void return type"));
                //mongoose methods must return either an int or a DataTable, so we can't intercept this one because it doesn't have a one of those return types

                Type firstTypeInTheTuple = returnTupleFieldTypes.First();
                bool thisIsACustomLoad = firstTypeInTheTuple == typeof(ICollectionLoadResponse)
                    || firstTypeInTheTuple == typeof(DataTable);
                //create the new argument list
                int idoMethodArgCount = args.Length + returnTupleFieldTypes.Count();
                idoMethodArgCount--; //the first one remains a return value
                object[] idoMethodArgs = new object[idoMethodArgCount];
                //copy in the original arguments, the extra ones must be null because nothing was passed                
                for (int i = 0; i < args.Length; i++)
                    idoMethodArgs[i] = args[i];
                IList<object> tupleElements = null;
                if (thisIsACustomLoad == true)
                {
                    IMGLoadCollectionResponseData loadCollectionResponse
                       = mgInvoker.LoadCollection(IDO, Method, idoMethodArgs);
                    //if the return value is tuple, not sure the return value can be gotten because noParameters exists on response.
                    //Could we just ignore the ref columns for CLM method? Only focuse on the returned datatable.
                    //in most of the cases, for CLM, return code is unncessary.
                    tupleElements = new List<object>();
                    if (firstTypeInTheTuple == typeof(ICollectionLoadResponse))
                        tupleElements.Add(loadCollectionResponse.GetLoadCollectionResponseData());
                    else tupleElements.Add(loadCollectionResponse.GetReturnValueDataTable());
                    if (returnTupleFieldTypes.Count() > 1)
                    {
                        //assume for clm method, only an returncode will be added. 
                        tupleElements.Add(0);
                    }
                }
                else
                {
                    var oInvokeResponse = mgInvoker.Invoke(IDO, Method, idoMethodArgs);
                    //now update the original args
                    for (int i = 0; i < args.Length; i++)
                        args[i] = idoMethodArgs[i];
                    //create the new argument list
                    int tupleElementsCount = returnTupleFieldTypes.Count();

                    tupleElements = _buildTupleElements(oInvokeResponse.Parameters, returnTupleFieldTypes, args.Length, idoMethodArgCount);

                    tupleElements.Insert(0, oInvokeResponse.GetReturnValue<int>());
                }
                return (new TupleBuilder(new Utilities.TupleUtilFactory().Create())).CreateValueTuple(tupleElements, returnTupleFieldTypes);
            }
            throw new Exception(string.Format($"Unknown return type {targetMethod.ReturnType.Name}; The return type must be Int or DataTable"));
        }
            catch (TargetInvocationException ex)
            {
                var e = ex.InnerException ?? ex;
                throw e;
            }
        }
        private IList<object> _buildTupleElements(IMGInvokeParameterList parameters, IEnumerable<Type> returnTupleFieldTypes, int orginalArgsCount, int idoMethodArgCount)
        {
            List<object> tupleElements = new List<object>();
            int tupleElementIndex = 1;  //the first one tuple element should be return value which is from ido method.
            for (int i = orginalArgsCount; i < idoMethodArgCount; i++)
            {
                //Response value is always string type which would cause tuple definition unmatch. 
                //Here, assume those ref parameters on IDO method definition have the same datatype. 
                //in this place, mutiple datatypes need to be supported. If using string, when build tuple, conversion might fail.
                Type type = returnTupleFieldTypes.ElementAt(tupleElementIndex);
                switch (type)
                {
                    case Type _ when type == typeof(string):
                        tupleElements.Add(parameters[i].GetValue<string>()); break;
                    case Type _ when type == typeof(int):
                        tupleElements.Add(parameters[i].GetValue<int>()); break;
                    case Type _ when type == typeof(int?):
                        tupleElements.Add(parameters[i].GetNullableValue<int>()); break;
                    case Type _ when type == typeof(decimal):
                        tupleElements.Add(parameters[i].GetValue<decimal>()); break;
                    case Type _ when type == typeof(decimal?):
                        tupleElements.Add(parameters[i].GetNullableValue<decimal>()); break;
                    case Type _ when type == typeof(DateTime):
                        tupleElements.Add(parameters[i].GetValue<DateTime>()); break;
                    case Type _ when type == typeof(DateTime?):
                        tupleElements.Add(parameters[i].GetNullableValue<DateTime>()); break;
                    case Type _ when type == typeof(short):
                        tupleElements.Add(parameters[i].GetValue<short>()); break;
                    case Type _ when type == typeof(short?):
                        tupleElements.Add(parameters[i].GetNullableValue<short>()); break;
                    case Type _ when type == typeof(long):
                        tupleElements.Add(parameters[i].GetValue<long>()); break;
                    case Type _ when type == typeof(long?):
                        tupleElements.Add(parameters[i].GetNullableValue<long>()); break;
                    case Type _ when type == typeof(Guid):
                        tupleElements.Add(parameters[i].GetValue<Guid>()); break;
                    case Type _ when type == typeof(Guid?):
                        tupleElements.Add(parameters[i].GetNullableValue<Guid>()); break;
                    case Type _ when type == typeof(double):
                        tupleElements.Add(parameters[i].GetValue<double>()); break;
                    case Type _ when type == typeof(double?):
                        tupleElements.Add(parameters[i].GetNullableValue<double>()); break;
                    default:
                        tupleElements.Add(parameters[i].Value); break;
                }
                tupleElementIndex++;
            }
            return tupleElements;
        }
        private int _callStandardIDOMethod(string ido, string method, object[] args)
        {
            var oInvokeResponse = mgInvoker.Invoke(IDO, Method, args);

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = oInvokeResponse.Parameters[i].Value;
            }

            return oInvokeResponse.GetReturnValue<int>();
        }
        private DataTable _callCustomLoadIDOMethod(string ido, string method, object[] args)
        {
            IMGLoadCollectionResponseData loadCollectionResponse
                          = mgInvoker.LoadCollection(IDO, Method, args);
            return loadCollectionResponse.GetReturnValueDataTable();
        }
        private IEnumerable<Type> EnumerateTupleFieldTypes(Type tupleType)
        {
            foreach (FieldInfo field in EnumerateTupleFields(tupleType))
                yield return field.FieldType;
        }
        private IEnumerable<FieldInfo> EnumerateTupleFields(Type tupleType)
        {
            foreach (FieldInfo field in tupleType.GetFields().OrderBy(f => f.MetadataToken)) //sorting by the MetadataToken gives you the declaration order
            {
                if (field.Name == "Rest")
                    foreach (FieldInfo nestedField in EnumerateTupleFields(field.FieldType))
                        yield return nestedField;
                else
                    yield return field;
            }
        }
        /// <summary>
        /// Create a proxy that intercepts the decorated instance and routes the invocation through the IDO Method
        /// </summary>
        public static T Create(T decorated, string IDO, string Method, IMGInvoker mgInvoker, IInterceptConfiguration interceptConfiguration)
        {
            // The design of DispatchProxy requires this static factory method
            // The parameters of this method are what would be passed to a constructor

            object proxy = Create<T, IDOMethodIntercept<T>>();
            ((IDOMethodIntercept<T>)proxy).Constructor(decorated,IDO, Method, mgInvoker, interceptConfiguration);

            return (T)proxy;
        }
    }
    
}
