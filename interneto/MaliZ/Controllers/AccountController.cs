﻿using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Interfaces;
using MaliZ.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _dataContext;
    private readonly ITokenService _tokenService;
    private string username;
    private char[] password;

    public AccountController(DataContext dataContext,ITokenService tokenService)
    {
        _dataContext = dataContext;
        _tokenService = tokenService;
    } 
     private async Task<bool> isUserExists(string username)
    {
        return await _dataContext.Users.AnyAsync(user => user.Username == username.ToLower());
    }
   
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDTO registerDTO)
    {
         if (await isUserExists(registerDTO.Username!))
            return BadRequest("username is already exists");

        using var hmacSHA256 = new HMACSHA256();
        var user = new AppUser
        {
            Username = registerDTO.Username.Trim().ToLower(),
            PasswordHash =  hmacSHA256.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password.Trim())),
            PasswordSalt = hmacSHA256.Key
        };
        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();
        return new UserDto
        {
            Username = user.Username,
            Token = _tokenService.CreateToken(user)
        };;
    }

     [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _dataContext.Users.SingleOrDefaultAsync(user =>
                            user.Username == loginDto.UserName);

        if (user is null) return Unauthorized("invalid username");

        using var hmacSHA256 = new HMACSHA256(user.PasswordSalt!);

        var computedHash = hmacSHA256.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password!.Trim()));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash?[i]) return Unauthorized("invalid password");
        }
        return new UserDto
        {
            Username = user.Username,
            Token = _tokenService.CreateToken(user)
        };;
    }
}

