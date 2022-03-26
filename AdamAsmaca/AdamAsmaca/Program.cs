using System;

namespace AdamAsmaca
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Bir kelime grubundan rastgele bir kelime seç. (ayna)
             * 2. Seçtiğin bu kelimenin her harfini * işaretine dönüştür
             * 3. Bu bulmacayı ekranda göster. (****)
             * 4. Oyuncudan harf iste 
             * 5. Harf kelimede var mı kontrol et.
             * 6. a. Eğer varsa, o harfin bulunduğu * işaretlerini harfe çevir (Örnek a**a)
             *    b. Yoksa bir hakkını azalt
             * 7. Oyuncudan kelimeyi tahmin etmesini iste
             *    Bilirse oyunu bitir
             *    Bilemezse 3. adıma dön
             */

            int right = 4;
            bool isGameOver = false;
            string letter = "";
            string prediction = "";
            string[] words = { "ayna", "masa", "tarantula", "endoplazmikretikulum" };
            string selectedWord = ChooseWord(words);
            string puzzle = ReplaceToStar(selectedWord);
            while (!isGameOver )
            {
                Console.WriteLine(puzzle);
                letter =EnterLetters();
               
                bool isLetterExistInWord = CheckLetterInWord(selectedWord, letter);
                if (isLetterExistInWord)
                {
                    puzzle = ReplaceStarToLetter(selectedWord, puzzle, letter);
                    
                }
                else
                {
                    right--;
                    Console.WriteLine($"Harf bilemediniz .{right} hakkınız kaldı");
                }
                Console.WriteLine(puzzle);
                Console.Write("Kelimeyi tahmin ediniz ");
                prediction = Console.ReadLine();
                if (prediction.ToUpper() == selectedWord.ToUpper())
                {
                    Console.WriteLine("Doğru Tahmin Ettiniz");
                    isGameOver = true;
                }

                else
                {
                    Console.WriteLine("Yanlış Tahmin");
                }
                 
                
                if (right == 0)
                {
                    Console.WriteLine("Hakkınız doldu.Oyunu kaybettiniz");
                    isGameOver = true;
                }

            }
        }

        /// <summary>
        /// Kullanıcının harf girmesini sağlayan metod
        /// </summary>
        /// <returns></returns>
        private static string EnterLetters()
        {
            string letter = String.Empty;
            Console.Write("Bir harf giriniz : ");
            letter = Console.ReadLine();
            return letter;
        }

        static string ChooseWord(string[] words)
        {
            Random random = new Random();
            string word = words[random.Next(0, words.Length)];
            return word;
        }

        private static string ReplaceToStar(string selectedWord)
        {
            string puzzleResult = string.Empty;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                puzzleResult += "*";
            }
            return puzzleResult;
        }

        /// <summary>
        /// Bu metod ile bir kelimede bir harf olup olmadığını bulursunuz.
        /// </summary>
        /// <param name="selectedWord">Kaynak kelime</param>
        /// <param name="letter">Aranacak harf</param>
        /// <returns></returns>
        private static bool CheckLetterInWord(string selectedWord, string letter)
        {
            return selectedWord.Contains(letter);
        }

        private static string ReplaceStarToLetter(string selectedWord, string puzzle, string letter)
        {
            int startIndex = 0;
            char[] puzzleStars = puzzle.ToCharArray();
            while (selectedWord.IndexOf(letter, startIndex) != -1)
            {
                int findingIndex = selectedWord.IndexOf(letter, startIndex);
                puzzleStars[findingIndex] = Convert.ToChar(letter);
                startIndex = findingIndex + 1;

            }

            string result = string.Empty;
            foreach (var item in puzzleStars)
            {
                result += item.ToString();
            }

            return result;

        }
    }
}
