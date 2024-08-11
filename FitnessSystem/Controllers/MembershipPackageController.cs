﻿using FitnessSystem.Application.DTOs.MembershipPackage;
using FitnessSystem.Application.Interfaces;
using FitnessSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessSystem.Presentation.Controllers
{
    [Route("api/membership-packages")]
    [ApiController]
    public class MembershipPackageController : ControllerBase
    {
        private readonly IMembershipPackageService _membershipPackageService;

        public MembershipPackageController(IMembershipPackageService membershipPackageService)
        {
            _membershipPackageService = membershipPackageService;
        }

        [HttpGet] 
        public async Task<ActionResult<List<MembershipPackageDto>>> GetAll()
        {
            var membershipPackages =  await _membershipPackageService.GetAllAsync();
            return Ok(membershipPackages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var membershipPackageDto = await _membershipPackageService.GetByIdAsync(id);
            if (membershipPackageDto == null)
            {
                return NotFound();
            }
            return Ok(membershipPackageDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembershipPackage([FromBody] MembershipPackageDto membershipPackageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdMembershipPackage = await _membershipPackageService.CreateMembershipPackageAsync(membershipPackageDto);
                return Ok(createdMembershipPackage);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while creating the admin.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembershipPackage(int id)
        {
            var membershipPackageToDelete = await _membershipPackageService.DeleteMembershipPackageAsync(id);
            if (membershipPackageToDelete == null)
            {
                return NotFound(new { message = "MembershipPackage not found." });
            }

            return Ok(new { message = "MembershipPackage deleted successfully.", membershipPackage = membershipPackageToDelete });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MembershipPackageDeleteDto>> UpdateClient(int id, [FromBody] MembershipPackageDto membershipPackageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedMembershipPackage = await _membershipPackageService.UpdateMembershipPackageAsync(id, membershipPackageDto);
                return Ok(updatedMembershipPackage);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
