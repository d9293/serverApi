using ServerApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ServerApi.Controllers
{
    public class CompendiumApiController : BaseController
    {
        // GET api/compendium/get
        [Route("api/compendium/get")]
        public HttpResponseMessage GetStates()
        {
            List<CompendiumModel> model = GetStatesInfo();
            var response = new JavaScriptSerializer().Serialize(model);
            HttpResponseMessage ResponseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(response, Encoding.UTF8, "application/json")
            };
            return ResponseMessage;
        }

        // GET api/compendium/create
        [HttpGet]
        [Route("api/compendium/create")]
        public HttpResponseMessage CreateState(CompendiumModel model)
        {
            //CompendiumModel model = new CompendiumModel() { ID = 4, Name = "test4" };
            return CreateStateInfo(model);
        }

        // GET api/compendium/set
        [HttpGet]
        [Route("api/compendium/set")]
        public HttpResponseMessage SetState(CompendiumModel model)
        {
            //CompendiumModel model = new CompendiumModel() { ID = 4, Name = "test4" };
            return SetStateInfo(model);
        }

        // GET api/compendium/delete
        [HttpGet]
        [Route("api/compendium/delete")]
        public HttpResponseMessage DeleteState(string id)
        {
            //string id = "3";
            return DeleteStateInfo(id);
        }
    }
}
