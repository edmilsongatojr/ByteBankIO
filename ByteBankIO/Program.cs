﻿using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoArquivo = "Contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);
            //var linha = leitor.ReadLine();
            // var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"Conta numero {contaCorrente.Numero}, Agencia: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo} ";
                Console.WriteLine(msg);
            }
        }
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(',');
        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.',',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular; ;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

       return resultado;
    }
}