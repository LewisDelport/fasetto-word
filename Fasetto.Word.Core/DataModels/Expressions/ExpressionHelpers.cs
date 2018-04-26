using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// complies an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">the type of return value</typeparam>
        /// <param name="lamba">the expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }
        /// <summary>
        /// sets the underlying properties value to the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">the type of value to set</typeparam>
        /// <param name="lamda">the expression</param>
        /// <param name="value">the value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            //converts a lamba () => some.Property, to some.Property 
            var expression = (lamba as LambdaExpression).Body as MemberExpression;
            //get the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            //get the target the lamba is run from
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
