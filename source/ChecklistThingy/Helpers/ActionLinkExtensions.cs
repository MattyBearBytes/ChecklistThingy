using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChecklistThingy.Helpers
{
    public static class ActionLinkExtensions
    {
        /// <summary>
        /// Return <a> link with Twitter Bootstrap icon
        /// </summary>
        public static MvcHtmlString IconActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string icon)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, null, null, icon);
        }

        /// <summary>
        /// Return <a> link with Twitter Bootstrap icon containing Route Values
        /// </summary>
        public static MvcHtmlString IconActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string icon, object routeValues)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, routeValues, null, icon);
        }

        /// <summary>
        /// Return <a> link with specified class
        /// </summary>
        public static MvcHtmlString ClassActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string htmlClass)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, null, new { @class = htmlClass }, null);
        }

        /// <summary>
        /// Return <a> link with specified class containing Route Values
        /// </summary>
        public static MvcHtmlString ClassActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string htmlClass, object routeValues)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, routeValues, new { @class = htmlClass }, null);
        }

        /// <summary>
        /// Return <a> link with specified class and Twitter Bootstrap icon
        /// </summary>
        public static MvcHtmlString IconClassActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string icon, string htmlClass)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, null, new { @class = htmlClass }, icon);
        }

        /// <summary>
        /// Return <a> link with specified class and Twitter Bootstrap icon containing Route Values
        /// </summary>
        public static MvcHtmlString IconClassActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string icon, string htmlClass, object routeValues)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, routeValues, new { @class = htmlClass }, icon);
        }

        /// <summary>
        /// Return <a> link with defined html attributes and Twitter Bootstrap icon containing Route Values
        /// </summary>
        public static MvcHtmlString IconClassActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, string icon, object htmlAttributes, object routeValues)
        {
            return GenerateActionLink(helper, text, actionName, controllerName, routeValues, htmlAttributes, icon);
        }

        private static MvcHtmlString GenerateActionLink(this HtmlHelper helper, string text, string actionName, string controllerName, object routeValues, object htmlAttributes, string icon)
        {
            var builder = new TagBuilder("i");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] " + text, actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

    }
}