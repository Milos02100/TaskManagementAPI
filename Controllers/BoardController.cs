using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
       public TaskManagmentContext Context{get;set;}
       public BoardController(TaskManagmentContext context){
           Context=context;
       }

       [Route("ReturnBoards")]
       [HttpGet]
       public async Task<List<TaskManagmentApi.Models.Board>> ReturnBoards(){
           return await Context.Boards.Include(p=>p.Tasks).ToListAsync();
       }

       [Route("ReturnBoardsDDL")]
       [HttpGet]
       public async Task<List<TaskManagmentApi.Models.Board>> ReturnBoardsDDL(){
           return await Context.Boards.ToListAsync();
       }

       [Route("ReturnDevelopers")]
       [HttpGet]
       public async Task<List<TaskManagmentApi.Models.Developer>> ReturnDevelopers(){
           return await Context.Developers.ToListAsync();
       }

       [Route("ReturnTask")]
       [HttpGet]
       public async Task<List<TaskManagmentApi.Models.Task>> ReturnTask(){
           return await Context.Tasks.Include(p=>p.Developer).ToListAsync();
           //return await Context.Tasks.FindAsync(taskID);
       }


       [Route("InsertBoard")]
       [HttpPost]
       public async System.Threading.Tasks.Task InsertBoard([FromBody] Board board)
       {
           Context.Boards.Add(board);
           await Context.SaveChangesAsync();
       }

       [Route("InsertDeveloper")]
       [HttpPost]
       public async System.Threading.Tasks.Task InsertDeveloper([FromBody] Developer developer)
       {
           Context.Developers.Add(developer);
           await Context.SaveChangesAsync();
       }

       [Route("EditBoard")]
       [HttpPut]
       public async System.Threading.Tasks.Task EditBoard([FromBody] Board board)
       {
           //var oldBoard=await Context.Boards.FindAsync(board.BoardID);
           //oldBoard.Title=board.Title;
           Context.Update<Board>(board);
           await Context.SaveChangesAsync();
       }

       [Route("EditTask")]
       [HttpPut]
       public async System.Threading.Tasks.Task EditTask([FromBody] TaskManagmentApi.Models.Task task)
       {
          
           Context.Update<TaskManagmentApi.Models.Task>(task);
           await Context.SaveChangesAsync();
       }

        [Route("DeleteBoard/{boardId}")]
        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteBoard(int boardId)
        {
            var board=await Context.Boards.FindAsync(boardId);
            Context.Remove(board);
            await Context.SaveChangesAsync();
        }

        [Route("DeleteTask/{taskId}")]
        [HttpDelete]
        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            var task=await Context.Tasks.FindAsync(taskId);
            Context.Remove(task);
            await Context.SaveChangesAsync();
        }

        [Route("InsertTask/{idBoard}/{idDeveloper}")]
        [HttpPost]
        public async System.Threading.Tasks.Task InsertTask(int idBoard,int idDeveloper,[FromBody] TaskManagmentApi.Models.Task task)
        {
            var developer=await Context.Developers.FindAsync(idDeveloper);
            var board=await Context.Boards.FindAsync(idBoard);
            task.Board=board;
            task.Developer=developer;
            Context.Tasks.Add(task);
            await Context.SaveChangesAsync();
        }
    }
}
