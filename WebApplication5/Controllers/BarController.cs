using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class BarController : Controller
    {
        // Get: Bar
        public async Task Index() // ViewResult 
        {


            Response.ContentType = "text/html;charset=utf-8";
            System.Text.StringBuilder tableBuilder = new("<h2>Request headers</h2><table>");
            foreach (var header in Request.Headers)
            {
                tableBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
            }
            tableBuilder.Append("</table>");
            await Response.WriteAsync(tableBuilder.ToString());
        }

        public string Context(string name, string[]food,  int count = 1) // ViewResult 
        {
            var str = "";
            str += $"You want drink : {name}  = ";
            foreach(var t in food)
            {
                str += t.ToString() + " - ";
            }
            str += count;
            return str;
        }
        // HttpContext 
        [HttpPost]
        public string Hello() => "POST This is Bar controller and Index method";

        [ActionName("Find")]
        public string GetById(int id)
        {
            return $"Id = {id}";
        }

        [NonAction]
        public string NonGetById(int id)
        {
            return $"Id = {id}";
        }
    }
}
//httpGet httpPost httpPut httpHead httpOptions httpDelete httpPatch
