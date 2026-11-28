# Parâmetros HTTP
```Text
Como consultar um produto específico, pesquisar produtos pelo nome ou filtrar pedidos por status?
```

Existem diferentes mecanismos para enviar essas informações ao servidor:
  1. Route parameters
  2. Query parameters
  3. Body parameters

## 1. Route parameters - Parâmetros de rota
Exemplo de produtos:

| Id | Produto |
|:---|:---|
| 1 | Teclado|
| 2 | Mouse |
| 3 | Monitor |

Para consultar o produto de ID 2, podemos enviar:
```HTTP
GET /api/products/2
```
O número `2`, presente na rota da URL, é o `Route Parameter`.

---

Outros exemplos:
```HTTP
GET /api/products/1
GET /api/products/2
GET /api/products/3
```

> Perceba que o caminho permanece o mesmo, mas o identificador muda.

---

### Quando utilizar?
Geralmente, quando queremos identificar um recurso específico.

---

## 2. Query parameters - Parâmetros de consulta
```Text
Como listar todos os produtos que possuem a categoria Eletrônicos?
```

Para isso, podemos enviar:
```HTTP
GET /api/products?category=Eletronicos
```
Perceba a diferença:
- O caminho identifica o recurso: `/api/products`.
- O ponto de interrogação `?` inicia os parâmetros de consulta.
- `category` é o nome do parâmetro.
- `Eletronicos` é o valor.

---

Também podemos enviar diferentes parâmetros:
```HTTP
GET /api/products?category=Eletronicos&minPrice=100&maxPrice=500
```
Nesse exemplo, estamos solicitando produtos:
- Da categoria `Eletrônicos`.
- Com preço mínimo de `100`.
- Com preço máximo de `500`.

---

### Quando utilizar?
Principalmente para filtros, pesquisas, ordenação e paginação.

---

## 3. Body Parameters — Dados no corpo da requisição
```Text
O que precisos para cadastrar um produto?
```
Para isso, precisamos enviar várias informações, como:
- Nome.
- Preço.
- Quantidade em estoque.

Nesse caso, podemos utilizar o Body:
```HTTP
POST /api/products
Content-Type: application/json
```

```Json
{
  "name": "Teclado Mecânico",
  "price": 250.00,
  "stock": 15
}
```
O servidor irá receber esses dados e pode utilizá-los para cadastrar o produto.

---

### Quando utilizar?
Quando precisamos enviar um conjunto de informações para uma operação, especialmente na criação ou atualização de recursos.

---

## 4. Comparação
Utilizando uma única entidade `Product`:
> **Route parameter**
>
> ```HTTP
> GET /api/products/10
> ```
>
> Identifica qual produto queremos consultar.
>
> ---
>
> **Query parameter**
>
> ```HTTP
> GET /api/products?category=Eletronicos
> ```
>
> Define critérios para filtrar os produtos.
>
> ---
> 
> **Body parameter**
>
> ```Json
> {
>   "name": "Teclado",
>   "price": 250
> }
> ```
>
> Envia os dados necessários para uma operação.

Uma forma simples de memorizar:
- `Route`: qual recurso?
- `Query`: quais critérios?
- `Body`: quais dados?

Isso é apenas uma simplificação didática, mas funciona muito bem para começar.

<br>
<div align="center">

| [Voltar à pasta](Aula01.md/..) | [Próxima aula](Aula01.md/../Aula02.md) |
|--------------------------------|----------------------------------------|
  
</div>
