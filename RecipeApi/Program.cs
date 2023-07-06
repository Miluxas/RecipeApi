﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RecipeApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeApiContext") ?? throw new InvalidOperationException("Connection string 'RecipeApiContext' not found.")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
