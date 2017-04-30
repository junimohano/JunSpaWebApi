using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JunSpaWebApi.Data;
using JunSpaWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JunSpaWebApi.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommentsController : Controller
    {
        private readonly JunSpaContext _context;

        public CommentsController(JunSpaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var boards = await _context.Comments.ToListAsync();
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var board = await _context.Comments.FirstOrDefaultAsync(x => x.BoardId == id);
            if (board == null) return NotFound();

            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Comment value)
        {
            try
            {
                await _context.Comments.AddAsync(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Comment value)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.BoardId == id);
            if (comment == null) return NotFound();

            try
            {
                comment.Content = value.Content;
                comment.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.BoardId == id);
            if (comment == null) return NotFound();

            try
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }
    }
}
