﻿using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Oyunda İki Oyuncu olacak
             * Her bir oyuncuda iki adet zar olacak
             * Oyuncular sırasıyla zar atar
             * Zarlar karşılaştırılır
             * Büyük Atan Kazanır
             * 
             * 
             * Nesneler
             * 1.Oyun
             * 2.Oyuncu
             * 3.Zar
             * 
            */
            do
            {
                Game game = new Game();
                game.PlayerOne = new Player { Name = "Uğur Okan Çivgin" };
                game.PlayerTwo = new Player { Name = "Sait Çivgin" };
                game.PlayAndTurn();
                game.ShowWinner();
                Console.WriteLine("Oyunu bitirmek ister misin?");
            } while (Console.ReadLine().ToUpper()!="E");
            
        }
    }
}
