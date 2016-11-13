//  --------------------------------------------------------------------------------------
//  <copyright file="BuiltInDelegatesConsumer.cs" company="Copper Star Systems, LLC">
//     Copyright 2016 Copper Star Systems, LLC. All Rights Reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------

using System;

namespace DelegatesExample
{
    public class BuiltInDelegatesConsumer
    {
        readonly BuiltInDelegatesExample delegates;
        int actionInvocationCount;

        public BuiltInDelegatesConsumer()
        {
            delegates = new BuiltInDelegatesExample();
        }

        public void InvokeDelegates()
        {
            InvokeActionWithoutParameters();
            NotifyConsole();
            InvokeActionWithParameter();
            NotifyConsole();
            InvokeBoolFunctionWithoutParameters();
            NotifyConsole();
            InvokeBoolFunctionWithSomeDataClassParameter();
            NotifyConsole();
            InvokeStringFunctionWithMultipleParameters();
            NotifyConsole();
        }

        void ActionMethod()
        {
            // Since we don't have any params to work on, we're
            // limited to doing local work.
            NotifyConsole("Executing ActionMethod()");
            actionInvocationCount++;
        }

        bool FuncMethod()
        {
            NotifyConsole("Executing FuncMethod()");
            // Normally we would be returning a value based on this class' state.
            return true;
        }

        void GenericActionMethod(SomeDataClass someDataClass)
        {
            NotifyConsole("Executing GenericActionMethod(SomeDataClass)");
            // We might perform some operation on someDataClass here, 
            // or maybe store it locally or whatever.
            someDataClass.SomeProperty = "Set by BuiltInDelegatesConsumer.GenericActionMethod.";
        }

        bool GenericFuncMethodWithOneParameter(SomeDataClass someDataClass)
        {
            NotifyConsole("Executing GenericFuncMethodWithOneParameter(SomeDataClass)");
            // In this scenario, maybe we're making a decision based on someDataClass' 
            // properties or something.
            return someDataClass != null;
        }

        string GenericFuncMethodWithTwoParameters(SomeDataClass someDataClass, string message)
        {
            NotifyConsole("Executing GenericFuncMethodWithTwoParameters");
            // IRL, we would probably do some operations on someDataClass here
            return message + " from GenericFuncMethodWithTwoParameters ";
        }

        void InvokeActionWithoutParameters()
        {
            NotifyConsole($"Invoking Action without parameters.  ActionInvocationCount = {actionInvocationCount}");
            delegates.DoWork((Action) ActionMethod);
            NotifyConsole($"After invoking Action without parameters.  ActionInvocationCount = {actionInvocationCount}");
        }

        void InvokeActionWithParameter()
        {
            NotifyConsole($"Invoking Action with SomeDataClass parameter.");
            delegates.DoWork((Action<SomeDataClass>) GenericActionMethod);
            NotifyConsole($"After invoking Action with SomeDataClass parameter.");
        }

        void InvokeBoolFunctionWithoutParameters()
        {
            NotifyConsole($"Invoking Func<bool> without parameters.");
            var result = delegates.DoWork(FuncMethod);
            NotifyConsole($"After invoking Func<bool> without parameters.  Return value:  {result}");
        }

        void InvokeBoolFunctionWithSomeDataClassParameter()
        {
            NotifyConsole($"Invoking Func<SomeDataClass, bool> with SomeDataClass parameter.");
            var result = delegates.DoWork(GenericFuncMethodWithOneParameter);
            NotifyConsole($"After invoking Func<SomeDataClass, bool>.  Return value:  {result}");
        }

        void InvokeStringFunctionWithMultipleParameters()
        {
            NotifyConsole($"Invoking Func<SomeDataClass, string, string> with SomeDataClass and string parameters");
            var stringResult = delegates.DoWork(GenericFuncMethodWithTwoParameters);
            NotifyConsole(
                $"After invoking Func<SomeDataClass, string, string> with SomeDataClass and string parameters.  Result: {stringResult}");
        }

        void NotifyConsole(string message = "")
        {
            Console.WriteLine(message);
        }
    }
}