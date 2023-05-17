using Spectre.Console;
using FullStackBank.Domain.Repository;

AnsiConsole.MarkupLine("Hello, World!");
var Repository = new PessoaFisicaRepository();

Repository.GetAll();