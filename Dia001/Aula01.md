## Análise ```/src/OrderFlow.Api/Program.cs```

### Preparando a base do projeto
```CSharp
var builder = WebApplication.CreateBuilder(args);
```
Cria o "construtor" da sua aplicação. É como pegar a planta da casa e separar as **ferramentas** e **configurações iniciais** (como argumentos passados ao iniciar o programa).

```CSharp
builder.Services.AddOpenApi();
```
Adiciona à "caixa de ferramentas" do projeto o recurso de **gerar a documentação automática** da sua API (o OpenAPI).

```CSharp
var app = builder.Build();
```
Pega tudo o que foi preparado no **builder** e "monta" de fato a aplicação pronta para funcionar. A partir daqui, o que você configura é o caminho que cada pedido vai percorrer.

---

### Definindo o caminho dos pedidos
```CSharp
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
// "Estamos rodando isso no meu computador enquanto eu programo?". 
```
- Se estiver em modo de desenvolvimento, **ativa o endereço da documentação automática** para você testar e enxergar suas rotas mais fácil.
- Em produção (para o público geral), isso fica desligado por padrão.

```CSharp
app.UseHttpsRedirection();
```
Funciona como um porteiro que diz: "Se alguém chegar por um caminho sem cadeado de segurança (HTTP), mande ir pelo caminho seguro (HTTPS)."

---

### Dados de exemplo e a rota que responde aos pedidos
```CSharp
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
```
- ```app.MapGet("/weatherforecast", () =>``` cria um "balcão de atendimento" no endereço ```/weatherforecast``` para quem quer consultar (buscar) uma previsão do tempo. A seta ```=>``` significa "quando alguém pedir isso, execute o que vem a seguir".
- ```.WithName("GetWeatherForecast");``` dá um "apelido" interno (**GetWeatherForecast**) para essa rota, útil para identificação e documentação.

---

### Ligando o motor e o molde dos dados
```CSharp
app.Run();
```
Liga o servidor e deixa a aplicação rodando, esperando alguém fazer um pedido. É como virar a chave e abrir as portas.

<br>
<div align="center">

| [Voltar](Dia001) | [Próximo](Aula02.md) |
|---------------------|----------------------|
  
</div>
