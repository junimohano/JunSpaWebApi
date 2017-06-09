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
    //[Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestsController : Controller
    {
        private readonly JunSpaContext _context;

        public TestsController(JunSpaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var boards = await _context.Boards.AsNoTracking().ToListAsync();
            return Ok(boards);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var board = await _context.Boards.AsNoTracking().SingleOrDefaultAsync(x => x.BoardId == id);
            if (board == null) return NotFound();

            return Ok(board);
        }

        [HttpGet("{id}/comments/{test}")]
        public async Task<IActionResult> GetComments(int id, int test, [FromQuery]string haha)
        {
            var board = await _context.Boards.AsNoTracking().SingleOrDefaultAsync(x => x.BoardId == id);
            if (board == null) return NotFound();

            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Board value)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                value.CreatedDate = DateTime.Now;
                await _context.Boards.AddAsync(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Board value)
        {
            var board = await _context.Boards.SingleOrDefaultAsync(x => x.BoardId == id);
            if (board == null) return NotFound();

            try
            {
                board.Title = value.Title;
                board.Content = value.Content;
                board.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(board);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var board = await _context.Boards.AsNoTracking().SingleOrDefaultAsync(x => x.BoardId == id);
            if (board == null) return NotFound();

            try
            {
                _context.Boards.Remove(board);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
