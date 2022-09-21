using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using UI.Helpers;
using UI.Models.Comment;
using UI.Models.Common;

namespace UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiConfiguration _baseUrl;

        public CommentController(IHttpClientFactory httpClientFactory, IOptions<ApiConfiguration> options)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = options.Value;
        }

        public async Task<ActionResult> CreateComment(CreateCommentModel createCommentModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var httpResponseMessage = await httpClient.PostAsJsonAsync($"{_baseUrl.Api}/Сomment/", createCommentModel);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var commentResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    int id = JsonConvert.DeserializeObject<int>(commentResponse);

                    return View(id);
                }

                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> GetParentComments()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var pagedModel = new PagedModel<SelectedParentCommentModel>();

                var httpResponseMessage = await httpClient.GetAsync($"{_baseUrl.Api}/Сomment/");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var commentResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    pagedModel = JsonConvert.DeserializeObject<PagedModel<SelectedParentCommentModel>>(commentResponse);
                }

                return View(pagedModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> GetComments(int parentId)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();

                var pagedModel = new PagedModel<SelectedCommentModel>();

                var httpResponseMessage = await httpClient.GetAsync($"{_baseUrl.Api}/Сomment/{parentId}");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var commentResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    pagedModel = JsonConvert.DeserializeObject<PagedModel<SelectedCommentModel>>(commentResponse);
                }

                return View(pagedModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
