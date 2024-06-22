using FluentBuilder;
using System.Text;

var hello = "hello";
var sb = new StringBuilder();

sb.Append("<p>");
sb.Append(hello);
sb.Append("</p>");
Console.WriteLine(sb);

var words = new string[] { "Hello", "World" };
sb.Clear();
sb.Append("<ul>");
foreach (var word in words)
{
    sb.AppendFormat("<li>{0}</li>", word);
}
sb.Append("</ul>");
Console.WriteLine(sb);

var builder = new HtmlBuilder("ul");
builder.AddChild("li", "hello");
builder.AddChild("li", "world");
Console.WriteLine(builder.ToString());