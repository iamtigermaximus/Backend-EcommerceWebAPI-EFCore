using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTOs.User;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class UserService : IUserService

{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(AddUserDTO newUser)
    {
        var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
        var user = _mapper.Map<User>(newUser);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.Users
                    .Select(u => _mapper.Map<GetUserDTO>(u))
                    .ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
    {
        var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
        var dbUsers = await _context.Users.ToListAsync();
        serviceResponse.Data = dbUsers.Select(u => _mapper.Map<GetUserDTO>(u)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
    {
        var serviceResponse = new ServiceResponse<GetUserDTO>();
        var dbUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        serviceResponse.Data = _mapper.Map<GetUserDTO>(dbUser);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser)
    {
        var serviceResponse = new ServiceResponse<GetUserDTO>();

        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user is null)
                throw new Exception($"User with Id '{updatedUser.Id}' not found.");

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.Avatar = updatedUser.Avatar;
            user.Role = updatedUser.Role;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }

    public async Task<ServiceResponse<List<GetUserDTO>>> DeleteUser(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetUserDTO>>();

        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new Exception($"User with Id '{id}' not found.");

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Users.Select(u => _mapper.Map<GetUserDTO>(u)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}