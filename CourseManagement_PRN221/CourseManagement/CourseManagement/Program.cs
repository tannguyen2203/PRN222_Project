using CrouseManagement.Repository.Models;
using CrouseManagement.Repository.Repository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CourseManagementContext>(); 
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<AttendenceRepository>();
builder.Services.AddScoped<MajorRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<SemesterRepository>();
builder.Services.AddScoped<SessionRepository>();
builder.Services.AddScoped<StudentInCourseRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<SubjectRepository>();


builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
