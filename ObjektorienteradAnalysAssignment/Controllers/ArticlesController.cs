using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObjektorienteradAnalysAssignment.Contexts;
using ObjektorienteradAnalysAssignment.Factories;
using ObjektorienteradAnalysAssignment.Models;
using ObjektorienteradAnalysAssignment.Models.DTOs;
using ObjektorienteradAnalysAssignment.Models.Entities;
using ObjektorienteradAnalysAssignment.Repositories;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjektorienteradAnalysAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleRepository _articleRepository;

        public ArticlesController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // GET: api/<ArticlesController>
        [HttpGet]
        public async Task<IEnumerable<ArticleEntity>> GetAllAsync()
        {
            return await _articleRepository.GetAllAsync();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Bruh please write a guid");
            }

            var article = await _articleRepository.GetAsync(a => a.Id == guid);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public async Task<IActionResult> Create(ArticleRequest article)
        {
            if (ModelState.IsValid)
            {
                ArticleResponse res = await _articleRepository.CreateAsync(article);
                if (res != null)
                    return Created("", res);
            }
            return BadRequest();
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ArticleEntity article)
        {
            if (article == null || id != article.Id)
            {
                return BadRequest("Invalid input");
            }
                await _articleRepository.Put(article);
                return Ok();
        }


        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _articleRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
