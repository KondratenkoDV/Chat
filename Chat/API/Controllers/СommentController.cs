﻿using API.DTOs.Comment;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class СommentController : ControllerBase
    {
        private readonly ICommentService _сommentService;

        public СommentController(ICommentService сommentService)
        {
            _сommentService = сommentService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNewComment(
            CreateCommentDto createCommentDto,
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _сommentService.AddAsync(
                createCommentDto.UserName,
                createCommentDto.Email,
                createCommentDto.HomePage,
                createCommentDto.Text,
                createCommentDto.Ip,
                createCommentDto.BrowserData,
                createCommentDto.ParentId,
                cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetParentComments")]
        public async Task<ActionResult<IEnumerable<SelectedParentCommentDto>>> GetParentComments()
        {
            try
            {
                var comments = await _сommentService.SelectingParentCommentsAsync();

                var selectedParentCommentDto = new List<SelectedParentCommentDto>();

                foreach (var comment in comments)
                {
                    selectedParentCommentDto.Add(new SelectedParentCommentDto()
                    {
                        Id = comment.Id,
                        SelectedUserName = comment.UserName,
                        SelectedEmail = comment.Email,
                        SelectedHomePage = comment.HomePage,
                        SelectedText = comment.Text,
                        SelectedIp = comment.Ip,
                        SelectedBrowserData = comment.BrowserData,
                        SelectedDateAdded = comment.DateAdded
                    });
                }

                return Ok(selectedParentCommentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetComments")]
        public async Task<ActionResult<IEnumerable<SelectedCommentDto>>> GetComments()
        {
            try
            {
                var comments = await _сommentService.SelectingCommentsAsync();

                var selectedCommentDto = new List<SelectedCommentDto>();

                foreach (var comment in comments)
                {
                    selectedCommentDto.Add(new SelectedCommentDto()
                    {
                        Id = comment.Id,
                        SelectedUserName = comment.UserName,
                        SelectedEmail = comment.Email,
                        SelectedHomePage = comment.HomePage,
                        SelectedText = comment.Text,
                        SelectedIp = comment.Ip,
                        SelectedBrowserData = comment.BrowserData,
                        SelectedDateAdded = comment.DateAdded,
                        SelectedParentId = comment.ParentId
                    });
                }

                return Ok(selectedCommentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
