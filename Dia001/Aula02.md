## Nosso primeiro endpoint

```CSharp
app.MapGet("/api/status", () =>
{
    return Results.Ok(new
    {
        application = "OrderFlow",
        status = "Online",
        message = "A API está funcionando!"
    });
});
```

- ```MapGet```: registra um endpoint que responde a requisições HTTP GET.
- ```/api/status```: define o endereço do recurso.
- ```Results.Ok```: produz uma resposta HTTP de sucesso, com status 200 OK.
- O objeto anônimo representa os dados que serão convertidos para JSON.

Requisição para: 
```Text
/api/status
```

Retorno esperada:
```Json
{
  "application": "OrderFlow",
  "status": "Online",
  "message": "A API está funcionando!"
}
```

Resposta adquirido com sucesso?
- [ ] SIM
- [ ] NÃO

<br>
<div align="center">

| [Voltar à pasta](Aula02.md/..) | [Aula anterior](Aula02.md/../Aula01.md) | [Próxima Aula](Aula02.md/../Aula03.md) |
|--------------------------------|-----------------------------------------|----------------------------------------|
  
</div>
