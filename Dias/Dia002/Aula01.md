## Como funciona uma aplicação Back-end?
```Text
Objetivo: compreender a comunicação entre cliente e servidor e identificar o papel da nossa API dentro desse processo.
```

### O que acontece quando você usa um site?
Ao acessar um loja virtual pelo navegador, você sabe de onde vêm dados como produtos, preços, imagens e informações visualizadas?
Uma aplicação real, normalmente, possui diferentes partes trabalhando nisso:

```mermaid
sequenceDiagram
  participant C as Cliente (Front-end)
  participant S as Servidor (Back-end)
  participant BD as Banco de Dados

  C-->>S: Requisição HTTP
  S-->>C: Resposta HTTP
  S-->>BD: Consulta ou Alteração de informações
  BD-->>S: Retorna registros
```
