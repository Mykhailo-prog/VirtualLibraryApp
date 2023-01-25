﻿using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Logic.Interface;
using VirtualLibrary.Utilites.Implementations.Filters.ModelFields;
namespace VirtualLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IModelLogic<Article, ArticleDTO> _dataStore;

        public ArticleController(ILogger<ArticleController> logger, IModelLogic<Article, ArticleDTO> dataStore)
        {
            _logger = logger;
            _dataStore = dataStore;
        }

        [HttpGet("ordered")]
        public async Task<IActionResult> GetArticles([FromHeader] string field)
        {
            var IsParsed = FieldParser.TryParseField(field, out var parsedField);

            if (!IsParsed)
            {
                return BadRequest($"{parsedField} field!");
            }
            var result = await _dataStore.GetSortedDataAsync(field);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _dataStore.GetDataAsync();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetArticleByID([FromQuery] string id)
        {
            var isInteger = int.TryParse(id, out int parsedId);

            if (string.IsNullOrWhiteSpace(id) && !isInteger)
            {
                return BadRequest("Incorect Id");
            }

            var result = await _dataStore.GetDatabyId(parsedId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostArticle([FromBody] ArticleDTO articleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _dataStore.AddDataAsync(articleDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /*[HttpPut("id")]
        public async Task<ActionResult> PutBook([FromQuery] string id, [FromBody] BookDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isInteger = int.TryParse(id, out int parsedId);

            if (string.IsNullOrWhiteSpace(id) && !isInteger)
            {
                return BadRequest("Incorect Id");
            }

            var result = await _repository.UpdateAsync(parsedId, bookDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            var succseedResult = (ActionManagerResponse<Book>)result;
            return Ok(succseedResult.ActionResult);
        }*/

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteArticle([FromQuery] string id)
        {
            var isInteger = int.TryParse(id, out int parsedId);

            if (string.IsNullOrWhiteSpace(id) && !isInteger)
            {
                return BadRequest("Incorect Id");
            }

            var result = await _dataStore.DeleteDataAsync(parsedId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
