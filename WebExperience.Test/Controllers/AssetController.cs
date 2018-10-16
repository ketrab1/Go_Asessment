using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using GeneralKnowledge.Test.App.Domain.Model;
using Newtonsoft.Json;
using WebExperience.Test.Infrastructure;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssetController : ApiController
    {
        private readonly IAssetRepository _repository;

        public AssetController()
        {
            
        }

        public AssetController(IAssetRepository repository)
        {
            _repository = repository;
        }

        // GET: Assets
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Index()
        {
            var data = await _repository.GetAssets();
            if (data == null)
            return Request.CreateResponse(HttpStatusCode.BadRequest);

            var dto = data.Select(Mapper.Map<AssetDto>);

          return Request.CreateResponse(HttpStatusCode.OK, dto);
        }

        // GET: Assets/Details/5
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Details(Guid id)
        {
            if (!Guid.TryParse(id.ToString(), out var _id))
            {
            return Request.CreateResponse(HttpStatusCode.BadRequest, _id);
            }

            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
      }

            var dto = Mapper.Map<Asset, AssetDto>(data);

          return Request.CreateResponse(HttpStatusCode.OK, dto);
    }

       

        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Create(
            [FromBody] AssetDtoForCreation asset)
       {
            if (!ModelState.IsValid)
            {
              return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
             await _repository.CreateAsync(asset);
             return Request.CreateResponse(HttpStatusCode.OK);
       }


        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> Edit(
            [FromBody]
            AssetDto asset)
        {
            if (!ModelState.IsValid)
            {
              return Request.CreateResponse(HttpStatusCode.BadRequest);
      
            }
          await _repository.UpdateAsync(asset);
          return Request.CreateResponse(HttpStatusCode.OK);
       }


        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
          if (Guid.TryParse(id.ToString(), out var _id))
          {
            return Request.CreateResponse(HttpStatusCode.BadRequest, _id);
          }

          await _repository.DeletedAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
    }
    }
}
