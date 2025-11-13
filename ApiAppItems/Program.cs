using ApplicationComponent;
using ApplicationComponent.DTOs;
using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent;

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



app.Run();
