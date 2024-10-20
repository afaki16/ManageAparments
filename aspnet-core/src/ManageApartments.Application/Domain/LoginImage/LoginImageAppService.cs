using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Timing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrimeNG.TableFilter;
using PrimeNG.TableFilter.Models;
using ManageApartments.Domain.LoginImage.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManageApartments.Authorization;
using ManageApartments.EntityFrameworkCore.Repositories.Contracts.LoginImage;
using ManageApartments.Migrations;
using Swiss.InventoryManagement.Domain.LoginImage;

namespace ManageApartments.Domain.LoginImage;

[AbpAuthorize(PermissionNames.LoginImage)]
public class LoginImageAppService :
        AsyncCrudAppService<Entities.LoginImage, LoginImageFullOutput, int, GetLoginImageListInput, CreateLoginImageInput, UpdateLoginImageInput,
        GetLoginImageInput, DeleteLoginImageInput>, ILoginImageAppService
{
    private readonly ILoginImageRepository _repository;
    private readonly IConfiguration _configuration;
    public LoginImageAppService(
        ILoginImageRepository repository,
        IConfiguration configuration) : base(repository)
    {
        _repository = repository;
        _configuration = configuration;
        CreatePermissionName = PermissionNames.LoginImage_Create;
        UpdatePermissionName = PermissionNames.LoginImage_Update;
        DeletePermissionName = PermissionNames.LoginImage_Delete;
        GetPermissionName = PermissionNames.LoginImage_Get;
        GetAllPermissionName = PermissionNames.LoginImage_GetList;
    }


    [HttpPost]
    public async Task<PagedResultDto<LoginImageFullOutput>> GetAllFilteredAsync(TableFilterModel tableFilterPayload)
    {
        var query = this._repository.GetAll().PrimengTableFilter(tableFilterPayload, out var totalRecord);
        var entities = await AsyncQueryableExecuter.ToListAsync(query);
        return new PagedResultDto<LoginImageFullOutput>(
            totalRecord,
            entities.Select(ObjectMapper.Map<LoginImageFullOutput>).ToList()
        );
    }

    [HttpGet]
    [AbpAllowAnonymous]
    public async Task<List<LoginImageFullOutput>> GetImagesFullOutputs()
    {
        var images = this.Repository.GetAll();

        return this.ObjectMapper.Map<List<LoginImageFullOutput>>(images);
    }

    [HttpPost]
    public override async Task<LoginImageFullOutput> CreateAsync(CreateLoginImageInput input)
    {
        string imagePath = Path.Combine(_configuration["Files:RootFolder"], "Images", "LoginImages");
        string dbPath = $"{Clock.Now.ToUnixTimestamp()}.{input.Base64FileUpload.FileName.Split('.').Last()}";

        if (!Directory.Exists(imagePath))
            Directory.CreateDirectory(imagePath);

        imagePath = Path.Combine(imagePath, dbPath);
        dbPath = $"assets/Images/LoginImages/{dbPath}";

        input.PhotoUrl = dbPath;

        File.WriteAllBytes(imagePath, Convert.FromBase64String(input.Base64FileUpload.FileData.Split(',').Last()));

        CheckCreatePermission();
        var image = Repository.Insert(MapToEntity(input));
        await CurrentUnitOfWork.SaveChangesAsync();

        return ObjectMapper.Map<LoginImageFullOutput>(image);
    }
}
