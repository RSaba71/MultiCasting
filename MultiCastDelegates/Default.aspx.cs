using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiCastDelegates
{
    public partial class Default : System.Web.UI.Page
    {
        class MathFunctions
        {
            public string Add(int x, int y)
            {
                return "Sum is:" + (x + y).ToString();
            }
            public string Subtract(int x, int y)
            {
                return "Difference is:" + (x - y).ToString();
            }
            public string Multiply(int x, int y)
            {
                return "Product is:" + (x * y).ToString();
            }
            public string Divide(int x, int y)
            {
                return "Quotient is:" + (x / y).ToString();
            }
        }

        //define the delegate

        public delegate string MultiCastDelegate(int a, int b);
        protected void Page_Load(object sender, EventArgs e)
        {
            // use the delegate.
            MathFunctions obj1 = new MathFunctions();
            MultiCastDelegate objD = new MultiCastDelegate(obj1.Multiply);
            objD += obj1.Add;            
            objD += obj1.Subtract;
            objD += obj1.Divide;
            delId.Value = objD(40, 10);
            objD -= obj1.Add;
            objD -= obj1.Divide;
            delId1.Value = objD(50, 10);
            
        }
    }
}