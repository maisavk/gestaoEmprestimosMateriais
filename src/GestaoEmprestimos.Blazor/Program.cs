using GestaoEmprestimos.Blazor.Components;
using GestaoEmprestimos.Application;

var builder = WebApplication.CreateBuilder(args);

// REGISTRO DO SERVIÇO COMO SINGLETON (Persistência em Memória)
builder.Services.AddSingleton<EmprestimoService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
