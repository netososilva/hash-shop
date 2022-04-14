# Hash Shop

Aplicação de compras em uma loja virtual. Código feito em .net core, c# e Docker.

## Dependências

- Para visualizar o código, você poderá utilizar qualquer uma das seguintes ferramentas:
    - Visual Studio Code (https://code.visualstudio.com/)
    - Visual Studio (https://visualstudio.microsoft.com/) 
    - Editor de texto de sua preferência;
- .NET Core 3.1 (https://dotnet.microsoft.com/en-us/download/dotnet/3.1);
- Docker (https://www.docker.com/products/docker-desktop/)

## Testes Automatizados
- Para executar os testes automatizados, você poderá utilizar qualquer uma das seguintes formas:
    - No Visual Studio, basta utilizar a janela Tests (https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2022);
    - No Visual Studio Code, há a opção pela ferramenta (https://code.visualstudio.com/api/working-with-extensions/testing-extension);
    - Pelo terminal, na raiz do projeto, através do comando:
    ```
    dotnet test
    ```

## Executando o projeto

- Para executar o projeto localmente, você poderá baixar a imagem docker do Docker Hub;
- Você pode baixar as imagens através dos comandos:
```
docker pull netososilva/hash-shop-api:latest
docker pull hashorg/hash-mock-discount-service
```
E executá-las através dos comandos:
```
docker run -p 8080:80 hash-shop-api
docker run -p 50051:50051 hashorg/hash-mock-discount-service
```

- Para testar a aplicação, basta abrir o link:

```
http://localhost:8080/swagger
```

## Docker-compose

- Para facilitar os testes, basta executar o seguinte comando, na raiz do projeto:
```
docker-compose up
```
- Para testar a aplicação, basta abrir o link:

```
http://localhost:8080/swagger
```

## Compilando o projeto

Para compilar a imagem docker, na raiz do projeto, execute o comando:
```
docker build -t netososilva/hash-shop-api -f Dockerfile .
```
- Após a compilação da imagem, rode a aplicação através do comando:
```
docker-compose up
```
- Para testar a aplicação, basta abrir o link:
```
http://localhost:8080/swagger
```
