var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<ExamenItalikaData.Alumnos.IAlumnosData, ExamenItalikaData.Alumnos.AlumnosData>();
builder.Services.AddTransient<ExamenItalikaServices.Alumnos.IAlumnosServices, ExamenItalikaServices.Alumnos.AlumnosServices>();

builder.Services.AddTransient<ExamenItalikaData.Escuelas.IEscuelasData, ExamenItalikaData.Escuelas.EscuelasData>();
builder.Services.AddTransient<ExamenItalikaServices.Escuelas.IEscuelasServices, ExamenItalikaServices.Escuelas.EscuelasServices>();

builder.Services.AddTransient<ExamenItalikaData.Profesores.IProfesoresData, ExamenItalikaData.Profesores.ProfesoresData>();
builder.Services.AddTransient<ExamenItalikaServices.Profesores.IProfesoresServices, ExamenItalikaServices.Profesores.ProfesoresServices>();


// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
