using System.Text.RegularExpressions;

namespace ConstraintsAspdotnetCore.Customconstraints
{
    public class AlphaNumericConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, 
            IRouter? route, string routeKey,
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
            { 
                return false;
            
            }
            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
            string? val = Convert.ToString(values[routeKey]);
            if (regex.IsMatch(val))
            {
                return true;
            }

            return false;

            throw new NotImplementedException();
        }
    }
}
