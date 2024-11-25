﻿using Application.Members.Commands;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public MembersController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetMemberById(id);
            return member != null ? Ok(member) : NotFound("Member not found.");
        }
        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            var createdMember = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var updatedMember = await _mediator.Send(command);
            return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var command = new DeleteMemberCommand { Id = id };
            var deletedMember = await _mediator.Send(command);
            return deletedMember != null ? Ok(deletedMember) : NotFound("Member not found.");
        }
    }
}
