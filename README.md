# Hash Shop

Aplicação de compras em uma loja virtual. Código feito em .net core, c# e Docker.

## Build

- Instalar o Visual Studio Code (https://code.visualstudio.com/), Visual Studio (https://visualstudio.microsoft.com/) ou o editor de texto de sua preferência;
- Instalar o framework .net core 3.1 (https://dotnet.microsoft.com/en-us/download/dotnet/3.1);
- Após a instalação dessas ferramentas, abrir o projeto no editor de texto ou no Visual Studio;
- Caso seja no Visual Studio, para rodar os testes, basta utilizar a janela Tests (https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2022);
- Caso você esteja utilizando o Visual Studio Code, há a opção pela ferramenta também (https://code.visualstudio.com/api/working-with-extensions/testing-extension);
- Alternativamente, na raiz do projeto, os testes poderam ser executados e o resultado visto no terminal, através do comando:
```
dotnet test
```

## Testes

- Para testar o projeto localmente, será necessário compilar a imagem docker. Na raiz do projeto, execute o comando:
```
docker build -t hash-shop-api -f Dockerfile .
```
- Após a compilação da imagem, rode a aplicação através do comando:
```
docker-compose up
```
- Não é preciso dizer que existe da dependência do Docker (https://www.docker.com/products/docker-desktop/)
