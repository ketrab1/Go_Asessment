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
        public async Task<IHttpActionResult> Index()
        {
            var data = await _repository.GetAssets();
            if (data == null)
                BadRequest();

            var dto = data.Select(Mapper.Map<AssetDto>);

            return Ok(JsonConvert.SerializeObject(dto));
        }

        // GET: Assets/Details/5
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Details(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }

            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return new NotFoundResult(this);
            }

            var dto = Mapper.Map<Asset, AssetDto>(data);

            return Ok(JsonConvert.SerializeObject(dto));
        }

       
        [ValidateAntiForgeryToken]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Create(
            [FromBody] AssetDtoForCreation asset)
       {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(asset);
            }

            return Ok();
        }


        [System.Web.Http.HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Edit(
            [FromBody]
            AssetDto asset)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(asset);
            }

            return Ok();
        }


        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }

            await _repository.DeletedAsync(id);
            return Ok();
        }
    }
}