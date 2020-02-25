# Password Validation Web API

Web API para validação de senha.
Validação em cima de 5 regras:
* Nove ou mais caracteres;
* Conter ao menos 1 dígito numérico;
* Conter ao menos 1 letra minuscula;
* Conter ao menos 1 letra maiuscula;
* Conter ao menos 1 caractere especial.

Exemplo:
```
IsValid("") -> false
IsValid("aa") -> false
IsValid("ab") -> false
IsValid("AAAbbbCc") -> false
IsValid("AbTp9!foo") -> true
```

## Pré-Requisitos

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [Postman](https://www.postman.com/)

## Executando os testes unitários

Acesse o diretório .\PasswordValidation.Test e execute o comando:

```
dotnet test
```

Os testes serão executados e serão exibidos os resultados.

## Executando o projeto localmente

Acesse o diretório .\PasswordValidation.Core e execute os comandos:

```
dotnet restore
dotnet run
```

o restore irá restaurar as dependencias do nuget e o run irá executar o projeto.

Utilizando o Postman, crie um novo Request em Post e aponte para a URL https://localhost:5001/api/password/isvalid.


Pelo body envie um JSON no formado abaixo:

```
{
	"password": "exemploDeSenha@1"
}
```
Informe a senha que deseja validar.

O retorno será no formato padrão de resposta dessa aplicação:

```
{
    "isValid": true
}
```
* Campo: isValid (boolean) retorna se a senha é válida ou não.

## Troubleshooting

Caso esteja utilizando o Postman e não esteja conseguindo acessar a URL informada para teste, verifique se a opção de 
SSL Certificate Verification está desabilitada em Configurações.