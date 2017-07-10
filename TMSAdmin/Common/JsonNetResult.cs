using Newtonsoft.Json.Linq; 
using System.Web.Mvc;

namespace TMSAdmin.Common
{
    public class JsonNetResult : ActionResult
    {
        private readonly JObject _data;
        public JsonNetResult(JObject data)
        {
            _data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(_data.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}