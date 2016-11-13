//  --------------------------------------------------------------------------------------
//  <copyright file="BuiltInDelegatesExample.cs" company="Copper Star Systems, LLC">
//     Copyright 2016 Copper Star Systems, LLC. All Rights Reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------

using System;

namespace DelegatesExample
{
    public class BuiltInDelegatesExample
    {
        // An Action is a built-in delegate representing a void method
        // with no parameters.  It's important to remember that Actions always
        // have a void return type.
        public void DoWork(Action methodToExecute)
        {
            // Note that we can invoke the delegate as if we were directly calling
            // a method.
            methodToExecute();
        }

        // Action also has a bunch of generic overloads that specify the 
        // inbound parameter types for the method.  For example, the code
        // below specifies a void method that takes a SomeDataClass parameter.
        // Each additional overload adds another parameter type to the action's
        // parameter list.
        public void DoWork(Action<SomeDataClass> methodToExecute)
        {
            var someDataClass = new SomeDataClass();
            methodToExecute(someDataClass);
        }

        // A Func is a built-in delegate representing a method with no
        // parameters but with a specified return type.  It's important to 
        // notice that there is no non-generic Func (as there is with Action)
        // because a return type must always be specified.
        //
        // The code below specifies a function with no parameters that returns a bool
        public bool DoWork(Func<bool> methodToExecute)
        {
            // Just like with Actions, we can invoke delegates directly.
            // We don't necessarily have to return the result of methodToExecute,
            // it's possible we would use that result as an intermediate variable,
            // for example maybe filtering a result set before returning it.
            return methodToExecute();
        }

        // The code below specifies a function with one SomeDataClass parameter that returns a bool
        // Syntactially, it's important to note that the last item in the generic type list
        // specifies the Func's return type.
        public bool DoWork(Func<SomeDataClass, bool> methodToExecute)
        {
            var someDataClass = new SomeDataClass();
            return methodToExecute(someDataClass);
        }

        // As with Action, there are multiple generic overloads of Func<T>, allowing us to
        // specify methods with multiple parameters.  The code below specifies a function
        // with a SomeDataClass and a string parameter that returns a string
        public string DoWork(Func<SomeDataClass, string, string> methodToExecute)
        {
            var message = "Delegates are pretty cool.";
            var someDataClass = new SomeDataClass();
            return methodToExecute(someDataClass, message);
        }
    }
}