# Model Binding no ASP.NET Core (C#)
Imaginando que recebemos a seguinte requisição:
```HTTP
GET /api/products/10
```

No ASP .NET Core, podemos escrever:
```C#
app.MapGet("/api/products/{id}", (int id) =>
{
    return Results.Ok($"Produto: {id}");
});
```

Percebemos que o ASP.NET Core identifica o valor `10` na URL e o associa ao parâmetro `id`. Esse processo é chamado de **Model Binding**.

> Em outras palavras: o ASP.NET Core recebe os dados da requisição e tenta associá-los aos parâmetros e objetos definidos no nosso código.

---

Exemplos:
| Origem | Requisição | Destino no C# |
|:---|:---|:---|
|Route	|/products/10	|int id|
|Query	|/orders?customerId=25	|int customerId|
|Body	|JSON com nome e preço	|Objeto C#|

## E quando os dados vêm no Body?
Imagine que o cliente envie:
```HTTP
POST /api/products
Content-Type: application/json
```
```Json
{
  "name": "Monitor",
  "price": 850.00,
  "stock": 8
}
```

---
No C#, podemos representar esses dados numa classe:
```C#
public class CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
```

E receber o código no seguinte endpoint:
```C#
app.MapPost("/api/products", (CreateProductRequest product) =>
{
    return Results.Ok(product);
});
```

O ASP.NET Core lê o JSON e cria um objeto `CreateProductRequest` com os valores recebidos. Assim, temos:
- Um objeto representando os dados necessários para criar um produto.
- Propriedades com nomes e tipos definidos.
- Um único parâmetro para receber todas essas informações.
- Um modelo que pode ser reutilizado e evoluído conforme a necessidade.

--- 
Sem objeto:
```C#
(string name, decimal price, int stock)
```

Com objeto:
```C#
(CreateProductRequest product)
```

> Uma observação: os dados não ficam necessariamente mais seguros só por estarem em um objeto. A principal vantagem aqui é a **organização** e a **representação clara** dos dados esperados.

<br>
<div align="center">

| [Voltar à pasta](Aula02.md/..) | [Aula anterior](Aula02.md/../Aula01.md) | [Próximo dia](Aula02.md/../../Dia005) |
|--------------------------------|-----------------------------------------|----------------------------------------|
  
</div>
