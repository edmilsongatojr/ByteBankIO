﻿using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

        var buffer = new byte[1024];
        fluxoDoArquivo.Read(buffer, 0, buffer.Length);
        Console.ReadLine();
    }
}