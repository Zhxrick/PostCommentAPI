using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Service;
using PostCommentAPI.Infraestructure.Interface;
using PostCommentAPI.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostServices, PostServices>();

builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ICommentsServices, CommentServices>();

builder.Services.AddScoped<IPostDetailsService, PostDetailsService>();
builder.Services.AddScoped<IPostDetailsRepository, PostDetailsRepository>();


builder.Services.AddCors(option =>
{
    option.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Politica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
