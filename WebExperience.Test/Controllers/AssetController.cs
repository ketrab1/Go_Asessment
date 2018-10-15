using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using GeneralKnowledge.Test.App.Asset.Domain.Infrastructure;
using Newtonsoft.Json;
using WebExperience.Test.Infrastructure;
using GeneralKnowledge.Test.App.Asset.Domain.Model;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        private readonly IAssetRepository _repository;

        public AssetController(IAssetRepository repository)
        {
            _repository = repository;
        }

        // GET: Assets
        public async Task<IHttpActionResult> Index()
        {
            var data = await _repository.GetAssets();
            if (data == null)
                BadRequest();

            return Ok(JsonConvert.SerializeObject(data));
        }

        // GET: Assets/Details/5
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

            return Ok(JsonConvert.SerializeObject(data));
        }

        // GET: Assets/Create
        public HttpResponseMessage Create()
        {
            var newUrl = Url.Link("Default", new
            {
                Controller = "Asset",
                Action = "Create"
            });
            return Request.CreateResponse(HttpStatusCode.OK, new {Success = true, RedirectUrl = newUrl});
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Create(
            [Bind(Include = "AssetId,FileName,MimeType,CreatedBy,Country,Email,Description")]
            AssetDto asset)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(asset);
            }

            return Ok();
        }


        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Edit(
            [Bind(Include = "AssetId,FileName,MimeType,CreatedBy,Country,Email,Description")]
            AssetDto asset)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(asset);
            }

            return Ok();
        }

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