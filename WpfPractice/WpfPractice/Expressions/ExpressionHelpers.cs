using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace WpfPractice.Expressions
{
    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> expression)
        {
            return expression.Compile().Invoke();
        }
        
        public static void SetPropertyValue<T>(this Expression<Func<T>> expression, T value)
        {
            var memberExp = (expression.Body as MemberExpression);

            var propertyInfo = (PropertyInfo)memberExp.Member;

            var target = Expression.Lambda(memberExp.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
