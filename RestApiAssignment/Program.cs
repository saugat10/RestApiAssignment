var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string allowAllPolicy = "AllowAll";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllPolicy,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
app.UseCors(allowAllPolicy);

app.MapControllers();

app.Run();
