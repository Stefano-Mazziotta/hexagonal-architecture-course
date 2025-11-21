using ApplicationComponent;
using ApplicationComponent.DTOs;
using DomainComponent.Entities;
using DomainComponent.Interfaces;
using MapperComponent;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;
using RepositoryComponent.ExtraData;
using RepositoryComponent.Factories;
using RepositoryComponent.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ItemsDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IRepository, ItemRepository>();
builder.Services.AddTransient<ICommonRepository<Note>, NoteRepository>();

builder.Services.AddTransient<IService, ItemService>();
builder.Services.AddTransient<ICommonService<Note>, NoteService>();

// DTO en Application
builder.Services.AddTransient<ICommonRepository<NoteDTO>, NoteDTORepository>();
builder.Services.AddTransient<ICommonService<NoteDTO>, NoteDTOService>();

// Mapper en Application
builder.Services.AddTransient<IAddRepository<NoteModel>, NoteMapperRepository>();
builder.Services.AddTransient<IMapper<NoteDTO, Note>, NoteEntityMapper>();
builder.Services.AddTransient<IMapper<NoteDTO, NoteModel>, NoteModelMapper>();
builder.Services.AddTransient<IAddService<NoteDTO, NoteModel>, NoteMapperService<NoteDTO, NoteModel>>();

// Factory
builder.Services.AddTransient<IRepositoryFactory<IAddRepository<Note>, NoteExtraData>, NoteRepositoryFactory>();
builder.Services.AddTransient<IMapper<NoteDTO, NoteExtraData>, NoteExtraDataMapper>();
builder.Services.AddTransient<IAddService<NoteDTO, NoteExtraData>, NoteWithFactoryService<NoteDTO, NoteExtraData>>();

// Add new primary and secondary ports feature
builder.Services.AddTransient<ICompleteRepository, ItemRepository>();
builder.Services.AddTransient<IGetRepository<Item>, ItemRepository>();
builder.Services.AddTransient<ICompleteService, CompleteItemService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/items", async (IService service) => await service.GetAsync())
    .WithName("GetItems");

app.MapGet("/notes", async (ICommonService<Note> service) => await service.GetAsync())
    .WithName("GetNotes");

app.MapPost("items", async (string title, IService service) =>
{
    await service.AddAsync(title);
    return Results.Created();
}).WithName("AddItem");

app.MapPost("notes", async (Note note, ICommonService<Note> service) =>
{
    await service.AddAsync(note);
    return Results.Created();
}).WithName("AddNote");

app.MapGet("/notes-dto", async (ICommonService<NoteDTO> service) => await service.GetAsync())
    .WithName("GetNotesDTO");

app.MapPost("notes-dto", async (NoteDTO dto, ICommonService<NoteDTO> service) =>
{
    await service.AddAsync(dto);
    return Results.Created();
}).WithName("AddNoteDTO");

app.MapPost("notes-mapper", async (NoteDTO dto, IAddService<NoteDTO, NoteModel> service) =>
{
    await service.AddAsync(dto);
    return Results.Created();
}).WithName("AddNoteMapper");

app.MapPost("notes-factory", async (NoteDTO dto, IAddService<NoteDTO, NoteExtraData> service) =>
{
    await service.AddAsync(dto);
    return Results.Created();
}).WithName("AddNoteFactory");

app.MapPut("complete-item/{id}", async (int id, ICompleteService service) =>
{
    try
    {
        await service.Complete(id);
        return Results.NoContent();
    }
    catch (KeyNotFoundException exception)
    {
        return Results.NotFound(exception.Message);
    }
    catch (ArgumentException exception)
    {
        return Results.InternalServerError(exception.Message);
    }
}).WithName("CompleteItem");

app.Run();
