using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicandOOPsPart1Practice
{
    class NullableTypeDynamicTypeVar
    {
        //NullableType
        int? nullableInt = null; // nullable integer with no value
        bool? nullableBool = true; // nullable boolean with a value
        string nullableString = null; // nullable String with no value
        NullableExample NullableExample = null; // nullable String with no value
        void exampleMethod()
        {
            dynamic nullableVar = null; //Dynamic is nullable
            var number1 = 1;
            var str1 = string.Empty;
        }
        public dynamic dynamicproperty = null; //Dynamic Property
        public dynamic ExampleMethod(dynamic parameter1) //Dynamic Method
        {
            return parameter1;
        }
    }
    class NullableExample
    {
        public int? nullableInt { get; set; }
    }
}
//Var is not nullable