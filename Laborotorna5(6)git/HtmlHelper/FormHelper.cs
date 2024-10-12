using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Laborotorna5_6_.HtmlHelper
{
    public static class FormHelper
    {
        public static HtmlString CreateForm(this IHtmlHelper html, int count)
        {
            StringBuilder sb = new StringBuilder("<form class=\"form-user\"  method=\"post\" action=\"/User/ShowInfo\">");
            for (int i = 1; i < count + 1; i++)
            {
                    sb.Append($"<label>Введіть дані для товара- {i}</label>" +
                    $"<label for=\"name{i}\">Назва</label>" +
                    $"<input type = \"text\" name = \"name{i}\" required/>" +
                    $"<label for=\"count{i}\">Кількість</label>" +
                    $"<input type = \"number\" name = \"count{i}\" required/>");
            }
            
            sb.AppendLine("<input type=\"submit\" value=\"Відправити\">" +
                "</form>\n");

            return new HtmlString(sb.ToString());
        }
    }
}
